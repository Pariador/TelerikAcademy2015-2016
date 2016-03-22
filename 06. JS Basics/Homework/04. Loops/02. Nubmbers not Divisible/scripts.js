// Problem 2. Numbers not divisible
// Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time

(function main() {
	var c,
		n = 100;

	console.log('N = ' + n);
	for (c = 1; c <= 100; c+=1) {
		if ((!(c % 3) && !(c % 7))) {
			console.log(c);
		}
	}
})();