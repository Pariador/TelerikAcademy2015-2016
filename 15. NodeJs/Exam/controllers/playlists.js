var playlists = require('../data/playlists.js');

exports.getById = function(req, res) {
	playlists.getById(req.params.id, function(err, playlist) {
		if (playlist.isPrivate &&
			(!req.isAuthenticated() ||
			(req.user._id !== playlist.creatorId && playlist.canBeViewedBy.indexOf(req.user._id) === -1))) {
			res.redirect('/login');
		} else {
			res.render('playlist', {playlist: playlist});
		}
	});
};

exports.create = {
	get: function(req, res) {
		res.render('playlist-create');
	},
	post: function(req, res) {
			var playlist = req.body;

			var vids = [];
			if (playlist.videos) {
				vids = playlist.videos.split(', ');
			}
			playlist.videos = vids;

			playlist.creatorId = req.user._id;

			playlist.createdOn = new Date();

			playlist.canBeViewedBy = [];

		playlists.create(playlist, function(err, playlist) {

			res.redirect('/playlists/' + playlist._id);
		});
	}
};