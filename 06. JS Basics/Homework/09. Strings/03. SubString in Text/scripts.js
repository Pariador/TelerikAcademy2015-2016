// Problem 3. Sub-string in text
// Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).

// Example:
// The target sub-string is 'in'
// The text is as follows: We are living in an yellow submarine. We don't have anything else.
// Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.
// The result is: 9

function countOccurrences(str, text) {
	var foundIndex = -1,
		count = 0;

	str = str.toLowerCase();
	text = text.toLowerCase();

	for (;;) {
		foundIndex = text.indexOf(str, foundIndex + 1);

		if (foundIndex === -1) {
			break;
		}

		count+=1;
	}

	return count;
}

(function main() {
	var example = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.",
		target = 'in';

	console.log('Result: ' + countOccurrences(target, example));
})();