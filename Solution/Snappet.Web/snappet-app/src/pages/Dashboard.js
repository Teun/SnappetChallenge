import axios from "axios";
import React, { Component } from "react";
import HorizontalChart from "../components/HorizontalChart";
import StatsContainer from "../components/StatsContainer";
import SubjectStatsTable from "../components/SubjectStatsTable";
import StudentsStatsTable from "../components/StudentsStatsTable";
import "./dashboard.css";

export default class Dashboard extends Component {
  constructor(props) {
    super(props);

    this.state = {
      loading: true,
      summary: {}
    }
  }

  componentDidMount() {
    axios.get("http://localhost:51275/api/stats/today")
      .then(resp => {
        this.setState({ loading: false, summary: resp.data })
      })
  }

  domainProgressChart() {
    const domainStats = getDomainStats(this.state.summary);
    return (
      <StatsContainer title={"Progress By Domain"}>
        <HorizontalChart options={domainStats.options} data={domainStats.data} />
      </StatsContainer>
    )
  }

  learningObjectProgressChart() {
    const learningObjectiveStats = getLearningObjectiveStats(this.state.summary);
    return (
      <StatsContainer title={"Progress By Learning Objective"}>
        <HorizontalChart options={learningObjectiveStats.options} data={learningObjectiveStats.data} />
      </StatsContainer>
    )
  }

  subjectStatsTable() {
    return (
      <StatsContainer title={"Progress By Subject"}>
        <SubjectStatsTable>
          {this.state.summary.subjects.map(s => {
            return (
              <tr>
                <td>{s.subject}</td>
                <td>{s.answersSubmitted}</td>
                <td>{s.correctAnswers}</td>
                <td>{s.inCorrectAnswers}</td>
                <td>{s.averageProgress.toFixed(2)}</td>
                <td>{s.averageDifficulty.toFixed(2)}</td>
              </tr>
            )
          })}
        </SubjectStatsTable>
      </StatsContainer>
    )
  }

  studentsStatsTable() {
    return (
      <StatsContainer title={"Progress By Student"} >
        <StudentsStatsTable>
          {this.state.summary.students.map(s => {
            return (
              <tr>
                <td>{s.studentId}</td>
                <td>{s.subject}</td>
                <td>{s.answersSubmitted}</td>
                <td>{s.correct}</td>
                <td>{s.inCorrect}</td>
              </tr>
            )
          })}
        </StudentsStatsTable>
      </StatsContainer>
    )
  }
  render() {

    const { loading } = this.state;
    if (loading) return (<div>loading...</div>)

    const domainChart = this.domainProgressChart();
    const learningObjectChart = this.learningObjectProgressChart();
    const subjectStatsTable = this.subjectStatsTable();
    const studentsStatsTable = this.studentsStatsTable();

    return (
      <div>
        {learningObjectChart}
        {domainChart}
        {subjectStatsTable}
        {studentsStatsTable}
      </div>)
  }
}



function getLearningObjectiveStats(summary) {
  let data = {
    labels: [...summary.learningObjectives.map(i => i.learningObjective)],
    datasets: [
      {
        data: [...summary.learningObjectives.map(i => i.progress)],
        backgroundColor: [
          'rgba(255, 99, 132, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(153, 102, 255, 0.2)',
          'rgba(255, 159, 64, 0.2)',
        ],
        borderColor: [
          'rgba(255, 99, 132, 1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)',
          'rgba(255, 159, 64, 1)',
        ],
        borderWidth: 1,
      },
    ],
  };
  const options = {
    indexAxis: 'y',
    elements: {
      bar: {
        borderWidth: 1,
      },
    },
    responsive: true,
    plugins: {
      legend: {
        position: 'right',
      },
      title: {
        display: true,
        text: 'Progress By Learning Objective',
      },
    },
  };

  return { data, options }
}

function getDomainStats(summary) {
  let data = {
    labels: [...summary.domains.map(i => i.domainName)],
    datasets: [
      {
        data: [...summary.domains.map(i => i.progress)],
        backgroundColor: [
          'rgba(255, 99, 132, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(153, 102, 255, 0.2)',
          'rgba(255, 159, 64, 0.2)',
        ],
        borderColor: [
          'rgba(255, 99, 132, 1)',
          'rgba(54, 162, 235, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(153, 102, 255, 1)',
          'rgba(255, 159, 64, 1)',
        ],
        borderWidth: 1,
      },
    ],
  };
  const options = {
    indexAxis: 'y',
    elements: {
      bar: {
        borderWidth: 1,
      },
    },
    responsive: true,
    plugins: {
      legend: {
        position: 'right',
      },
      title: {
        display: true,
        text: 'Progress By Domain',
      },
    },
  };

  return { data, options }

}
