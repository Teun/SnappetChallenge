import {MongoClient} from 'mongodb';

let database = null;
let client = null;

const initiate = async () => {
  const uri = process.env.MONGODB_URI;
  client = new MongoClient(uri, {useUnifiedTopology: true});

  try {
    await client.connect();

    database = client.db('snappet');
    return database;
  } catch (error) {
    client.close();
    throw new Error(error.message);
  }
};

export default async () => {
  if (!database) {
    await initiate();
  }
  return {database, client};
};
