import {compose, set, lensPath} from 'ramda';

import {persistentLens, temporaryLens} from './_lenses';
import {
  setFocusedUser,
  setByUserId,
  setByDomain,
} from '../actions/data';
import {handleActions, defaultTo} from '../../utils/state';

export const byUserIdState = compose(
  persistentLens,
  lensPath(['byUserId']),
  defaultTo([]),
);

export const byDomainState = compose(
  persistentLens,
  lensPath(['byDomain']),
  defaultTo({}),
);

export const focusedUserState = compose(
  temporaryLens,
  lensPath(['byDomain']),
  defaultTo({}),
);

export default handleActions({
  [setByUserId]: set(byUserIdState),
  [setByDomain]: set(byDomainState),
  [setFocusedUser]: set(focusedUserState),
});
