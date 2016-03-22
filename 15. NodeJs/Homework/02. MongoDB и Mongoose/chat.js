var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/chat');
var db = mongoose.connection;

db.on('error', function(err) {
	console.log(err);
})

// var userSchema = new mongoose.Schema({
// 	name: {type: String, required: true},
// 	password: {type: String, required: true}
// });

// var User = mongoose.model('User', userSchema);

// var messageSchema = new mongoose.Schema({
// 	from: {type: String, required: true},
// 	to: {type: String, required: true},
// 	text: {type: String, required: true}
// });

// var Message = mongoose.model('Message', messageSchema);

// function registerUser(userData, callback) {
// 	var user = new User(userData);
// 	user.save(callback);
// }

// function sendMessage(messageData, callback) {
// 	User.findOne()
// 		.where({name: messageData.from})
// 		.exec(function(err, user) {
// 			if (user) {
// 				User.findOne()
// 				.where({name: messageData.to})
// 				.exec(function(err, user) {
// 					if (user) {
// 						var message = new Message(messageData);
// 						message.save(callback);
// 					}
// 				});
// 			}
// 		});
// }

// function getMessages(users, callback) {
// 	Message.find({
// 		$or: [{from: users.with, to: users.and}, {from: users.and, to: users.with}]
// 	})
// 	.exec(callback);
// }

// module.exports = {
// 	registerUser: registerUser,
// 	sendMessage: sendMessage,
// 	getMessages: getMessages
// };