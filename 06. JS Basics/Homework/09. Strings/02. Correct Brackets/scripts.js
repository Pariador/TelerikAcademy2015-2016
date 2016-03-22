// Problem 2. Correct brackets
// Write a JavaScript function to check if in a given expression the brackets are put correctly.
// Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).

function checkBrackets(expression) {
	var i,
		len,
		openCount = 0,
		closedCount = 0;

	for (i = 0, len = expression.length; i < len; i+=1) {
		if (expression[i] === '(') {
			openCount+=1;
		} else if (expression[i] === ')') {
			closedCount+=1;
		}

		if (closedCount > openCount) {
			return false;
		}
	}

	if (openCount === closedCount) {
		return true
	}

	return false;
}

(function main() {
	var correct = '((a+b)/5-d)',
		incorrect = ')(a+b))';

	console.log('Correct expression: ' + checkBrackets(correct));
	console.log('Incorrect expression: ' + checkBrackets(incorrect));
})();