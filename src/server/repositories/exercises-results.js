import {ZonedDateTime, convert} from 'js-joda';

import db from '../db';
import {CollectionName} from '../../model/exercise-result';

const getAll = async ({
  from,
  to,
}) => {
  const startDate = ZonedDateTime.parse(new Date(from).toISOString());
  const endDate = ZonedDateTime.parse(new Date(to).toISOString());

  const query = {
    submitDateTime: {
      $gte: convert(startDate).toDate(),
      $lt: convert(endDate).toDate(),
    }
  };

  const {database} = await db();
  const collection = database.collection(CollectionName);

  const exercises = await collection
  .find(query)
  .sort({submitDateTime: 1});

  const results = [];

  await exercises.forEach(doc => {
    results.push(doc);
  });

  return {results, total: results.length};
};

export default {
  getAll
};
