module.exports = function (grunt, options) {
    return {
        options: {
            encoding: 'utf8',
            algorithm: 'md5',
            length: 20
        },
        js: {
            src: [
                options.dist.dir + '/js/app.js',
                options.dist.dir + '/js/vendor.js',
                options.dist.dir + '/js/templates.js'
            ]
        },
        css: {
            src: [
                options.dist.dir + '/css/all.css'
            ]
        }
    };
};
