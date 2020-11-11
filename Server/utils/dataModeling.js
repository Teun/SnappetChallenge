const {groupBy} = require('ramda');

const groupByUserId = entries => groupBy(x => x.UserId, entries);

const getDomainResults = entries => entries.reduce((acc, cur) =>
  !acc[cur.Domain] ?
    {
      [cur.Domain]: {
        aantal: 1,
        progressie: cur.Progress
      },
      ...acc
    } :
    {
      [cur.Domain]: {
        aantal: acc[cur.Domain].aantal += 1,
        progressie: acc[cur.Domain].progressie += cur.Progress,
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
