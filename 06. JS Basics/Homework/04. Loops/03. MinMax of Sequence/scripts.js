// Problem 3. Min/Max of sequence
// Write a script that finds the max and min number from a sequence of numbers.

function findMaxNum(numbers) {
	var i,
		len,
		max = numbers[0];

	for (i = 1, len = numbers.length; i < len; i+=1) {
		if (numbers[i] > max) {
			max = numbers[i];
		}
	}

	return max;
}

function findMinNum(numbers) {
	var i,
		len,
		min = numbers[0];

	for (i = 1, len = numbers.length; i < len; i+=1) {
		if (numbers[i] < min) {
			min = numbers[i];
		}
	}

	return min;
}

(function main() {
	var i,
		min,
		max,
		numbers,
		randomExamples = [ [], [], [], [], [] ];

	for (numbers of randomExamples) {
		for (i = 0; i < 10; i+=1) {
			numbers[i] = (Math.random() * 100) | 0;
		}

		min = findMinNum(numbers);
		max = findMaxNum(numbers);

		console.log('[' + numbers.join(', ') + ']\nMin: ' + min + ' Max: ' + max + '\n');
	}
})();