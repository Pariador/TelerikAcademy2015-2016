module.exports = function(grunt) {
	grunt.initConfig({
		compileDest: 'dev',
		clean: ['<%= compileDest%>'],
		copy: {
			images: {
				expand: true,
				cwd: 'app/images',
				src: '*',
				dest: '<%= compileDest%>/images'
			},
		},
		jade: {
			default: {
				files: [{
					expand: true,
					cwd: 'app',
					src: '**/*.jade',
					dest: '<%= compileDest%>',
					ext: '.html'
				}]
			}
		},
		stylus: {
			default: {
				files: {
					'<%= compileDest%>/styles/app.css': 'app/styles/**/*.styl'
				}
			}
		},
		coffee: {
			default: {
				files: [{
					expand: true,
					cwd: 'app/scripts',
					src: '**/*.coffee',
					dest: '<%= compileDest%>/scripts',
					ext: '.js'
				}]
			}
		},
		csslint: {
			default: {
				src: ['<%= compileDest%>/styles/**/*.css']
			}
		},
		jshint: {
			options: {
				force: true,
				eqeqeq: true
			},
			default: {
				src: ['<%= compileDest%>/scripts/**/*.js']
			}
		},
		uglify: {
			default: {
				files: [{
					expand: true,
					src: '<%= compileDest%>/scripts/**/*.js',
					dest: ''
				}]
			}
		},
		connect: {
			default: {
				options: {
					hostname: 'localhost',
					port: 8888,
					base: '<%= compileDest%>',
					open: true,
					livereload: true
				}
			}
		},
		watch: {
			default: {
				options: {
					livereload: true
				},
				files: ['app/**/*'],
				tasks: ['compile']
			}
		}
	});

	require('load-grunt-tasks')(grunt);

	grunt.registerTask('compile', 'Compile all.', function(dest) {
		if (dest) {
			grunt.config.set('compileDest', dest);
		}

		grunt.task.run([
			'clean',
			'copy',
			'jade',
			'stylus',
			'coffee'
		]);
	});

	grunt.registerTask('serve', [
		'compile',
		'connect',
		'watch'
	]);

	grunt.registerTask('test', 'test', function() {
		grunt.log.writeln(grunt.config.get('compileDest'));
	});

	grunt.registerTask('build', [
		'compile:dist',
		'csslint',
		'jshint',
		'uglify'
	]);
};