angular.module('snappet').filter('moment', function() {
	moment.lang('en', {
		relativeTime: {
			future: "in %s",
			past:   "%s",
			s:  "now",
			m:  "a minute ago",
			mm: "%d minutes ago",
			h:  "an hour ago",
			hh: "%d hours ago",
			d:  "a day ago",
			dd: "%d days ago",
			M:  "a month ago",
			MM: "%d months ago",
			y:  "a year ago",
			yy: "%d years ago"
		}
	});

	return function(value, method, argument) {
		if(!isNaN(value)){
			value = parseInt(value);
		}
		return moment(value)[method](argument);
	};
});