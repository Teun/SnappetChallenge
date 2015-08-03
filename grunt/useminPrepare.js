module.exports = function (grunt, options) {
    return {
        options: {
            dest: options.dist.dir + '/',
            staging: options.temp.dir,
            flow: {
                steps: {
                    js: ['concat'],
                    css: ['concat']
                },
                post: {}
            }
        },
        html: options.src.html
    };
};
