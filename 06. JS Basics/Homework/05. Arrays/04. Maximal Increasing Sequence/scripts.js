// Problem 4. Maximal increasing sequence
// Write a script that finds the maximal increasing sequence in an array.

// Example:
// input					result
// 3, 2, 3, 4, 2, 2, 4		2, 3, 4

function maxIncreasingSequence(numbers) {
	var i,
		len,
		lastValue = numbers[0],
		count = 1,
		maxCount = 1;

	for (i = 1, len = numbers.length; i < len; i+=1) {
		if (numbers[i - 1] + 1 === numbers[i]) {
			count+=1;
		} else {
			count = 1;
		}

		if (count > maxCount) {
			maxCount = count;
			lastValue = numbers[i];
		}
	}

	return {lastValue: lastValue, count: maxCount};
}

(function main() {
	var c,
		result,
		output = [],
		example = [3, 2, 3, 4, 2, 2, 4];

	result = maxIncreasingSequence(example);

	for (c = 0; c < result.count; c+=1) {
		output.unshift(result.lastValue - c);
	}
	console.log('Result: [' + output.join(', ') + ']');
})();