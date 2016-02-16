var gulp = require('gulp');
var del = require('del');
var rename = require("gulp-rename");
var postcss = require('gulp-postcss');
var autoprefixer = require('autoprefixer');
var mqpacker = require('css-mqpacker');
var csswring = require('csswring');
var runSequence = require('run-sequence');

gulp.task('clean', function() {
    return del(['dist','parsed']);
});

gulp.task('parse', function(){
    require('./node/parseData');
});

gulp.task('knockout', function(){
    return gulp.src('node_modules/knockout/build/output/knockout-latest.js')
        .pipe(rename('ko.js'))
        .pipe(gulp.dest('dist'))
    ;
});

gulp.task('html', function(){
    return gulp.src('src/html/index.html')
        .pipe(gulp.dest('dist'))
    ;
});

gulp.task('js', function(){
    return gulp.src('src/js/app.js')
        .pipe(gulp.dest('dist'))
    ;
});

gulp.task('css', function(){
    return gulp.src('src/css/styles.css')
        .pipe(postcss([
            autoprefixer({browsers: ['last 1 version', 'ie <= 9']}),
            mqpacker,
            csswring
        ]))
        .pipe(gulp.dest('dist'))
    ;
});

gulp.task('watch', function(){
    gulp.watch('src/js/*,js', ['js']);
    gulp.watch('src/html/*.html', ['html']);
    gulp.watch('src/css/*.css', ['css']);
});


gulp.task('default', function(){
    runSequence('clean', 'parse', ['knockout', 'html', 'css', 'js', 'watch']);
});
