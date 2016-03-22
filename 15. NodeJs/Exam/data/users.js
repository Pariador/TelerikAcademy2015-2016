var mongoose = require('mongoose');
var User = mongoose.model('User');
var encryption = require('../services/encryption');

exports.create = function(user, callback) {
	user.salt = encryption.generateSalt();
	user.passHash = encryption.generateHashedPassword(user.salt, user.password);

	User.create(user, callback);
};

exports.update = function(id, user, done) {
	User.update({_id: id}, user, {upsert: true}, done)
};