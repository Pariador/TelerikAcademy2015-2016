// Problem 1. Format with placeholders
// Write a function that formats a string. The function should have placeholders, as shown in the example
// Add the function to the String.prototype

// Example:
// input	output
// var options = {name: 'John'};
// 'Hello, there! Are you #{name}?'.format(options);	'Hello, there! Are you John'
// var options = {name: 'John', age: 13};
// 'My name is #{name} and I am #{age}-years-old').format(options);	'My name is John and I am 13-years-old'

String.prototype.format = function format(options) {
	return  this.replace(/#{(\w+)}/g, function(match, prop) {
		return options[prop];
	});
};

(function main() {
	var str1 = 'Hello, there! Are you #{name}?',
		str2 = 'My name is #{name} and I am #{age}-years-old';

	str1.format({name: 'John'});
	str2.format({name: 'John', age: 13});

	console.log('Hello, there! Are you #{name}?'.format({name: 'John'}));
	console.log('My name is #{name} and I am #{age}-years-old'.format({name: 'John', age: 13}));
})();