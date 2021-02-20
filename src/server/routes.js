/**
 * Ideally all errors should be handled to some place where we can track it
 * For example using Sentry, Rollbar, LogRocket, etc...
 * But for the purpose of this challenge, I'm returning it in the response
 */

export default express => {
  const router = express.Router();

  router.get('/healthcheck', async ({repositories}, res) => {
    try {
      const [status, response] = await repositories.healthcheck.getAll();
      return res.status(status).send(response);
    } catch (error) {
      return res.status(500).send(error);
    }
  });

  router.get('/exercises-results', async ({query, repositories}, res) => {
    const from = query.from;
    const to = query.to;

    try {
      const data = await repositories.exercisesResults.getAll({from, to});
      return res.status(200).send({...data, from, to});
    } catch (error) {
      return res.status(500).send(error);
    }
  });

  return router;
};
