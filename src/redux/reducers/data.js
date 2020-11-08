import {compose, set, lensPath} from 'ramda';

import {
  setByUserId,
  setByDomain,
} from '../actions/data';
import {handleActions, defaultTo} from '../../utils/state';

const baseLens = lensPath(['root']);

export const byUserIdState = compose(
  baseLens,
  lensPath(['byUserId']),
  defaultTo({}),
);

export const byDomainState = compose(
  baseLens,
  lensPath(['byDomain']),
  defaultTo({}),
);

export default handleActions({
  [setByUserId]: set(byUserIdState),
  [setByDomain]: set(byDomainState),
});
