module.exports = function (grunt, options) {

    return {
        fonts: {
            files: [{
                src: [options.src.vendors + '/bootstrap-sass-official/assets/fonts/bootstrap/*.{eot,svg,ttf,woff,woff2,otf}'],
                dest: options.dist.dir + '/' + options.dist.fontDir + '/',
                flatten: true,
                expand: true
            }]
        },
        build: {
            files: [{
                src: [options.src.html],
                dest: options.dist.dir + '/' + options.dist.html,
                filter: 'isFile'
            }]
        }
    };
};
