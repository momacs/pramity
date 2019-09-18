from flask import Flask, request, jsonify
import os,sys
sys.path.append(os.path.join(os.path.dirname(__file__), '..'))  # 'rules' module
sys.path.append(os.path.join(os.path.dirname(__file__), '..', '..'))

from pram.data   import GroupSizeProbe, ProbeMsgMode
from pram.entity import Group, GroupQry, GroupSplitSpec, Site
from pram.rule   import GoToRule, DiscreteInvMarkovChain, TimeInt, TimePoint
from pram.sim    import Simulation

import json
import MassFlows

app = Flask(__name__)
rules = {}
sites = []
probe_grp_size_site = None

def add_initial_rules(time_offset):
	"Imports rules built into pram and inserts them into the rules dictionary"
	rules["Simple Flu Progress Rule"] = [DiscreteInvMarkovChain('flu-status', { 's': [0.95, 0.05, 0.00], 'i': [0.00, 0.50, 0.50], 'r': [0.10, 0.00, 0.90] })]
	rules["Home-Work-School Rules"] = [GoToRule(TimeInt( (8 - time_offset)%24,(12 - time_offset)%24), 0.4, 'home',  'work',  'Some agents leave home to go to work'),
		GoToRule(TimeInt((16- time_offset)%24,(20- time_offset)%24), 0.4, 'work',  'home',  'Some agents return home from work'),
		GoToRule(TimeInt((16- time_offset)%24,(21- time_offset)%24), 0.2, 'home',  'store', 'Some agents go to a store after getting back home'),
		GoToRule(TimeInt((17- time_offset)%24,(23- time_offset)%24), 0.3, 'store', 'home',  'Some shopping agents return home from a store'),
		GoToRule(TimePoint((24- time_offset)%25),  1.0, 'store', 'home',  'All shopping agents return home after stores close'),
		GoToRule(TimePoint( (2- time_offset)%25),  1.0, None, 'home',  'All still-working agents return home')]

	global sites 
	global probe_grp_size_site
	sites = {s:Site(s) for s in ['home', 'work-a', 'work-b', 'work-c', 'store-a', 'store-b']}
	probe_grp_size_site = GroupSizeProbe.by_rel('site', Site.AT, sites.values(), msg_mode=ProbeMsgMode.DISP, memo='Mass distribution across sites')
	return

@app.route('/')
def home():
	return 'Hello World!'

def make_relations_serializable(attr):
	keys = []
	vals = []
	for k, v in attr.items():
		if not k == Site.AT:
			keys.append(k)
			vals.append(v.name)
	return keys, vals

def make_attributes_serializable(attr):
	keys = []
	vals = []
	for k, v in attr.items():
		keys.append(k)
		vals.append(v)
	return keys, vals

def get_mass_flow(s):
    redistributions = []
    if s.pop.last_iter.mass_flow_specs == None:
    	return redistributions
    for mfs in s.pop.last_iter.mass_flow_specs:
        for g_dst in mfs.dst:
            redistribution = {}

            source_dict = {}
            source_dict['attributeKeys'], source_dict['attributeValues'] = make_attributes_serializable(mfs.src.attr)
            if Site.AT in mfs.src.rel.keys():
                source_dict['site'] = mfs.src.rel[Site.AT].name
            else:
                source_dict['site'] = None
            source_dict['n'] = 0
            source_dict['relationKeys'], source_dict['relationValues'] = make_relations_serializable(mfs.src.rel)

            destination_dict = {}
            destination_dict['attributeKeys'], destination_dict['attributeValues'] = make_attributes_serializable(g_dst.attr)
            if Site.AT in g_dst.rel.keys():
                destination_dict['site'] = g_dst.rel[Site.AT].name
            else:
                destination_dict['site'] = None
            destination_dict['relationKeys'], destination_dict['relationValues'] = make_relations_serializable(g_dst.rel)

            destination_dict['n'] = 0

            redistribution['source'] = source_dict
            redistribution['destination'] = destination_dict
            redistribution['mass'] = g_dst.m

            redistributions.append(redistribution)
    return {"redistributions": redistributions}

def run_and_get_mass_flow(s, number_of_iterations):
    simSteps = []
    for i in range(number_of_iterations):
        s.run(1)
        simSteps.append(get_mass_flow(s))
    return {"simSteps": simSteps}

def get_attribute_dictionary(k, v):
	a_dict = {}
	for i in range(len(k)):
		a_dict[k[i]] = v[i]

	return a_dict

@app.route('/run_simulation', methods=['POST'])
def run_simulation():
	sim_info = json.loads(request.form['runInfo'])

	initial_groups = sim_info['groups']
	included_rules = sim_info['rules']
	runs = sim_info['runs']
	time_offset = sim_info['start_time']

	add_initial_rules(time_offset)

	s = Simulation(do_keep_mass_flow_specs=True)
	#s.add_probe(probe_grp_size_site)

	for rule_name in included_rules:
		for r in rules[rule_name]:
			s.add_rule(r)

	g_index = 0
	for group in initial_groups:
		g_name = "g" + str(g_index)
		g_index = g_index + 1
		g_mass = group['n']
		g_attributes = get_attribute_dictionary(group['attributeKeys'], group['attributeValues'])
		g_relations = get_attribute_dictionary(group['relationKeys'], group['relationValues'])
		g = Group(g_name, g_mass, g_attributes)

		if not group['site'] == "":
			g.set_rel(Site.AT, sites[group['site']])

		for k,v in g_relations.items():
			g.set_rel(k, sites[v])
		s.add_group(g)

	flows = run_and_get_mass_flow(s, runs)

	return jsonify(flows)

