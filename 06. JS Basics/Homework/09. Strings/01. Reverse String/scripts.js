// Problem 1. Reverse string
// Write a JavaScript function that reverses a string and returns it.

// Example:
// input	output
// sample	elpmas

function reverseString(string) {
	var i,
		len,
		result ='';

	for (i = 0, len = string.length; i < len; i+=1) {
		result = string[i] + result;
	}

	return result;
}

(function main() {
	var str = 'sample';

	str = reverseString(str);
	console.log('Reversed once: ' + str);

	str = reverseString(str);
	console.log('Reversed twice: ' + str);
})();