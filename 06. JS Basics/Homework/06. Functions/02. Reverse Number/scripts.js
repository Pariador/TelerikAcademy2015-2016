// Problem 2. Reverse number
// Write a function that reverses the digits of given decimal number.

// Example:
// input	output
// 256		652
// 123.45	54.321

function reverseNumber(number) {
	var i,
		len,
		result = '';

	number = '' + number;

	for (i = 0, len = number.length; i < len; i+=1) {
		result = number[i] + result;
	}

	return +result;
}

(function main() {
	var result,
		number,
		examples = [256, 123.45, 1995, 2015, 3.14];

	for (number of examples) {
		result = reverseNumber(number);

		console.log(number + ' | ' + result);
	}
})();