// Problem 6. Most frequent number
// Write a script that finds the most frequent number in an array.

// Example:
// input									result
// 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3	4 (5 times)
function findMostFrequentNum(numbers) {
	var i,
		j,
		len,
		count,
		copy = numbers.slice(0),
		maxCount = 0,
		maxValue;
	for (i = 0, len = copy.length; i < len - 1; i+=1) {
		if (copy[i] === null) {
			continue;
		}

		count = 1;
		for (j = i + 1; j < len; j+=1) {
			if (copy[j] === null) {
				continue;
			}

			if (copy[i] === copy[j]) {
				count+=1;

				copy[j] = null;
			}
		}

		if (count > maxCount) {
			maxCount = count;
			maxValue = copy[i];
		}
	}

	return {value: maxValue, count: maxCount};
}

(function main() {
	var result,
		example = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];

	result = findMostFrequentNum(example);

	console.log('Value = ' + result.value + ' Count = ' + result.count);
})();