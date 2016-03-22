exports.get = function(req, res) {
	console.log(req.user);

	res.render('test');
};