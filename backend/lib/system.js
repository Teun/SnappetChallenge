import alasql from 'alasql';
import * as fs from 'fs/promises';
import pkg from 'rxjs';

import fieldTypes from './field-types.js';
import { isEmpty, isNumeric, log } from './utils.js';

// import config from './config.js';

const { BehaviorSubject } = pkg;

export default class System {

    alasql = alasql;

    constructor(config) {
        this.debug = config.debug;
        this.data = [];
        this.ready = new BehaviorSubject(false);
        this.debug && log('Read data file: ', config.filename);
        this.readFile(config.filename)
            .then(json => {
                this.data = JSON.parse(json);

                // console.log(alasql('SELECT UserId, COUNT(1) FROM ? GROUP BY UserId', [this.data]));

                this.debug && log('System ready, starting app', '');
                this.ready.next(true);
            });
    }

    async readFile(filename) {
        return await fs.readFile(filename, 'utf-8');
    }

    buildSqlString(params, cols = '*', postfix = '', skipValidation = false) {
        if (!skipValidation && !this.validateQuery(params)) {
            return null;
        }
        const sql = `SELECT ${cols} FROM ? ` + (skipValidation && isEmpty(params, this.debug) ? '' : 'WHERE ');
        const where = [];
        for (const key in params) {
            const value = isNumeric(params[key]) ? params[key] : `"${params[key]}"`;
            if (key === 'startdate') {
                where.push(`SubmitDateTime >= ${value}`);
            } else if (key === 'enddate') {
                where.push(`SubmitDateTime <= ${value}`);
            } else if (params[key][0] === '%' || params[key].slice(-1) === '%') {
                where.push(`${key} LIKE ${value}`);
            } else {
                where.push(`${key} = ${value}`);
            }
        }
        return sql + where.join(' AND ') + ` ${postfix}`;
    }


    validateQuery(params) {
        if (isEmpty(params, this.debug)) {
            return false;
        }
        for (const key in params) {
            if (fieldTypes[key] === 'number') {
                if (!isNumeric(params[key])) {
                    this.debug && log('Validating request params failed - field should be numeric ', key);
                    return false;
                }
            }
            // TODO: many more validations
        }
        return true;
    }

    query(query) {
        this.debug && log('Executing query: ', query);
        // const dataSource = Array((query.match(new RegExp(/\?/, 'g')) || []).length).fill(this.data);
        return alasql.promise(query, [this.data]);
    }

    raiseError(response, message = null) {
        const msg = message ? message : `Please check request parameters`;
        this.debug && log('ERROR 500', msg);
        response.status(500).json({ error: msg });
    }

}
