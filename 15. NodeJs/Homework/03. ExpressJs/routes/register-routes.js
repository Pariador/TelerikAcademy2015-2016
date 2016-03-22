var home = require('./home');
var info = require('./info');

module.exports = function registerRoutes(app) {
	app.get('/', home.root);

	app.get('/info', info.root);
};