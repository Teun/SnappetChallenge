module.exports = function (grunt, options) {

    return {
        options: {
            assetsDirs: [options.dist.dir]
        },
        html: options.dist.dir + '/index.html'
    };
};
