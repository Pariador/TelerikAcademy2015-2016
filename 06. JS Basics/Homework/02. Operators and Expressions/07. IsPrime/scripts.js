// Problem 7. Is prime
// Write an expression that checks if given positive integer number n (n ≤ 100) is prime.

// Examples:
// n		Prime?

// 1		false
// 2		true
// 3		true
// 4		false
// 9		false
// 37		true
// 97		true
// 51		false
// -3		false
// 0		false

function isPrime(number) {
	var maxDevider,
		i;

	if (number === 2) {
		return true;
	}

	if(number < 0 || number === 1 || !(number % 2)) {
		return false;
	}

	maxDevider = Math.sqrt(number);
	for(i = 3; i <= maxDevider; i+=2) {
		if (!(number % i)) {
			return false;
		};
	}

	return true;
}

(function main() {
	var examples = [1, 2, 3, 4, 9, 37, 97, 51, -3, 0],
		i;

	for(number of examples) {
		console.log('Is ' + number + ' prime? -> ' + isPrime(number));
	}
})();