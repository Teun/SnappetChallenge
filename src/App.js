import React, { Component } from 'react';
import './App.css';
import "react-vis/dist/style.css";
import work from './data/work.json';
import moment from 'moment';
import { Boxplot, computeBoxplotStats } from 'react-boxplot';
import { XYPlot, XAxis, YAxis, HorizontalGridLines, MarkSeries, VerticalBarSeriesCanvas } from 'react-vis';

const formatStatsByStudent = (work) => {
  const students = {};
  work.forEach(w => {
    let student = students[w.UserId];
    if (!student) {
      student = {
        'progress': 0,
        'qnsCorrect': 0,
        'qnsWrong': 0,
      }
    }

    // progress scores
    student.progress += w.Progress;

    // question scores
    if (w.Correct) {
      student.qnsCorrect += 1
    } else {
      student.qnsWrong += 1
    }

    students[w.UserId] = student
  })

  return students;
}

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

    const statsByStudent = formatStatsByStudent(todayWork)

    this.state = {
      statsByStudent,
    }
  }


  render() {

    const progressBoxPlotStats = Object.keys(this.state.statsByStudent).map(userId => {
      return this.state.statsByStudent[userId].progress;
    })

    const qnsCorrectBoxPlotStats = Object.keys(this.state.statsByStudent).map(userId => {
      return this.state.statsByStudent[userId].qnsCorrect;
    })

    const qnsWrongBoxPlotStats = Object.keys(this.state.statsByStudent).map(userId => {
      return this.state.statsByStudent[userId].qnsWrong;
    })

    const qnsAttemptedBoxPlotStats = Object.keys(this.state.statsByStudent).map(userId => {
      return this.state.statsByStudent[userId].qnsCorrect + this.state.statsByStudent[userId].qnsWrong;
    })

    const progressGraphStats = Object.keys(this.state.statsByStudent)
      .map((userId, index) => {
        return {
          x: index,
          y: this.state.statsByStudent[userId].progress,
        }
      })
      .sort((userA, userB) => {
        if (userA.y < userB.y) {
          return -1
        } else {
          return 1
        }
      })
      .map((user, index) => {
        user.x = index
        return user
      })

    const correctGraphStats = Object.keys(this.state.statsByStudent)
      .sort((studentAId, studentBId) => {
        const studentA = this.state.statsByStudent[studentAId]
        const studentB = this.state.statsByStudent[studentBId]
        const aScores = studentA.qnsCorrect + studentA.qnsWrong
        const bScores = studentB.qnsCorrect + studentB.qnsWrong
        if (aScores < bScores) {
          return -1
        } else {
          return 1
        }
      })
      .map((userId, index) => {
        return {
          x: index,
          y: this.state.statsByStudent[userId].qnsCorrect,
        }
      })

    const wrongGraphStats = Object.keys(this.state.statsByStudent)
    .sort((studentAId, studentBId) => {
      const studentA = this.state.statsByStudent[studentAId]
      const studentB = this.state.statsByStudent[studentBId]
      const aScores = studentA.qnsCorrect + studentA.qnsWrong
      const bScores = studentB.qnsCorrect + studentB.qnsWrong
      if (aScores < bScores) {
        return -1
      } else {
        return 1
      }
    })
    .map((userId, index) => {
      return {
        x: index,
        y: this.state.statsByStudent[userId].qnsWrong,
      }
    })

    return (
      <div className="App">
        <header className="App-header">
          <p>
            Welcome Mr James, these are your class scores for today.
          </p>
        </header>
        <div className="App-body">
          <div id='summary-panel'>
            <p className='title'>Class Summary</p>

            <p className='summary-subheader'>Progress by student</p>
            <div className='summary-item'>
              <Boxplot
                width={200}
                height={20}
                orientation="horizontal"
                min={Math.min(...progressBoxPlotStats)}
                max={Math.max(...progressBoxPlotStats)}
                stats={computeBoxplotStats(progressBoxPlotStats)}
              />
            </div>

            <p className='summary-subheader'>Correct answers by student</p>
            <div className='summary-item'>
              <Boxplot
                width={200}
                height={20}
                orientation="horizontal"
                min={Math.min(...qnsCorrectBoxPlotStats)}
                max={Math.max(...qnsCorrectBoxPlotStats)}
                stats={computeBoxplotStats(qnsCorrectBoxPlotStats)}
              />
            </div>


            <p className='summary-subheader'>Wrong answers by student</p>
            <div className='summary-item'>
              <Boxplot
                width={200}
                height={20}
                orientation="horizontal"
                min={Math.min(...qnsWrongBoxPlotStats)}
                max={Math.max(...qnsWrongBoxPlotStats)}
                stats={computeBoxplotStats(qnsWrongBoxPlotStats)}
              />
            </div>

            <p className='summary-subheader'>Total questions answered by each student</p>
            <div className='summary-item'>
              <Boxplot
                width={200}
                height={20}
                orientation="horizontal"
                min={Math.min(...qnsAttemptedBoxPlotStats)}
                max={Math.max(...qnsAttemptedBoxPlotStats)}
                stats={computeBoxplotStats(qnsAttemptedBoxPlotStats)}
              />
            </div>

          </div>

          <div id='dashboard'>
            <p className='title'>Dashboard</p>

            <div className='widget-holder'>
              <div className='widget'>
                <p className='summary-subheader'>Progress by Student</p>
                <XYPlot
                  width={300}
                  height={300}>
                  <HorizontalGridLines />
                  <MarkSeries
                    data={progressGraphStats}/>
                  <YAxis />
                </XYPlot>
              </div>
              <div className='widget'>
                <p className='summary-subheader'>Answers by Student</p>
                <XYPlot
                  width={300}
                  height={300}
                  stackBy="y">
                  <HorizontalGridLines />
                  <VerticalBarSeriesCanvas data={correctGraphStats} />
                  <VerticalBarSeriesCanvas data={wrongGraphStats} />
                  <YAxis />
                </XYPlot>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default App;
