import express, {static as serve} from 'express';
import dotenv from 'dotenv';
import http from 'http';
import {join} from 'path';
import betterConsole from 'better-logging';

import routes from './routes';
import repositories from './repositories';

dotenv.config({path: join(__dirname, '../../.env')});
betterConsole(console);

console.info('Starting api, please wait!');

const port = process.env.PORT || 4000;
const app = express();
const server = http.createServer(app);

app.use((req, _, next) => {
  req.repositories = repositories;
  next();
});

app.use(serve(join(__dirname, '../../dist')));

app.use('/api', routes(express));

app.get('*', (req, res) => {
  res.sendFile(join(__dirname, '../../dist/index.html'));
});

server.listen(port, '0.0.0.0');

process.on('SIGTERM', () => {
  console.info('SIGTERM signal received.');
  server.close(() => {
    console.log('Http server closed.');
    process.exit(0);
  });
});

console.info(`Api is running at http://0.0.0.0:${port}`);
