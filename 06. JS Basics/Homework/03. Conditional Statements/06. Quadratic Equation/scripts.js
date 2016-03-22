// Problem 6. Quadratic equation
// Write a script that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
// Calculates and prints its real roots.
// Note: Quadratic equations may have 0, 1 or 2 real roots.

// Examples:
// a	b	c	roots
// 2	5	-3	x1=-3; 	x2=0.5
// -1	3	0	x1=3; 	x2=0
// -0.5	4	-8	x = 4
// 5	2	8	no real roots

function quadraticEquation(a, b, c) {
	var result,
		discriminant = Math.sqrt((b * b) - (4 * a * c)),
		divider = 2 * a;
		b = -(b);

	if (discriminant > 0) {
		result = [];

		result[0] = (b - discriminant) / divider;
		result[1] = (b + discriminant) / divider;
	} else if (!discriminant) {
		result = b / divider;
	} else {
		result = null;
	}

	return result;
}

(function main() {
	var result,
		numbers,
		examples = [
						[2, 5, -3],
						[-1, 3, 0],
						[-0.5, 4, -8],
						[5, 2, 8]
					];

	for (numbers of examples) {
		result = quadraticEquation(numbers[0], numbers[1], numbers[2]);

		if (Array.isArray(result)) {
			result = 'x1 = ' + result[0] + '; x2 = ' + result[1];
		} else if (typeof(result) === 'number') {
			result = 'x = ' + result;
		} else {
			result = 'no real roots';
		}

		console.log('[' + numbers.join(', ') + ']\nResult: ' + result + '\n')
	}
})();