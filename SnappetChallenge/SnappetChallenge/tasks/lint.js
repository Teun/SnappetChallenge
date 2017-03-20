'use strict';

const gulp = require('gulp'),
    plumber = require('gulp-plumber'),
    tslint = require('gulp-tslint'),
    util = require('gulp-util'),
    tasksConfig = require('../config/tasks.config.js');

gulp.task('build.tslint', () => {
    gulp.src(tasksConfig.allTsFiles)
        .pipe(plumber())
        .pipe(tslint({
            formatter: 'msbuild'
        }))
        .pipe(tslint.report({
            emitError: false
        }))
});

gulp.task('background.tslint', () =>
    gulp.watch(tasksConfig.allTsFiles, function (event) {
        util.log('Executing TSLint for: ' + util.colors.blue(event.path));

        gulp.src(event.path)
            .pipe(tslint({
                formatter: 'prose'
            }))
            .pipe(tslint.report({
                emitError: false
            }));
    })
);