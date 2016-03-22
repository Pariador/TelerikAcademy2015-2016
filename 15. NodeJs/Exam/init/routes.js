var requireDir = require('require-dir');

module.exports = function(config) {
	var controllers = requireDir('../controllers');

	var app = config.app;
	app.route('/')
	.get(controllers.home.get);

	app.route('/register')
	.get(controllers.users.register.get)
	.post(controllers.users.register.post)

	app.route('/login')
	.get(controllers.users.login.get)
	.post(controllers.users.login.post);

	app.route('/logout')
	.post(controllers.users.isAuthenticated, controllers.users.logout);

	app.route('/profile')
	.get(controllers.users.isAuthenticated, controllers.users.profile.get)
	.post(controllers.users.isAuthenticated, controllers.users.profile.post)

	app.route('/playlists/create')
	.get(controllers.users.isAuthenticated, controllers.playlists.create.get)
	.post(controllers.users.isAuthenticated, controllers.playlists.create.post);

	app.route('/playlists/:id')
	.get(controllers.playlists.getById);

	app.route('/test')
	.get(controllers.users.isAuthenticated, controllers.test.get)
};