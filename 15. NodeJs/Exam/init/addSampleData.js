var mongoose = require('mongoose');
var ObjectId = require('mongoose').Types.ObjectId;

module.exports = function(config) {
	var users = require('../data/users');
	var playlists = require('../data/playlists');

	var user = {
		_id: ObjectId(),
		username: 'tester',
		password: 'tester',
		email: 'tester',
		firstName: 'tester',
		lastName: 'tester',
		playlists: []
	};

	var playlist = {
		_id: ObjectId(),
		title: 'test',
		description: 'test',
		creatorId: user._id,
		videos: ['vid'],
		category: 'test',
		createdOn: new Date(),
		isPrivate: false,
		ratings: [{
			userId: user._id,
			score: 1
		}, {
			userId: user._id,
			score: 5
		}]
	};

	user.playlists.push(playlist._id);

	users.create(user, function(err, user) {
		if (err) {
			// console.log(err);
		} else {
			// console.log(user._id);
		}
	});

	playlists.create(playlist, function(err, playlist) {
		if (err) {
			console.log(err);
		} else {
			// console.log(playlist.creatorId);
			// console.log(playlist.avgRating());
		}
	});

	playlists.getPublic(function(err, data) {
		if (err) {
			console.log(err);
		} else {
			// console.log(data);
			// console.log(data.length);
		}
	});
};