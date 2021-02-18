import healthcheck from '../healthcheck';
import db from '../../db';

jest.mock('../../db', () => jest.fn().mockImplementation(() => ({
  client: {
    close: jest.fn()
  },
  database: {
    command: jest.fn()
  }
})));

global.console = {
  error: jest.fn(),
};

describe('repositories', () => {
  describe('healthcheck', () => {
    beforeEach(() => {
      jest.resetModules();
      process.env = {};
    });

    describe('check', () => {
      test('should return OK when env vars and the database connection are correct', async () => {
        process.env.MONGODB_URI = 'fakeuri';
        const [status, result] = await healthcheck.getAll();
        expect(status).toBe(200);
        expect(result.ENVIRONMENT_VARIABLES).toBe('OK');
        expect(result.DATABASE).toBe('OK');
      });

      test('should return ERROR when env vars are not set', async () => {
        process.env.MONGODB_URI = undefined;
        const [status, result] = await healthcheck.getAll();

        expect(status).toBe(503);
        expect(result.ENVIRONMENT_VARIABLES).toBe('ERROR');
        expect(result.DATABASE).toBe('OK');
      });

      test('should return ERROR when database is not reachable', async () => {
        db.mockImplementation(() => ({
          client: {
            close: jest.fn()
          },
        }));

        process.env.MONGODB_URI = 'fakeuri';
        const [status, result] = await healthcheck.getAll();

        expect(status).toBe(503);
        expect(result.ENVIRONMENT_VARIABLES).toBe('OK');
        expect(result.DATABASE).toBe('ERROR');
      });
    });
  });
});
