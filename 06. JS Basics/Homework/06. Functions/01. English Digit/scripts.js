// Problem 1. English digit
// Write a function that returns the last digit of given integer as an English word.

// Examples:
// input	output
// 512		two
// 1024		four
// 12309	nine

function lastDigitWord(number) {
	var lastDigit = number % 10;

	switch (lastDigit) {
		case 0: return 'zero';
		case 1: return 'one';
		case 2: return 'two';
		case 3: return 'three';
		case 4: return 'four';
		case 5: return 'five';
		case 6: return 'six';
		case 7: return 'seven';
		case 8: return 'eight';
		case 9: return 'nine';
		default: return 'not a digit';
	}
}

(function main() {
	var result,
		number,
		examples = [512, 1024, 12309];

	for (number of examples) {
		result = lastDigitWord(number);

		console.log('The last digit of ' + number + ' is ' + result + '.')
	}
})();