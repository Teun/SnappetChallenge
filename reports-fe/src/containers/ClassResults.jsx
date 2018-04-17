import React, { Component } from 'react';
import DatePicker from 'react-datepicker';
import moment from 'moment';
import axios from 'axios';

import 'react-datepicker/dist/react-datepicker.css';

import ReportList from './ReportList';

class ClassResults extends Component {
  constructor(props) {
    super(props);
    this.state = {
      startDate: moment(),
      results: [],
    };
    this.handleChange = this.handleChange.bind(this);
    // eslint-disable-next-line
    this.apiUrl = document.querySelector('.js-main-app').dataset.reportApi
  }

  componentDidMount() {
    this.getReportData();
  }

  getReportData() {
    axios.get(`${this.apiUrl}?date=${moment(this.state.startDate).format('YYYY-MM-DD')}`)
      .then((response) => {
        this.setState({
          results: response.data.reportItems,
        });
      });
  }

  handleChange(date) {
    this.setState({
      startDate: date,
    });
    this.getReportData();
  }
  render() {
    return (
      <div>
        <DatePicker
          selected={this.state.startDate}
          onChange={this.handleChange}
        />
        <ReportList results={this.state.results} />
      </div>
    );
  }
}

export default ClassResults;
