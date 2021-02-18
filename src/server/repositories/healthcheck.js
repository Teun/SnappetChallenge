import db from '../db';

const message = success => success ? 'OK' : 'ERROR';

const getAll = async () => {
  const {client, database} = await db();
  const uriSuccess = Boolean(process.env.MONGODB_URI);
  let databaseSuccess;
  try {
    await database.command({ping: 1});
    databaseSuccess = true;
  } catch (error) {
    databaseSuccess = false;
    console.error(error);
  } finally {
    await client.close();
  }

  const ENVIRONMENT_VARIABLES = message(uriSuccess);
  const DATABASE = message(databaseSuccess);
  const STATUS = databaseSuccess && uriSuccess ? 200 : 503;

  return [STATUS, {
    ENVIRONMENT_VARIABLES,
    DATABASE
  }];
};

export default {
  getAll
};
