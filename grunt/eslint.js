module.exports = function (grunt, options) {
    return {
        source: {
            options: {
                //format: 'compact',
                configFile: options.eslint.config,//'eslint.json',
                rules: {
                    //Disable use strict warnings on development codes, use-strict will be checked by generated subtask
                    "strict": 0
                }
                //outputFile: options.eslint.log//'eslint.errors.log'
            },
            src: options.src.js//['src/app/**/*.js', 'src/app/*.js']
        },
        generated: {
            options: {
                configFile: options.eslint.config
            },
            src: [options.temp.dir + '/' + options.temp.concat + '/app.js']
        }
    };
};
