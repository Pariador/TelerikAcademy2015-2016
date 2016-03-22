// Problem 5. Third bit
// Write a boolean expression for finding if the bit #3 (counting from 0) of a given integer.
// The bits are counted from right to left, starting from bit #0.
// The result of the expression should be either 1 or 0.

// Examples:
// n		binary representation	bit #3
// 5		00000000 00000101		0
// 8		00000000 00001000		1
// 0		00000000 00000000		0
// 15		00000000 00001111		1
// 5343		00010100 11011111		1
// 62241	11110011 00100001		0

var bitPos = 3,
	mask = 1,
	binaryStr,
	result,
	examples = [5, 8, 0, 15, 5343, 62241];

console.log("The wise bitwise way. Punny ain't I!");
for(number of examples) {
	result = (number & (mask << bitPos)) >> bitPos;

	console.log(number + '(' + number.toString(2) + ')' + ' bit #' + bitPos + ' is: ' + result);
}

console.log('\nThe lazy and slower stringzses way.');
for(number of examples) {
	binaryStr = number.toString(2);
	result = (binaryStr[binaryStr.length - 1 - bitPos]) | 0;
	console.log(number + '(' + binaryStr + ')' + ' bit #' + bitPos + ' is: ' + result);
}