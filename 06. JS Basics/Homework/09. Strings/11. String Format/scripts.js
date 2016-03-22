// Problem 11. String format
// Write a function that formats a string using placeholders.
// The function should work with up to 30 placeholders and all types.

// Examples:
// var str = stringFormat('Hello {0}!', 'Peter');
// str = 'Hello Peter!';

// var frmt = '{0}, {1}, {0} text {2}';
// var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
// str = '1, Pesho, 1 text Gosho'

function stringFormat(string, one, two, three, four, five) {
	var i,
		len,
		placeHolder,
		args = arguments;

	string = string.replace(/{(\d+)}/g, function(match, index){
		return args[(+index) + 1];
	});

	return string;
}

(function main() {
	console.log(stringFormat('Hello {0}!', 'Peter'));
	console.log(stringFormat('{0}, {1}, {0} text {2}', 1, 'Pesho', 'Gosho'));
})();