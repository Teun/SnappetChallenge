'use strict';

const gulp = require('gulp'),
    chokidar = require('chokidar-socket-emitter'),
    tasksConfig = require('../config/tasks.config.js');

gulp.task('background.chokidar', done => {
    chokidar({
        port: tasksConfig.chokidarPort,
        path: tasksConfig.tsFiles,
        chokidar: {
            ignored: tasksConfig.chokidarIgnore,
            cwd: tasksConfig.wwwroot
        }
    });
    done();
});