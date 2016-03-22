// Problem 4. Has property
// Write a function that checks if a given object contains a given property.
// var obj  = …;
// var hasProp = hasProperty(obj, 'length');

function customHasOwnProperty(obj, checkProperty) {
	var property;

	for (property in obj) {
		if (property === checkProperty) {
			return true;
		}
	}

	return false;
}

(function main() {
	var objOne = {a: 1, b: 2, length: 2};
		objTwo = {a: 10, b: 20};

	console.log('hasOwnProperty: objOne -> ' + objOne.hasOwnProperty('length') + ' | objTwo -> ' + objTwo.hasOwnProperty('length') +
				'\ncustomHasOwnProperty: objOne -> ' + customHasOwnProperty(objOne, 'length') + ' | objTwo -> ' + customHasOwnProperty(objTwo, 'length'));
})();