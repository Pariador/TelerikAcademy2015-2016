// Problem 2. Multiplication Sign
// Write a script that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.
// Use a sequence of if operators.

// Examples:
// a	b		c		result
// 5	2		2		+
// -2	-2		1		+
// -2	4		3		-
// 0	-2.5	4		0
// -1	-0.5	-5.1	-



function wtf(a, b, c) {
	// + + +
	// + - -
	// - + -
	// - - +

	// - - -
	// - + +
	// + - +
	// + + -

	if (((a > 0) && (b > 0) && (c > 0)) ||
		((a > 0) && (b < 0) && (c < 0)) ||
		((a < 0) && (b > 0) && (c < 0)) ||
		((a < 0) && (b < 0) && (c > 0))) {
		return '+';
	} else if (((a < 0) && (b < 0) && (c < 0)) ||
				((a < 0) && (b > 0) && (c > 0)) ||
				((a > 0) && (b < 0) && (c > 0)) ||
				((a > 0) && (b > 0) && (c < 0))) {
		return '-';
	} else {
		return '0';
	}
}

function countNegatives(a, b, c) {
	var number,
		allNumbers = [a, b ,c],
		negativeCount = 0;

	for (number of allNumbers) {
		if (number < 0) {
			negativeCount += 1;
		} else if (!number) {
			return '0';
		}
	}

	if (!negativeCount || negativeCount === 2) {
		return '+';
	} else {
		return '-';
	}
}

function findSign(a, b, c) {
	var result = a * b * c;

	if (result > 0) {
		return '+';
	} else if (result < 0) {
		return '-';
	} else {
		return '0';
	}
}

(function main() {
	var numbers,
		examples = [
					[5, 2, 2],
					[-2, -2, 1],
					[-2, 4, 3],
					[0, -2.5, 4],
					[-1, -0.5, -5.1]
					];

	console.log('The wtf way:')
	for (numbers of examples) {
		console.log(wtf(numbers[0], numbers[1], numbers[2]));
	}

	console.log('\nCount Negatives:')
	for (numbers of examples) {
		console.log(countNegatives(numbers[0], numbers[1], numbers[2]));
	}

	console.log('\nFind Sign:');
	for (numbers of examples) {
		console.log(findSign(numbers[0], numbers[1], numbers[2]));
	}
})();