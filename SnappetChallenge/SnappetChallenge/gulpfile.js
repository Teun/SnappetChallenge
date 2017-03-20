/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
require('./tasks/lint.js');
require('./tasks/chokidar.js');

gulp.task('background', ['background.chokidar', 'background.tslint']);