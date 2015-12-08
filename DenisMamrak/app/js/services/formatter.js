angular.module('snappet').service('Formatter', function(){
	_this = this;

	_this.tick = function(points){
		var range = points[points.length - 1] - points[0];

		var months  = Math.floor(range / (1000 * 60 * 60 * 24 * 30));
		var weeks   = Math.floor(range / (1000 * 60 * 60 * 24 * 7));
		var days    = Math.floor(range / (1000 * 60 * 60 * 24));
		var hours   = Math.floor(range / (1000 * 60 * 60));
		var minutes = Math.floor(range / (1000 * 60));
		
		var result = '%M:%S';
		if(minutes){
			result = '%H:%M';
		}				
		if(hours){
			result = '%H:%M';
		}
		if(days){
			result = '%b/%d';
		}
		if(weeks){
			result = '%b/%d';
		}
		if(months){
			result = '%b/%d/%y';
		}
		return result;
	}
	
	_this.tooltip = function(points){
		var range = points[points.length - 1] - points[0];

		var months  = Math.floor(range / (1000 * 60 * 60 * 24 * 30));
		var weeks   = Math.floor(range / (1000 * 60 * 60 * 24 * 7));
		var days    = Math.floor(range / (1000 * 60 * 60 * 24));
		var hours   = Math.floor(range / (1000 * 60 * 60));
		var minutes = Math.floor(range / (1000 * 60));
		
		var result = 'mm:ss';
		if(minutes){
			result = 'HH:mm';
		}				
		if(hours){
			result = 'HH:mm';
		}
		if(days){
			result = 'MMM/DD';
		}
		if(weeks){
			result = 'MMM/DD';
		}
		if(months){
			result = 'MMM/DD/YY';
		}
		return result;
	}

});