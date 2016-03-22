var passport = require('passport');
var users = require('../data/users');

exports.register = {
	get: function(req, res) {
		res.render('register');
	},
	post: function(req, res) {
		users.create(req.body, function(err, user) {
			if (err) {
				res.status(400);
				res.redirect('/register');
			} else {
				res.status(201);
				res.redirect('/login');
			}
		});
	}
};

exports.login = {
	get: function(req, res) {
		res.render('login');
	},
	post: passport.authenticate('local', { successRedirect: '/', failureRedirect: '/login', failureFlash: false})
};

exports.logout = function(req, res) {
	req.logout();
	res.redirect('/');
};

exports.profile = {
	get: function(req, res) {
		res.render('profile');
	},
	post: function(req, res) {
		var newData = {};
		for (var key in req.body) {
			if (req.body[key]) {
				newData[key] = req.body[key];
			}
		}

		users.update(req.	user._id, newData, function(err, data) {
			res.redirect('./profile');
		});
	}
};

exports.isAuthenticated = function(req, res, next) {
	if (!req.isAuthenticated()) {
		res.redirect('/login');
	} else {
		next();
	}
};