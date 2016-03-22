// Problem 2. Lexicographically comparison
// Write a script that compares two char arrays lexicographically (letter by letter).

function stringCompare(first, second) {
	var i,
		firstLength,
		secondLength,
		difference,
		charOfFirst,
		charOfSecond;

	// Compare by ASCII values until one of the strings runs out.
	firstLength = first.length;
	secondLength = second.length;
	for (i = 0; i < firstLength && i < secondLength; i+=1) {
		charOfFirst = first.charCodeAt(i);
		charOfSecond = second.charCodeAt(i);

		difference = charOfFirst - charOfSecond;

		if (difference) {
			return difference;
		}
	}

	// If they are equal at this point we need to compare them by length.
	// The shorter one being before the other, alphabetically.
	if (firstLength > secondLength) {
		return 1;
	} else if (firstLength < secondLength) {
		return -1;
	}

	// If they have equal length as well they are equal.
	return 0;
}

(function main() {
	var test,
		tests = [
					['a', 'b'],
					['ab', 'aa'],
					['aaa', 'aaa'],
					['aaa', 'aa'],
					['aa', 'aaa']
					];

	for (test of tests) {
		console.log('(' + test[0] + ') compared to (' + test[1] + '): ' + stringCompare(test[0], test[1]))
	}
})();