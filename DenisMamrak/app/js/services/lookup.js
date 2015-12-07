angular.module('snappet').filter('lookup', function(){
	var map = {
		'SubmittedAnswerId': 'Answer',
		'SubmitDateTime':    'Time',
		'Correct':           'Correct',
		'Progress':          'Progress',
		'UserId':            'User',
		'ExerciseId':        'Exercise',
		'Difficulty':        'Difficulty',
		'Subject':           'Subject',
		'Domain':            'Domain',
		'LearningObjective': 'Learning Objective'		
	};

	return function(input){
		if(input){
			var result = map[input] || input;
			return result;
		}
	}
});