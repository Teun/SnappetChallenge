import flask
from flask import Flask
import json
import logic
app = Flask(__name__)

@app.route('/')
def dashboard():
    return flask.render_template('dashboard.html')

@app.route('/time_spent/<filteron>')
def time_spent(filteron):
    if filteron == 'Overall':
        filteron = None
    response = logic.time_spent(df, filteron=filteron)
    return json.dumps(response)

@app.route('/progress/<filteron>/<user_id>')
def progress(filteron, user_id):
    if filteron == 'Overall':
        filteron = None
    response = logic.absolute_progress_against_peer_group(df, filteron=filteron, user_id=int(user_id))
    return json.dumps(response)

@app.route('/students')
def students():
    return json.dumps(logic.student_list())

if __name__ == '__main__':
    df = logic.load_data()
    app.run(host='0.0.0.0', port=5000, debug=True)