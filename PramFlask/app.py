from flask import Flask, request, jsonify
import os,sys
sys.path.append(os.path.join(os.path.dirname(__file__), '..'))  # 'rules' module
sys.path.append(os.path.join(os.path.dirname(__file__), '..', '..'))

from pram.data   import GroupSizeProbe, ProbeMsgMode
from pram.entity import Group, GroupQry, GroupSplitSpec, Site
from pram.rule   import GoToRule, DiscreteInvMarkovChain, TimeInt
from pram.sim    import Simulation

import json
import MassFlows

app = Flask(__name__)
rules = {}

def add_initial_rules():
	"Imports rules built into pram and inserts them into the rules dictionary"
	rules["Simple Flu Progress Rule"] = DiscreteInvMarkovChain('flu-status', { 's': [0.95, 0.05, 0.00], 'i': [0.00, 0.50, 0.50], 'r': [0.10, 0.00, 0.90] })
	return

@app.route('/')
def home():
	return 'Hello'

@app.route('/rule/<rule_name>')
def access_rules(rule_name):
	if rule_name in rules.keys():
		return jsonify(rules[rule_name])
	return jsonify(None)

@app.route('/rule', methods=['POST'])
def add_rule():
	post_data = request.get_json()

	rule_name = post_data['name']
	description = post_data['description']
	instructions = post_data['instructions']

	if rule_name in rules.keys():
		return 'failure'

	rules[rule_name] = {'description': description, 'instructions': instructions}
	return rule_name + 'added'

def make_attributes_serializable(attr):
    keys = []
    vals = []
    for k, v in attr.items():
        keys.append(k)
        vals.append(v)
    return keys, vals

def get_mass_flow(s):
    redistributions = []
    for mfs in s.pop.last_iter.mass_flow_specs:
        for g_dst in mfs.dst:
            redistribution = {}

            source_dict = {}
            source_dict['attributeKeys'], source_dict['attributeValues'] = make_attributes_serializable(mfs.src.attr)
            if Site.AT in mfs.src.rel.keys():
                source_dict['site'] = mfs.src.rel[Site.AT]
            else:
                source_dict['site'] = None
            source_dict['n'] = 0

            destination_dict = {}
            destination_dict['attributeKeys'], destination_dict['attributeValues'] = make_attributes_serializable(g_dst.attr)
            if Site.AT in g_dst.rel.keys():
                destination_dict['site'] = g_dst.rel[Site.AT]
            else:
                destination_dict['site'] = None

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

	s = Simulation(do_keep_mass_flow_specs=True)

	for rule_name in included_rules:
		s.add_rule(rules[rule_name])

	g_index = 0
	for group in initial_groups:
		g_name = "g" + str(g_index)
		g_index = g_index + 1
		g_mass = group['n']
		g_attributes = get_attribute_dictionary(group['attributeKeys'], group['attributeValues'])
		s.add_group(Group(g_name, g_mass, g_attributes))

	flows = run_and_get_mass_flow(s, runs)

	return jsonify(flows)

add_initial_rules()