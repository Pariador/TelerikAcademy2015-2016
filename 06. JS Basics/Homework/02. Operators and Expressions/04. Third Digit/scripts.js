// Problem 4. Third digit
// Write an expression that checks for given integer if its third digit (right-to-left) is 7.

var result,
	examples = [ 4, 700, 1731, 9702, 876, 777876, 9999799 ],
	numberAsStr;

console.log('The mathz way.');
for(number of examples) {
	result = (((number / 100) | 0) % 10) === 7;
	console.log(number + ' -> ' + result);
}

console.log('\nThe stringz way.');
for(number of examples) {
	numberAsStr = '' + number;
	result = numberAsStr[numberAsStr.length - 3] === '7';
	console.log(number + ' -> ' + result);
}