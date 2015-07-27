/// <binding BeforeBuild='build, inject' Clean='clean' ProjectOpened='watchers' />

var gulp = require('gulp'),
    util = require('gulp-util'),
    print = require('gulp-print'),
    inject = require('gulp-inject'),
    del = require('del'),
    jshint = require('jshint'),
    watch = require('gulp-watch'),
    cssmin = require('gulp-cssmin')
    uglify = require('gulp-uglify'),
    wiredep = require('wiredep').stream,
    bowerJson = require('./bower.json'),
    project = require('./project.json');

var paths = {
    webroot: './' + project.webroot + '/',
    layoutPage: './Views/Shared/_Layout.cshtml',
    layoutPagePath: './Views/Shared/',
    jsContent: './Scripts/**/*.js',
    cssContent: './Content/css/**/*.css'
};

paths.lib = paths.webroot + 'lib/';
paths.jsDest = paths.webroot + 'js/';
paths.cssDest = paths.webroot + 'css/';
paths.js = paths.webroot + 'js/**/*.js';
paths.css = paths.webroot + 'css/**/*.css';

gulp.task('build:js', function() {
    log('Copying js to ' + paths.jsDest + '...');
    return gulp
        .src(paths.jsContent)
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task('build:ccs', function() {
    log('Copying css to ' + paths.cssDest + '...');
    return gulp
        .src(paths.cssContent)
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task('build', ['build:js', 'build:ccs']);

gulp.task('watcher:js', function() {
    log('Watching js in ' + paths.jsContent);
    return gulp.src(paths.jsContent)
        .pipe(watch(paths.jsContent))
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task('watcher:css', function() {
    log('Watching css in ' + paths.cssContent);
    return gulp.src(paths.cssContent)
        .pipe(watch(paths.cssContent))
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task('watchers', ['watcher:js', 'watcher:css']);

gulp.task('min:js', function() {
    log('Building and uglifying js...');
    return gulp
        .src(paths.jsContent)
        .pipe(uglify())
        .pipe(gulp.dest(paths.jsDest));
});

gulp.task('min:css', function() {
    log('Building and minifying css...');
    return gulp
        .src(paths.cssContent)
        .pipe(cssmin())
        .pipe(gulp.dest(paths.cssDest));
});

gulp.task('min', ['min:js', 'min:css']);

gulp.task('clean:js', function(cb) {
    del(paths.jsDest, cb);
});

gulp.task('clean:css', function(cb) {
    del(paths.cssDest, cb);
});

gulp.task('clean', ['clean:js', 'clean:css']);

gulp.task('wiredep', function() {
    log('Placing Bower components in ' + paths.layoutPage);
    return gulp
        .src(paths.layoutPage)
        .pipe(wiredep({
            bowerJson: bowerJson,
            directory: paths.lib,
            devDependencies: true,
            ignorePath: '../../' + project.webroot
        }))
        .pipe(gulp.dest(paths.layoutPagePath));
});

gulp.task('inject', ['wiredep'], function() {
    log('Wire up the css and js into ' + paths.layoutPage);
    return gulp
        .src(paths.layoutPage)
        .pipe(inject(gulp.src([paths.js, paths.css], { read: false }), { ignorePath: project.webroot }))
        .pipe(gulp.dest(paths.layoutPagePath));
});

/////////////

function log(msg) {
    if (typeof (msg) === 'object') {
        for (var item in msg) {
            if (msg.hasOwnProperty(item)) {
                util.log(util.colors.blue(msg[item]));
            }
        }
    } else {
        util.log(util.colors.blue(msg));
    }
};