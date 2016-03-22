// Problem 5. Selection sort
// Sorting an array means to arrange its elements in increasing order.
// Write a script to sort an array.
// Use the selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

function selectionSort(numbers) {
	var i,
		j,
		len,
		swap;

	for (i = 0, len = numbers.length; i < len - 1; i+=1) {
		for (j = i + 1; j < len; j+=1) {
			if (numbers[j] < numbers[i]) {
				swap = numbers[j];
				numbers[j] = numbers[i];
				numbers[i] = swap;
			}
		}
	}
}

(function main() {
	var numbers = [10, 9, 8, 7, 6, 5, 4, 3, 2, 1];

	selectionSort(numbers);

	console.log('Result: [' + numbers.join(', ') + ']');
})();