import express from 'express';
import cors from 'cors';
import config from './lib/config.js';
import System from './lib/system.js';
import { log } from './lib/utils.js';

const app = express();
const system = new System(config);

app.use(cors());

system.ready.subscribe(state => {
    if (state) {
        app.get('/', (request, response) => {
            const sql = system.buildSqlString(request.query);
            if (!sql) {
                system.raiseError(response);
            } else {
                system.query(sql)
                    .then(results => {
                        response.json(results);
                    });
            }
        });
        app.get('/activity', (request, response) => {
            const sql = system.buildSqlString(
                request.query,
                'UserId, COUNT(1) as ActivityCount',
                'GROUP BY UserId',
                true);
            if (!sql) {
                system.raiseError(response);
            } else {
                system.query(sql)
                    .then(results => {
                        response.json(results);
                    });
            }
        });
        app.get('/exercises', (request, response) => {
            const sql = system.buildSqlString(
                request.query,
                'ExerciseId',
                `GROUP BY ExerciseId`,
                true);
            system.query(sql)
                .then(results => {
                    const items = [];
                    results.forEach(r => items.push(r.ExerciseId));
                    const q = system.buildSqlString(request.query, '*', ` AND ExerciseId IN(${items.join(',')})`);
                    system.alasql.promise(q, [system.data, items]).then(data => {
                        response.json(data);
                    });
                });
        });
        app.get('/progress', (request, response) => {
            if (typeof request.query.UserId === 'undefined' || !request.query.UserId) {
                system.raiseError(response, 'UserId is required');
                return;
            }
            const sql = system.buildSqlString(request.query, '*', ' ORDER BY SubmitDateTime DESC');
            if (!sql) {
                system.raiseError(response);
            } else {
                system.query(sql)
                    .then(results => {
                        response.json(results);
                    });
            }
        });
        app.get('/users', (request, response) => {
            const sql = system.buildSqlString(
                request.query,
                'UserId',
                'GROUP BY UserId',
                true);
            if (!sql) {
                system.raiseError(response);
            } else {
                system.query(sql)
                    .then(results => {
                        response.json(results);
                    });
            }
        });
        /*
        app.get('/subjects', (request, response) => {
            const sql = system.buildSqlString(
                request.query,
                'Subject',
                'GROUP BY Subject',
                true);
            if (!sql) {
                system.raiseError(response);
            } else {
                system.query(sql)
                    .then(results => {
                        response.json(results);
                    });
            }
        });
        app.get('/correct', (request, response) => {
            const sql = system.buildSqlString(
                {},
                'Correct, AnswerId, COUNT(1)',
                `GROUP BY Correct`,
                true);
            if (!sql) {
                system.raiseError(response);
            } else {
                system.query(sql)
                    .then(results => {
                        response.json(results);
                    });
            }
        });
        */

        app.listen(config.port, () => {
            config.debug && log('I\'m all ears', `http://localhost:${config.port}`);
        });

        // if (config.debug) {
        //     (function cli() {
        //         const rl = readline.createInterface({
        //             input: process.stdin,
        //             output: process.stdout,
        //         });
        //         rl.question('query: ', (query) => {
        //             system.query(query).then(results => {
        //                 console.log(results);
        //                 rl.close;
        //                 cli();
        //             });
        //         });
        //     })();
        // }
    }
});
