// Problem 1. Odd or Even
// Write an expression that checks if given integer is odd or even.

for(var c = 0; c < 20; c+=1) {
	var randomInt = (Math.random() * 100) | 0;
	var result = randomInt % 2 !== 0;

	console.log('Is ' + randomInt + ' odd? Answer: ' + result);
}