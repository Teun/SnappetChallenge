import {lensProp, compose} from 'ramda';

export const baseLens = lensProp('root');

export const temporaryLens = compose(baseLens, lensProp('temp'));
export const persistentLens = compose(baseLens, lensProp('persistent'));
