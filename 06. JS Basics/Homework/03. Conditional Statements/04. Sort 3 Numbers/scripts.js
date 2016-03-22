// Problem 4. Sort 3 numbers
// Sort 3 real values in descending order.
// Use nested if statements.
// Note: Don’t use arrays and the built-in sorting functionality.

// Examples:
// a		b		c	|result

// 5		1		2	|5 		2 		1
// -2		-2		1	|1 		-2 		-2
// -2		4		3	|4 		3 		-2
// 0		-2.5	5	|5 		0 		-2.5
// -1.1		-0.5	-0.1|-0.1	-0.5 	-1.1
// 10		20		30	|30 	20		10
// 1		1		1	|1 		1		1
function sortThree(numbers) {
	var result = [];

	if (numbers[0] >= numbers[1] && numbers[0] >= numbers[2]) {
		result[0] = numbers[0];

		if (numbers[1] > numbers[2]) {
			result[1] = numbers[1];
			result[2] = numbers[2];
		} else {
			result[1] = numbers[2];
			result[2] = numbers[1];
		}
	} else if (numbers[1] >= numbers[0] && numbers[1] >= numbers[2]) {
		result[0] = numbers[1];

		if (numbers[0] > numbers[2]) {
			result[1] = numbers[0];
			result[2] = numbers[2];
		} else {
			result[1] = numbers[2];
			result[2] = numbers[0];
		}
	} else {
		result[0] = numbers[2];

		if (numbers[0] > numbers[1]) {
			result[1] = numbers[0];
			result[2] = numbers[1];
		} else {
			result[1] = numbers[1];
			result[2] = numbers[0];
		}
	}

	return result;
}


function selectionSort(numbers) {
	var i,
		j,
		len,
		swap,
		result = numbers.slice(0);

	for (i = 0, len = result.length; i < len - 1; i+=1) {
		for (j = i + 1; j < len ; j+=1) {
			if (result[j] > result[i]) {
				swap = result[i];
				result[i] = result[j];
				result[j] = swap;
			}
		}
	}

	return result;
}

(function main() {
	var numbers,
		examples = [
					[5, 1, 2],
					[-2, -2, 1],
					[-2, 4, 3],
					[0, -2.5, 5],
					[-1.1, -0.5, -0.1],
					[10, 20, 30],
					[1, 1, 1]
					];

	for (numbers of examples) {
		console.log('Sort Three:\n' + sortThree(numbers));
		console.log('Selection Sort:\n' + selectionSort(numbers) + '\n');
	}
})();