module.exports = function (grunt, options) {
    return {
        build: [options.dist.dir, options.temp.dir],
        all: [options.dist.dir, options.temp.dir]
    };
};
