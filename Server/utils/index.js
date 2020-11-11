const {getTodaysData} = require('./db.js');
const {groupByUserIdAndDomain, getDomainResults} = require('./dataModeling.js');

module.exports = {
  getTodaysData,
  getDomainResults,
  groupByUserIdAndDomain,
};
