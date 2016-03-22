// Problem 10. Find palindromes
// Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".


function isPalindrome(word) {
	var i,
		len = word.length,
		iMid = (len / 2) | 0;

	for (i = 0; i < iMid; i+=1) {
		if (word[i] !== word[len - 1 - i]) {
			return false;
		}
	}

	return true;
}

function findPalindromes(string) {
	var word,
		result = [],
		words = string.match(/[A-Za-z]{2,}/g);

	for (word of words) {
		if (isPalindrome(word) && result.indexOf(word) === -1) {
				result.push(word);
		}
	}

	return result;
}

(function main() {
	var test = 'Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".';

	console.log(findPalindromes(test))
;})()