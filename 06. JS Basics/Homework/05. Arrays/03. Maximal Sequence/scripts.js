// Problem 3. Maximal sequence
// Write a script that finds the maximal sequence of equal elements in an array.

// Example:
// input							result
// 2, 1, 1, 2, 3, 3, 2, 2, 2, 1		2, 2, 2

function maximalSequence(numbers) {
	var i,
		len,
		value = numbers[0],
		count = 1,
		maxCount = 1;

	for (i = 1, len = numbers.length; i < len; i+=1) {
		if (numbers[i - 1] === numbers[i]) {
			count+=1;
		} else {
			count = 1;
		}

		if (count > maxCount) {
			maxCount = count;
			value = numbers[i];
		}
	}

	return {value: value, count: maxCount};
}


(function main() {
	var i,
		result,
		output = [],
		example = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];

	result = maximalSequence(example);

	for (i = 0; i < result.count; i+=1) {
		output[i] = result.value;
	}
	console.log('Result: [' + output.join(', ') + ']');
})();