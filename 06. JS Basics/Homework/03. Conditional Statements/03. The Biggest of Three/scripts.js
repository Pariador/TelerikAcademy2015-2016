// Problem 3. The biggest of Three
// Write a script that finds the biggest of three numbers.
// Use nested if statements.

// Examples:
// a		b		c		biggest

// 5		2		2		5
// -2		-2		1		1
// -2		4		3		4
// 0		-2.5	5		5
// -0.1		-0.5	-1.1	-0.1

function nestedIfs(a, b, c) {
	if (a >= b) {
		if (a >= c) {
			return a;
		}
	}

	if (b >= a) {
		if (b >= c) {
			return b;
		}
	}

	if (c >= a) {
		if (c >= b) {
			return c;
		}
	}
}

function maxNumber(numbersArr) {
	var max = numbersArr[0],
		len,
		i;

	for (i = 1, len = numbersArr.length; i < len; i+=1) {
		if (numbersArr[i] > max) {
			max = numbers[i];
		}
	}

	return max;
}

(function main() {
	var result,
		numbers,
		examples = [
						[5, 2, 2],
						[-2, -2, 1],
						[-2, 4, 3],
						[0, -2.5, 5],
						[-0.1, -0.5, -1.1],
						[1, 2, 2]
					];

	console.log('With nested ifs:');
	for (numbers of examples) {
		result = nestedIfs(numbers[0], numbers[1], numbers[2]);

		console.log('Biggest of [' + numbers.join(', ') + ']: ' + result);
	}

	console.log("\nThe other way:");
	for (numbers of examples) {
		result = maxNumber(numbers);

		console.log('Biggest of [' + numbers.join(', ') + ']: ' + result);
	}
})();