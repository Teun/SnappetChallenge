/// <binding BeforeBuild='default' />

var gulp = require('gulp');
var del = require('del');
var sass = require('gulp-sass');
var watch = watch = require('gulp-watch');
var batch = require('gulp-batch');
//var concat = require('gulp-concat');
//var uglify = require('gulp-uglify');

var paths = {
    bower: './bower_components/',
    app: './app/',
    target: './wwwroot/'
};

// Delete the wwwroot directory
gulp.task('clean', function () {
    return del(paths.target + "/");
});

gulp.task('copy', ['clean'], function () {
    //Vendors:
    gulp.src(paths.bower + 'angular/angular.js').pipe(gulp.dest(paths.target + 'vendors/angular'));
    gulp.src(paths.bower + 'angular-animate/angular-animate.min.js').pipe(gulp.dest(paths.target + 'vendors/angular-animate'));
    gulp.src(paths.bower + 'angular-route/angular-route.min.js').pipe(gulp.dest(paths.target + 'vendors/angular-route'));
    gulp.src(paths.bower + 'angular-sanitize/angular-sanitize.min.js').pipe(gulp.dest(paths.target + 'vendors/angular-sanitize'));
    gulp.src(paths.bower + 'angular-ui-router/release/angular-ui-router.min.js').pipe(gulp.dest(paths.target + 'vendors/angular-ui-router'));
    gulp.src(paths.bower + 'angular-strap/dist/angular-strap.*.js').pipe(gulp.dest(paths.target + 'vendors/angular-strap'));

    gulp.src(paths.bower + 'bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,eot}').pipe(gulp.dest(paths.target + 'vendors/bootstrap'));
    gulp.src(paths.bower + 'font-awesome/{css,fonts}/*.{css,otf,eot,svg,ttf,woff,woff2}').pipe(gulp.dest(paths.target + 'vendors/font-awesome'));
    gulp.src(paths.bower + 'jquery/dist/jquery.min.js').pipe(gulp.dest(paths.target + 'vendors/jquery'));

    //Pages:
    gulp.src('./app/**/*.{html,js}')
        .pipe(gulp.dest(paths.target + 'app'));
    gulp.src('./app/index.html')
        .pipe(gulp.dest(paths.target));
});

//Read main.scss and create main.css. 
//main.scss should reference all needed .scss files.
gulp.task('sass', ['copy'], function () {
    console.log("Generating main.css from .scss files.");

    gulp.src('./app/main.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(paths.target + 'app'));
});

//Watch for .scss changes, run sass task on changes.
gulp.task('sass:watch', ['clean'], function () {
    gulp.watch('./app/**/*.scss', ['sass']);
});

//Watch for normal js and html file changes, run copy task on changes.
gulp.task('watch', ['clean'], function () {
    var watchers = [
        './{app,directives}/**/*.{html,js}',
        './index.html'];

    gulp.watch(watchers, ['copy', 'sass']);
});

gulp.task('dev', ['clean', 'copy', 'sass', 'watch', 'sass:watch']);

//When executing gulp from command line, these scripts are executed by default.
gulp.task('default', ['clean', 'copy', 'sass']);