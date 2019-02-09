import React, { Component } from 'react';
import './App.css';
import work from './data/work.json';
import moment from 'moment';

class App extends Component {
  constructor(props) {
    super(props)

    const nowString = "2015-03-24T11:30:00.00+00:00"
    const now = moment(nowString).utcOffset('+0100')

    const startOfDay = now.clone().startOf('day')

    const todayWork = work.filter(w => {
      const datetime = moment(w.SubmitDateTime).utcOffset('+0100')
      return datetime.isBefore(now) && datetime.isAfter(startOfDay)
    })

    this.state = {
      todayWork
    }
  }


  render() {
    return (
      <div className="App">
        <header className="App-header">
          <p>
            Welcome Mr James, this are your class scores for today.
          </p>
        </header>
        <div className="App-body">
          <div>
            
          </div>
        </div>
      </div>
    );
  }
}

export default App;
