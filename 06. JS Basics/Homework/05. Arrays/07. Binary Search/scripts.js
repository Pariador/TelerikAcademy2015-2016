// Problem 7. Binary search
// Write a script that finds the index of given element in a sorted array of integers by using the binary search algorithm.

function binarySearch(find, numbers) {
	var	iMid,
		iMin = 0,
		iMax = numbers.length - 1
		copy = numbers.slice(0);

	copy = copy.sort(function(a, b) {return a - b;});

	while(iMin <= iMax) {
		iMid = ((iMin + iMax) / 2) | 0;

		if (find < copy[iMid]) {
			iMax = iMid - 1;
		} else if(find > copy[iMid]) {
			iMin = iMid + 1;
		} else {
			return iMid;
		}
	}

	return null;
}

(function main() {
	var i,
		len,
		result,
		toFind = [14, 29, 3, 0],
		expected = [4, 9, null, 0],
		numbers = [0, 5, 8, 11, 14, 17, 20, 23, 26, 29];


	for (i = 0, len = toFind.length; i < len; i+=1) {
		result = binarySearch(toFind[i], numbers);

		console.log('Result = ' + result + ' | ' + (result === expected[i]));
	}
})();