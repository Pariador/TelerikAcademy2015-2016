// Problem 7. The biggest of five numbers
// Write a script that finds the greatest of given 5 variables.
// Use nested if statements.

// Examples:
// a	b		c		d	e		biggest
// 5	2		2		4	1		5
// -2	-22		1		0	0		1
// -2	4		3		2	0		4
// 0	-2.5	0		5	5		5
// -3	-0.5	-1.1	-2	-0.1	-0.1

function biggestOfFive(numbers) {
	if (numbers[0] >= numbers[1]) {
		if (numbers[0] >= numbers[2]) {
			if (numbers[0] >= numbers[3]) {
				if (numbers[0] >= numbers[4]) {
					return numbers[0];
				}
			}
		}
	}

	if (numbers[1] >= numbers[0]) {
		if (numbers[1] >= numbers[2]) {
			if (numbers[1] >= numbers[3]) {
				if (numbers[1] >= numbers[4]) {
					return numbers[1];
				}
			}
		}
	}

	if (numbers[2] >= numbers[0]) {
		if (numbers[2] >= numbers[1]) {
			if (numbers[2] >= numbers[3]) {
				if (numbers[2] >= numbers[4]) {
					return numbers[2];
				}
			}
		}
	}

	if (numbers[3] >= numbers[0]) {
		if (numbers[3] >= numbers[1]) {
			if (numbers[3] >= numbers[2]) {
				if (numbers[3] >= numbers[4]) {
					return numbers[3];
				}
			}
		}
	}

	if (numbers[4] >= numbers[0]) {
		if (numbers[4] >= numbers[1]) {
			if (numbers[4] >= numbers[2]) {
				if (numbers[4] >= numbers[3]) {
					return numbers[4];
				}
			}
		}
	}
}

(function main() {
	var result,
		numbers,
		examples = [
					[5, 2, 2, 4, 1],
					[-2, -22, 1, 0, 0],
					[-2, 4, 3, 2, 0],
					[0, -2.5, 0, 5, 5],
					[-3, -0.5, -1.1, -2, -0.1]
					];

	for (numbers of examples) {
		result = biggestOfFive(numbers);

		console.log('[' + numbers.join(', ') + ']\n' + 'Result: ' + result + '\n');
	}
})();