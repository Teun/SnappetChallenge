var gulp = require('gulp');
var del = require('del');
var rename = require("gulp-rename");
var postcss = require('gulp-postcss');
var autoprefixer = require('autoprefixer');
var mqpacker = require('css-mqpacker');
var csswring = require('csswring');

gulp.task('clean', function() {
  // You can use multiple globbing patterns as you would with `gulp.src`
  return del(['dist','parsed']);
});

// run the parse first to get all the data mangled
gulp.task('parse', ['clean'], function(){
    require('./node/parseData');
});

gulp.task('knockout',['clean'], function(){
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
    // gulp.watch(img, ['img']);
});


gulp.task('default', ['parse', 'knockout', 'html', 'css', 'js', 'watch']);
