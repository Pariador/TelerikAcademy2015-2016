var path = require('path');
var bodyParser = require('body-parser');
var session = require('express-session');
var passport = require('passport');
var static = require('express').static;
var routesInit = require('./routes');
var notFound = require('../controllers/notFound');

module.exports = function(config) {
	var app = config.app;

	app.set('views', path.join(__dirname, '../views'));
	app.set('view engine', 'jade');

	app.locals.title = 'YouTube Playlists';
	app.locals.publicPath = function(dir) {
		return 'http://' + path.join('localhost:' + config.PORT, dir);
	};

	var expires = new Date();
	expires.setDate(expires.getDate() + 1);
	app.use(bodyParser.json());
	app.use(bodyParser.urlencoded({extended: true}));
	app.use(session({secret: 'Go Go Power Rangers!!!', resave: false, saveUninitialized: false, cookie: {expires: expires}}));
	app.use(passport.initialize());
	app.use(passport.session());
	app.use(function(req, res, next) {
		if (req.isAuthenticated()) {
			app.locals.user = req.user;
		} else {
			app.locals.user = null;
		}

		next();
	});

	app.use(static(path.join(__dirname, '../public')));

	routesInit(config);

	app.use(notFound);
};