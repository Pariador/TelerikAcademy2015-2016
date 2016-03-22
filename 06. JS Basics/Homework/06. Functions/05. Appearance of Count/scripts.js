// Problem 5. Appearance count
// Write a function that counts how many times given number appears in given array.
// Write a test function to check if the function is working correctly.

function appearanceCount(value, array) {
	var count = 0;

	array.forEach(function(item) {
		if (value === item) {
			count+=1;
		}
	});

	return count;
}

// Resturns true if test succeeds, false otherwise.
function test() {
	var	result,
		array = [];

	for (i = 1; i < 10; i+=1) {
		for (c = 0; c < i; c+=1) {
			array.push(i);
			array.push('' + i);
		}

		result = appearanceCount(i, array);

		if (result !== i) {
			return false;
		}

		result = appearanceCount('' + i, array);

		if (result !== i) {

			return false;

		}
	}

	return true;
}

(function main() {
	var result = test();

	console.log('Test Success: ' + result);
})();