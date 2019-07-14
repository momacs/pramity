from flask import Flask, request, jsonify
app = Flask(__name__)

@app.route('/')
def home():
	return 'Hello'

@app.route('/test_connection', methods=['POST'])
def test_connection():
	return 'Hello!'

@app.route('/run_simulation', methods=['POST']):
def run_simulation():
	post_data = request.get_json()

	response_data = {}

	initial_groups = post_data['groups']
	rules = post_data['rules']
	probe = post_data['probe']
	runs = post_data['runCount']

	resulting_groups = [initial_groups]
	return jsonify(resulting_groups)