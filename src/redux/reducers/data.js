import {compose, set, lensPath} from 'ramda';

import {persistentLens, temporaryLens} from './_lenses';
import {
  setFocusedUser,
  setByUserId,
  setByDomain,
} from '../actions/data';
import {handleActions, defaultTo} from '../../utils/state';

const dataLens = compose(persistentLens, lensPath(['data']));

export const byUserIdState = compose(
  dataLens,
  lensPath(['byUserId']),
  defaultTo([]),
);

export const byDomainState = compose(
  dataLens,
  lensPath(['byDomain']),
  defaultTo({}),
);

export const focusedUserState = compose(
  temporaryLens,
  lensPath(['focusedUser']),
  defaultTo({}),
);

export default handleActions({
  [setByUserId]: set(byUserIdState),
  [setByDomain]: set(byDomainState),
  [setFocusedUser]: set(focusedUserState),
});
