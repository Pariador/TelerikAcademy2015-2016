// Problem 2. Divisible by 7 and 5
// Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

var result,
	examples = [ 3, 0, 5, 7, 35, 140 ];

for(number of examples) {
	result = (number % 7 === 0) && (number % 5 === 0);
	console.log('Is ' + number + ' divisible by 7 and 5? Answer: ' + result);
}