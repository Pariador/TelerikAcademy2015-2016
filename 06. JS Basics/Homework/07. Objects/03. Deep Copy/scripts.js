// Problem 3. Deep copy
// Write a function that makes a deep copy of an object
// The function should work for both primitive and reference types.

function copy(obj) {
	var prop,
		copy = {};

	if (typeof(obj) !== 'object') {
		return obj;
	}

	for (prop in obj) {
		copy[prop] = obj[prop];
	}

	return copy;
}

(function main() {
	var obj = {a: 0, b: 0}
		copy = copy(obj);

	obj.a = 'changed';

	console.log(obj);
	console.log(copy);
})();