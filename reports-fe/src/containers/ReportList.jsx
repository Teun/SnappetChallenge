import React from 'react';
import PropTypes from 'prop-types';

const ReportList = (props) => {
  const { results } = props;
  return (
    <table className="table">
      <thead>
        <tr>
          <th scope="col">Subject</th>
          <th scope="col">Correct answers</th>
          <th scope="col">Progress</th>
        </tr>
      </thead>
      <tbody>
        {results.map(res =>
              (
                <tr key={res.subject}>
                  <td>{res.subject}</td><td>{res.correctAnswers}</td><td>{res.sumProgress}</td>
                </tr>))}
      </tbody>
    </table>
  );
};

ReportList.propTypes = {
  results: PropTypes.arrayOf(PropTypes.shape({
    subject: PropTypes.string.isRequired,
    correctAnswers: PropTypes.number.isRequired,
    sumProgress: PropTypes.number.isRequired,
  }).isRequired).isRequired,
};

export default ReportList;
