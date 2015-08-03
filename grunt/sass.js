module.exports = function (grunt, options) {
	var endFiles = {};

	grunt.file.expand(options.src.sass + "/*.scss").forEach(function (dir) {
		// Replace "src/sass/index.scss" to ".tmp/css/index.css" and map it to the SASS compiler
		endFiles[dir.replace(".scss", ".css").replace(options.src.sass, options.dist.dir + "/css")] = dir;
	});

	return {
		sass: {
			options: {
				sourceMap: true
			},
			files: endFiles
		}
	};
};
