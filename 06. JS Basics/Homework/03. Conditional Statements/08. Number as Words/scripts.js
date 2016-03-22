// Problem 8. Number as words
// Write a script that converts a number in the range [0…999] to words, corresponding to its English pronunciation.

function numberAsWord(number) {
	var result,
		i,
		digitCount,
		digits = [],
		hold = number,
		units = [
				'',
				'one',
				'two',
				'three',
				'four',
				'five',
				'six',
				'seven',
				'eight',
				'nine'
				],
		teens = [
				'ten',
				'eleven',
				'twelve',
				'thirteen',
				'fourteen',
				'fifteen',
				'sixteen',
				'seventeen',
				'eighteen',
				'nineteen'
				],
		tens = [
				'',
				'',
				'twenty',
				'thirty',
				'forty',
				'fifty',
				'sixty',
				'seventy',
				'eighty',
				'ninety'
				],
		hundred = 'hundred';

	if (!number) {
		return 'zero';
	}
	// Get digits.
	for (i = 0; hold > 0; i+=1) {
		digits[i] = (hold % 10) | 0;
		hold = (hold / 10) | 0;
	}

	// Build result.
	digitCount = digits.length;
	result = units[digits[0]];

	if (digitCount > 1) {
		if (digits[1] === 1) {
			result = teens[digits[0]]
		} else if (digits[1]) {
			if (!digits[0]) {
				result = tens[digits[1]];
			} else {
				result = tens[digits[1]] + ' ' + result;
			}
		}
	}

	if (digitCount === 3) {
		hundred = units[digits[2]] + ' ' + hundred;

		if (number % 100) {
			result = hundred + ' and ' + result;
		} else {
			result = hundred;
		}
	}

	return result;
}

(function main() {
	var c;

	for (c = 0; c < 1000; c+=1) {
		console.log(c + ': ' + numberAsWord(c));
	}
})();