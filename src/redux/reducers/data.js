import {compose, set, lensPath} from 'ramda';

import {
  setRawData,
  setIsLoading,
  setByUserId,
  setByDomain,
} from '../actions/data';
import {handleActions, defaultTo} from '../../utils/state';

const baseLens = lensPath(['root']);

export const rawDataState = compose(
  baseLens,
  lensPath(['rawData']),
  defaultTo([]),
);

export const isLoadingState = compose(
  baseLens,
  lensPath(['isLoading']),
  defaultTo(false),
);

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
  [setRawData]: set(rawDataState),
  [setIsLoading]: set(isLoadingState),
  [setByUserId]: set(byUserIdState),
  [setByDomain]: set(byDomainState),
});
