// Problem 3. Occurrences of word
// Write a function that finds all the occurrences of word in a text.
// The search can be case sensitive or case insensitive.
// Use function overloading.

function findWord(word, text, caseSensitive) {
	var i = -1,
		result = [];

	caseSensitive = (caseSensitive === undefined)? true : caseSensitive;

	if (!caseSensitive) {
		word = word.toLowerCase();
		text = text.toLowerCase();
	}

	for (;;) {
		i = text.indexOf(word, i + 1);

		if (i === -1) {
			break;
		}

		result.push(i);
	}

	if (result.length > 0) {
		return result;
	}

	return null;
}

(function main() {
	var result,
		find = 'a',
		text = 'A A aaa';

	result = findWord(find, text, true);
	if (result !== null) {
		console.log('Case sensitive: [' + result.join(', ') + ']');
	} else {
		console.log('ERROR!');
	}

	result = findWord(find, text, false);
	if (result !== null) {
		console.log('Case insensitive: [' + result.join(', ') + ']');

	} else {
		console.log('ERROR!');
	}
})();