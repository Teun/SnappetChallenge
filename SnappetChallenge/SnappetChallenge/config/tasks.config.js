'use strict';

const buildConfig = {
    wwwroot: 'wwwroot',
    dist: 'wwwroot/dist',
    testDir: 'tests/',
    tsConfig: 'wwwroot/tsconfig.json',
    tsFiles: '**/*.ts',
    allTsFiles: ['**/*.ts', '!**/node_modules/**/*', '!**/jspm_packages/**/*'],

    chokidarPort: 5776,
    chokidarIgnore: [/[\/\\]\./, 'node_modules/**', 'wwwroot/jspm_packages/**']

};

module.exports = buildConfig;
