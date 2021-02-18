import db from '../db';
import {CollectionName} from '../../model/exercise-result';

const getAll = async ({limit = 100, skip = 100}) => {
  const {database} = await db();
  const collection = database.collection(CollectionName);
  const total = await collection.countDocuments({});

  const exercises = await collection
  .find({})
  .sort({SubmitDateTime: -1})
  .limit(limit)
  .skip(skip);

  const results = [];

  await exercises.forEach(doc => {
    results.push(doc);
  });

  return {results, total};
};

export default {
  getAll
};
