	// Problem 4. Lexicographically smallest
// Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects.

function findMinStr(strings) {
	var i,
		len,
		min = strings[0];

	for (i = 1, len = strings.length; i < len; i+=1) {
		if (strings[i] < min) {
			min = strings[i];
		}
	}

	return min;
}

function findMaxStr(strings) {
	var i,
		len,
		max = strings[0];

	for (i = 1, len = strings.length; i < len; i+=1) {
		if (strings[i] > max) {
			max = strings[i];
		}
	}

	return max;
}

(function main() {
	var min,
		max,
		prop,
		properties = [];

	// document
	for (prop in document) {
		properties.push(prop);
	}
	min = findMinStr(properties);
	max = findMaxStr(properties);
	console.log('document: Biggest = ' + max + ' | Smallest = ' + min);

	// window
	properties = [];
	for (prop in window) {
		properties.push(prop);
	}
	min = findMinStr(properties);
	max = findMaxStr(properties);
	console.log('window: Biggest = ' + max + ' | Smallest = ' + min);

	// navigator
	properties = [];
	for (prop in navigator) {
		properties.push(prop);
	}
	min = findMinStr(properties);
	max = findMaxStr(properties);
	console.log('navigator: Biggest = ' + max + ' | Smallest = ' + min);

})();