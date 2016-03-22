/* Task Description */
/*
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number

*/

function sum(numbers) {
	var i,
		len,
		sum;

	if (numbers === undefined) {
		throw new Error('Undefined parameter.');
	}

	len = numbers.length;
	if (!len) {
		return null;
	}

	for (i = 0; i < len; i+=1) {
		numbers[i] = +numbers[i];

		if (isNaN(numbers[i])) {
			throw new Error('Invalid number.');
		}
	}

	sum = numbers[0];
	for (i = 1; i < len; i+=1) {
		sum += numbers[i];
	}

	return sum;
}

module.exports = sum;