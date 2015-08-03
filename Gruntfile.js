"use strict";

module.exports = function(grunt) {

    var path = require('path');

    require('load-grunt-config')(grunt, {
        // path to task.js files, defaults to grunt dir
        configPath: path.join(process.cwd(), 'grunt'),

        // auto grunt.initConfig
        init: true,

        // data passed into config.  Can use with <%= test %>
        data: {
            src: {
                dir: 'source/app/',
                js: ['source/app/**/*.js', 'source/app/*.js'],
                sass: 'source/sass',
                html: 'source/app/index.html',
                templates: ['source/app/**/*.html', '!source/app/index.html'],
                vendors: 'source/vendors'
            },

            eslint: {
                log: 'eslint.errors.log', //save the ESLint output of the pre-check to a file
                config: 'eslint.json'
            },

            dist: {
                dir: 'dist', //build folder
                fontDir: 'fonts',
                html: 'index.html',
            },

            temp: {
                dir: '.tmp', //temperary build folder
                docs: 'docs/js',
                concat: 'concat/js'
            }
        },

        // can optionally pass options to load-grunt-tasks.
        // If you set to false, it will disable auto loading tasks.
        loadGruntTasks: {
            pattern: 'grunt-*',
            config: require('./package.json'),
            scope: 'devDependencies'
        },

        //can post process config object before it gets passed to grunt
        postProcess: function(config) {},

        //allows to manipulate the config object before it gets merged with the data object
        preMerge: function(config, data) {}
    });

};
