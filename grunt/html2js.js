module.exports = function (grunt, options) {
	return {
		build: {
			options: {
				base: 'source/app/',
				quoteChar: '\'',
				htmlmin: {
					collapseBooleanAttributes: true,
					collapseWhitespace: true,
					removeAttributeQuotes: true,
					removeComments: true,
					removeEmptyAttributes: true,
					removeRedundantAttributes: true,
					removeScriptTypeAttributes: true,
					removeStyleLinkTypeAttributes: true
				}
			},
			src: options.src.templates,
			dest: options.dist.dir + '/js/templates.js'
		}
	};
};
