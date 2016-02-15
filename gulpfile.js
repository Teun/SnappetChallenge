var gulp = require('gulp');
var del = require('del');
var rename = require("gulp-rename");

gulp.task('clean', function() {
  // You can use multiple globbing patterns as you would with `gulp.src`
  return del(['dist','parsed']);
});

// run the parse first to get all the data mangled
gulp.task('parse', ['clean'], function(){
    require('./node/parseData');
});

gulp.task('knockout', function(){
    return gulp.src('node_modules/knockout/build/output/knockout-latest.js')
        .pipe(rename('ko.js'))
        .pipe(gulp.dest('dist'))
    ;
});

gulp.task('default', ['parse', 'knockout']);
