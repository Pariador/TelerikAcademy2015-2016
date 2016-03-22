var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var ObjectId = Schema.ObjectId;

exports.init = function() {
	var schema = new Schema({
		title: {type: String, requried: true},
		description: {type: String, requried: true},
		creatorId: {type: ObjectId, requried: true},
		videos: [String],
		category: {type: String, required: true, enum: ['test', 'Favorites', 'Watch Later', 'Music', 'Video Games']},
		createdOn: {type: Date, required: true},
		isPrivate: {type: Boolean, default: true},
		canBeViewedBy: [ObjectId],
		ratings: [{
			userId: {type: ObjectId, required: true},
			score: {type: Number, requried: true, min: 1, max: 5}
		}],
		comments: [{
			userId: {type: ObjectId, required: true},
			content: {type: String, required: true}
		}]
	});

	schema.methods.avgRating = function() {
		if (!this.ratings || this.ratings.length === 0) {
			return null;
		}

		var sum = 0;
		for (var i = 0; i < this.ratings.length; i += 1) {
			sum += this.ratings[i].score;
		}

		return sum / this.ratings.length;
	};

	mongoose.model('Playlist', schema);
};