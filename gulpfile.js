var gulp = require('gulp');

gulp.task('js', function(){
	gulp.src([
		'bower_components/angular/angular.min.js',
		'bower_components/angular-sanitize/angular-sanitize.min.js',
		'bower_components/ui-select/dist/select.min.js',
		'bower_components/angular-ui-router/release/angular-ui-router.min.js',
		'bower_components/moment.min.js',
		'bower_components/angular-bootstrap-datetimepicker/src/js/datetimepicker.min.js'
	])
	.pipe(gulp.dest('Web/Content/js/libs/'));
});

gulp.task('css', function(){
	gulp.src([
		'bower_components/ui-select/dist/select.min.css',
		'bower_components/bootstrap/dist/css/bootstrap.min.css',
		'bower_components/angular-bootstrap-datetimepicker/src/css/datetimepicker.css'
	])
	.pipe(gulp.dest('Web/Content/css/libs/'));
});

gulp.task('default', ['js', 'css']);