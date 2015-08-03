module.exports = function (grunt, options) {
    return {
        templates: {
            options: {
                patterns: [
                    {
                        match: /<!-- inject:templates -->([^]+)<!-- endinject -->/,
                        replacement: '<script src="js/templates.js"></script>'
                    }
                ]
            },
            files: [
                {
                    expand: true,
                    flatten: true,
                    src: ['dist/index.html'],
                    dest: 'dist/'
                }
            ]
        }
    };
};
