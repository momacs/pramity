from flask import Flask, request, jsonify

app = Flask(__name__)
rules = {}

def add_initial_rules():
	"Imports rules built into pram and inserts them into the rules dictionary"
	pass

@app.route('/')
def home():
	return 'Hello'

@app.route('/test_connection', methods=['POST'])
def test_connection():
	return 'Hello!'

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
	post_data = request.get_json()

	response_data = {}

	initial_groups = post_data['groups']
	rules = post_data['rules']
	probe = post_data['probe']
	runs = post_data['runCount']

	resulting_groups = [initial_groups]
	return jsonify(resulting_groups)

add_initial_rules()