from flask import Flask, request, jsonify
import os,sys
sys.path.append(os.path.join(os.path.dirname(__file__), '..'))  # 'rules' module
sys.path.append(os.path.join(os.path.dirname(__file__), '..', '..'))

from pram.data   import GroupSizeProbe, ProbeMsgMode
from pram.entity import Group, GroupQry, GroupSplitSpec, Site
from pram.rule   import GoToRule, DiscreteInvMarkovChain, TimeInt
from pram.sim    import Simulation

import json

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

@app.route('/run_simulation', methods=['POST'])
def run_simulation():
	sim_info = json.loads(request.form['runInfo'])

	initial_groups = sim_info['groups']
	rules = sim_info['rules']
	runs = sim_info['runs']

	print(initial_groups)
	print()
	print(rules)
	print()
	print(runs)

	resulting_groups = [initial_groups]
	return jsonify(resulting_groups)

add_initial_rules()