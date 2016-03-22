// Problem 7. First larger than neighbours
// Write a function that returns the index of the first element in array that is larger than its neighbours or -1, if there’s no such element.
// Use the function from the previous exercise.


// Copied form previus problem.
function largerThanNeighbors(index, array) {
	var leftFailCheck = array[index - 1] !== undefined && array[index - 1] >= array[index],
		rightFailCheck = array[index + 1] !== undefined && array[index + 1] >= array[index];

	if (leftFailCheck || rightFailCheck) {
		return false;
	}

	return true;
}

function firstLargerThanNeighbors(array) {
	var i,
		len;

	for (i = 0, len = array.length; i < len; i+=1) {
		if (largerThanNeighbors(i, array)) {
			return i;
		}
	}

	return -1;
}

(function main() {
	var i,
		len,
		result,
		tests = [
				[0, 0, 0, 0, 1, 0, 0, 0],
				[0, 0, 0, 0, 0, 0, 0, 1],
				[1, 0, 0, 0, 0, 0, 0, 0],
				[0, 0, 0, 0, 0, 0, 1, 0],
				[0, 1, 0, 0, 0, 0, 0, 0],
				[0, 0, 0, 0, 0, 0, 0, 0]
				],
		expected = [4, 7, 0, 6, 1, -1];

	for (i = 0, len = tests.length; i < len; i+=1) {
		result = firstLargerThanNeighbors(tests[i]);

		console.log('Test ' + i + ': ' + (result === expected[i]));
	}
})();