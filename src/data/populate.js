import {MongoClient} from 'mongodb';
import betterConsole from 'better-logging';
import dotenv from 'dotenv';
import {outputJSON} from 'fs-extra';
import {join} from 'path';

import work from './work.json';
import ExerciseResult, {CollectionName} from '../model/exercise-result';

dotenv.config();
betterConsole(console);

const uri = process.env.MONGODB_URI;

if (!uri) {
  throw new Error('MONGODB_URI not defined.');
}

const dbClient = new MongoClient(uri, {useUnifiedTopology: true});

const loadData = async () => {
  const successData = [];
  const errorData = [];
  for (let i = 0; i < work.length; i++) {
    try {
      const exercise = ExerciseResult(work[i]);
      successData.push(exercise);
    } catch (error) {
      errorData.push(work[i]);
    }
  }

  if (errorData.length) {
    const errorFile = join(__dirname, 'work.failed.json');
    await outputJSON(errorFile, errorData, {flag: 'w'});

    console.warn(`Error trying to load ${errorData.length} exercise(s) from file.`);
    console.warn(`For details check: ${errorFile}`);
  }

  return successData;
};

const run = async () => {
  try {
    await dbClient.connect();

    const database = dbClient.db('snappet');
    await database.command({ping: 1});
    console.info('Connected to database');

    const collection = database.collection(CollectionName);
    await collection.deleteMany({});
    console.info('Collection cleaned');

    const options = {ordered: true};
    const docs = await loadData();

    console.info(`Migrating documents, please wait...`);
    const result = await collection.insertMany(docs, {options});

    await collection.createIndex({SubmitDateTime: 1});

    console.info(`${result.insertedCount} documents were inserted`);
  } catch (error) {
    console.error(error.message);
  } finally {
    await dbClient.close();
  }
};

run();
