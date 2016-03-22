// Problem 6. Larger than neighbours
// Write a function that checks if the element at given position in given array of integers is bigger than its two neighbours (when such exist).

function largerThanNeighbors(index, array) {
	var leftFailCheck = array[index - 1] !== undefined && array[index - 1] >= array[index],
		rightFailCheck = array[index + 1] !== undefined && array[index + 1] >= array[index];

	if (leftFailCheck || rightFailCheck) {
		return false;
	}

	return true;
}


(function main() {
	var i,
		len,
		result,
		test = [2, 1, 3, 1],
		expected = [true, false, true, false];


	for (i = 0, len = test.length; i < len; i+=1) {
		result = largerThanNeighbors(i, test);

		console.log('Test ' + i + ': ' + (result === expected[i]));
	}
})();