var _ = require('underscore');
var mongoose = require('mongoose');
var Playlist = mongoose.model('Playlist');

exports.create = function(playlist, done) {
	Playlist.create(playlist, done);
};

exports.getPublic = function (done) {
	Playlist.find({isPrivate: false})
		.exec(function(err, playlists) {
			if (err) {
				done(err);
				return;
			}

			var result = _.sortBy(playlists, function(pl) {
				pl.rating = pl.avgRating();
				return pl.rating;
			});

			done(null, result.slice(0, 8));
		});
};

exports.getById = function(id, done) {
	Playlist.findOne({_id: id})
	.exec(done);
};