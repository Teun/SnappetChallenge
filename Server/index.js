const express = require('express');
const cors = require('cors');

const workJson = require('../Data/work.json');
const {
  groupByUserIdAndDomain,
  getTodaysData,
  getDomainResults
} = require('./utils');

const app = express();
const port = 9000;

const todaysData = getTodaysData(workJson);

app.use(cors());

app.get('/todaysResults', (req, res) => {
  res.send({
    classResultsPerDomain: getDomainResults(todaysData),
    userResultsPerDomain: groupByUserIdAndDomain(todaysData)
  });
});

app.listen(port, () => {
  console.log(`🦅 We have lift off! 🦅
Snappet server listening on http://localhost:${port}`);
});
