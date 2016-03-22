// TODO: Finish users, Add Nav

console.log('------------ APP START ------------');
var requireDir = require('require-dir');
var path = require('path');
var express = require('express');

var initializers = requireDir('./init');

var app = express();

var config = {
	PORT: 8888,
	app: app,
	data: {
		db: 'mongodb://localhost/NodeExam'
	}
};

var initSkip = ['routes', 'addSampleData', 'data', 'passport']
initializers.data(config);
initializers.passport(config);
for (var init in initializers) {
	if (initSkip.indexOf(init) === -1) {
		initializers[init](config);
	}
}


app.listen(config.PORT);
console.log('Server running on port: ' + config.PORT);

console.log('');