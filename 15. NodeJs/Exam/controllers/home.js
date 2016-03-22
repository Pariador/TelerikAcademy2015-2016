var playlists = require('../data/playlists');
var cache = require('js-cache');

exports.get = function(req, res) {
	if (cache.get('playists')) {
		res.render('index', cache.get('playists'));
	} else {
		playlists.getPublic(function(err, playlists) {
			cache.set('playlists', playlists, 600000);
			res.render('index', {playlists: playlists});
		});
	}
};