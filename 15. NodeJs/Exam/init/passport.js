var mongoose = require('mongoose');
var encryption = require('../services/encryption');
var passport = require('passport');
var LocalStrategy = require('passport-local');

module.exports = function(config) {
	var User = require('mongoose').model('User');

	var strategy = new LocalStrategy(function(username, password, done) {
		User.findOne({username: username})
		.exec(function(err, user) {
			if (err) {
				return  done(err);
			}

			if (user) {
				var submitedPassHash = encryption.generateHashedPassword(user.salt, password);

				if (submitedPassHash === user.passHash) {
					return done(null, user);
				}
			}

			return done(null, false);
		});
	});

	passport.serializeUser(function(user, done) {
		done(null, user._id);
	});

	passport.deserializeUser(function(id, done) {
		User.findOne({_id: id})
		.exec(function(err, user) {
			return done(err, user);
		});
	});

	passport.use(strategy);
};