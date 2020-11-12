const {groupBy} = require('ramda');

const groupByUserId = entries => groupBy(x => x.UserId, entries);

const getDomainResults = entries => entries.reduce((acc, cur) =>
  !acc[cur.Domain] ?
    {
      [cur.Domain]: {
        amount: 1,
        progression: cur.Progress
      },
      ...acc
    } :
    {
      [cur.Domain]: {
        amount: acc[cur.Domain].amount += 1,
        progression: acc[cur.Domain].progression += cur.Progress,
      },
      ...acc
    }
, {});

const groupByUserIdAndDomain = entries =>
  Object.entries(groupByUserId(entries)).map(([UserId, entries]) => {
    return ({
      UserId,
      DomainResults: getDomainResults(entries)
    });
  });

module.exports = {
  groupByUserIdAndDomain,
  getDomainResults
};
