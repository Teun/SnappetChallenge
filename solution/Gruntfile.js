module.exports = function(grunt) {

    grunt.initConfig({

        uglify: {
            module: {
                files: {
                    'dist/mainModule.js': ['js/app.js', 'js/controller/*.js', 'js/services/*.js','js/directive/*.js']
                }
            }
        },

        cssmin: {
            target: {
                files: {
                    'dist/module.css': ['node_modules/bootstrap/dist/css/bootstrap.min.css', 'style/*.css']
                }
            }
        },
        watch: {
            css: {
                files: ['style/*.css'],
                tasks: ['cssmin']
            },
            js: {
                files: ['js/*.js', 'js/**/*.js'],
                tasks: ['uglify'],
            }
        },

        shell: {
            serve: {
                command: 'http-server'
            }
        }

    });


    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-shell');

    grunt.registerTask('build', ['uglify', 'cssmin', 'watch']);
    grunt.registerTask('serve', ['shell:serve']);



}