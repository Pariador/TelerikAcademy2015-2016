var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

exports.init = function() {
	var schema = new Schema({
		username: {type: String, required: true, minlength: 6, maxlength: 20, validate: /^[a-zA-Z\_\.]+$/},
		salt: {type: String, required: true},
		passHash: {type: String, required: true},
		email: {type: String, required: true},
		firstName: {type: String, required: true},
		lastName: {type: String, required: true},
		avatar: {type: String, default: 'http://www.theworldofmeme.com/6369-meme-forever-alone-faces-excited-fresh-new-hd-wallpaper-best-quality.jpg'},
		facebook: String,
		youtube: String,
		playlists: [ObjectId]
	});

	mongoose.model('User', schema);
};