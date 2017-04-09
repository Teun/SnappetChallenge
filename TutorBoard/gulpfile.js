var gulp = require('gulp');
var sass = require('gulp-sass');

var webpack = require('webpack');

var config = require('./webpack.config.js');

gulp.task('styles', function () {
    gulp.src('Client/styles/**/*.scss')
        .pipe(sass({
            sourcemap: true,
            outputStyle: 'compressed',
            includePaths: ['node_modules/susy/sass']
        }).on('error', sass.logError))
        .pipe(gulp.dest('./Content/'));
});
gulp.task("typescript", function (done) {
    webpack(config).run(done);
});

gulp.task('default', function () {
    gulp.watch('Client/styles/**/*.scss', ['styles']);
    gulp.watch('Client/app/**/*.ts', ['typescript']);
});