var gulp = require('gulp');
var del = require('del');

gulp.task('clean', function() {
  // You can use multiple globbing patterns as you would with `gulp.src`
  return del(['dist','parsed']);
});

// run the parse first to get all the data mangled
gulp.task('parse', ['clean'], function(){
    require('./node/parseData');
});


gulp.task('default', ['parse']);
