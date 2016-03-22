/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(start, end) {
	function isPrime(number) {
		var c,
			numSqrt;

		if (number === 2) {
			return true
		}

		if (number < 2 || !(number % 2)) {
			return false;
		}

		for (c = 3, numSqrt = Math.sqrt(number); c <= numSqrt; c+=2) {
			if (!(number % c)) {
				return false;
			}
		}

		return true;
	}

	var num,
		result = [];

	if (start === undefined || end === undefined) {
		throw new Error('There were undefined parameters.');
	}

	start = +start;
	end = +end;

	if (isNaN(start) || isNaN(end)) {
		throw new Error('Invalid parameters.');
	}

	if (start > end) {
		throw new Error('Invalid range.')
	}

	for (num = start; num <= end; num+=1) {
		if (isPrime(num)) {
			result.push(num);
		}
	}

	return result;
}

module.exports = findPrimes;
