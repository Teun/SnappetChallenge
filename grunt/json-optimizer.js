// This is a quick and dirty method to make a lot of multiple strings combine into separate files
// We also going to add random names for fun :)
module.exports = function (grunt, options) {

	grunt.registerTask('seperateJSON', 'Transform JSON data to two seperate files.', function(arg1, arg2) {

		var files = {
			input: "./source/json/data.json",
			output: {
				folder: "./dist/json/",
				format: "json"
			}
		};
		var id = 1;
		var checkAndCreateId = function(array, string) {
			if( array[string] === undefined || array[string] === null ) { 	// Check if string has already an id
				array[string] = id;											//store string with an unique id
				id++;
			}
			return array;
		};
		var mergeValues = function(arr1, arr2, arr3) {
			var tmp = {};
			for (var key in arr1) {
				if (arr1.hasOwnProperty(key)) {
					tmp[arr1[key]] = key;
				}
			}
			for (var key in arr2) {
				if (arr2.hasOwnProperty(key)) {
					tmp[arr2[key]] = key;
				}
			}
			for (var key in arr3) {
				if (arr3.hasOwnProperty(key)) {
					tmp[arr3[key]] = key;
				}
			}
			return tmp;
		};

		var sourceFile = grunt.file.readJSON(files.input),
			_Subject = {}, _Domain = {}, _LearningObjective = {}, newOutput = [];

		for (var i = 0, len = sourceFile.length; i < len; i++) {
			_Subject = checkAndCreateId( _Subject, sourceFile[i].Subject );
			_Domain = checkAndCreateId( _Domain, sourceFile[i].Domain );
			_LearningObjective = checkAndCreateId( _LearningObjective, sourceFile[i].LearningObjective );

			newOutput[i] = sourceFile[i]; //store ordinal JSON into new object
			newOutput[i].Subject = _Subject[sourceFile[i].Subject];
			newOutput[i].Domain = _Domain[sourceFile[i].Domain];
			newOutput[i].LearningObjective = _LearningObjective[sourceFile[i].LearningObjective];
			// newOutput[i].SubmitDateTime = Date.parse(newOutput[i].SubmitDateTime);

		}

		var wasWrittenData = grunt.file.write(files.output.folder + "data." + files.output.format, JSON.stringify(newOutput, null, 2));
		if (wasWrittenData) {
			grunt.log.ok('Data output successful written!');
		} else {
			grunt.log.error('Unable to write data contents to file!');
		}

		var wasWrittenText = grunt.file.write(files.output.folder + "translations." + files.output.format, JSON.stringify(mergeValues(_Subject, _Domain, _LearningObjective), null, 2));
		if (wasWrittenText) {
			grunt.log.ok('Translations output successful written!');
		} else {
			grunt.log.error('Unable to write text contents to file!');
		}

	});

};
