import express, {static as serve} from 'express';
import dotenv from 'dotenv';
import http from 'http';
import {join} from 'path';
import betterConsole from 'better-logging';

import routes from './routes';
import repositories from './repositories';

dotenv.config({path: join(__dirname, '../../.env')});
betterConsole(console);

console.info('Starting server, please wait!');

const port = process.env.PORT || 4000;
const app = express();
const server = http.createServer(app);

app.use((req, _, next) => {
  req.repositories = repositories;
  next();
});

app.use('/api', routes(express));

app.use('/', serve(join(__dirname, '../../dist')));
app.use('*', serve(join(__dirname, '../../dist')));

server.listen(port, () => {
  console.info(`Server is running, look it at: http://0.0.0.0:${port}`);
});
