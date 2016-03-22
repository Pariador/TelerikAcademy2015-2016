// Problem 6.
// Write a function that groups an array of people by age, first or last name.
// The function must return an associative array, with keys - the groups, and values - arrays with people in this groups
// Use function overloading (i.e. just one function)

// Example:
// var people = {…};
// var groupedByFname = group(people, 'firstname');
// var groupedByAge= group(people, 'age');

function group(people, by) {
	var person,
		result = {};

	for (person of people) {
		if (result.hasOwnProperty(person[by])) {
			result[person[by]].push(person);
		} else {
			result[person[by]] = [person];
		}
	}

	return result;
}

(function main() {
	var result,
		people = [
					{firstName: 'Pesho', lastName: 'Forester', age: 18},
					{firstName: 'Jane', lastName: 'Doe', age: 18},
					{firstName: 'John', lastName: 'Doe', age: 20},
					{firstName: 'Pesho', lastName: 'Doe', age: 20},
					{firstName: 'Gosho', lastName: 'Lovecraft', age: 27},
					{firstName: 'Gosho', lastName: 'Forester', age: 27},
					{firstName: 'John', lastName: 'Forester', age: 54},
					{firstName: 'Gosho', lastName: 'Ponpon', age: 18},
					{firstName: 'Jane', lastName: 'Lovecraft', age: 21},
					{firstName: 'John', lastName: 'Ponpon', age: 20}
					];

	for (prop in people[0]) {
		result = group(people, prop);

		console.log('Grouped by ' + prop + ':');
		console.log(result);
		console.log('-------------------------------------------\n');
	}
})();