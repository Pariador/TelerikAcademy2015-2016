var requireDir = require('require-dir');
var mongoose = require('mongoose');
var models = requireDir('../data/models');
var addSampleData = require('./addSampleData');

module.exports = function(config) {
	mongoose.connect(config.data.db);
    var db = mongoose.connection;

    db.once('open', function(err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database connection established.')
    });

    db.on('error', function(err){
        console.log('Database error: ' + err);
    });

    for (var model in models) {
        models[model].init();
    }

    addSampleData(config);
};