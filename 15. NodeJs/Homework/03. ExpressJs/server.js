console.log('------------- APP START -------------');

// TODO: home, register, login, info, buy, sell

var express = require('express');
var path = require('path');

var registerRoutes = require('./routes/register-routes');
var notFound = require('./middleware/not-found');

var PORT = 8888;

var app = express();

app.set('view engine', 'jade');
app.set('views', path.join(__dirname, 'views'));
app.use(express.static(path.join(__dirname, 'public')));

app.locals.title = 'TechOffer';

registerRoutes(app);

app.use(notFound);

app.listen(PORT);

console.log('Server running on port: ' + PORT);

console.log('');