// Problem 6. Group people
// Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object
// Use Array#reduce
// Use only array methods and no regular loops (for, while)

// Example:
//     result = {
//         'a': [{
//             firstname: 'Asen',
//             /* ... */
//         }, {
//             firstname: 'Anakonda',
//             /* ... */
//         }],
//         'j': [{
//             firstname: 'John',
//             /* ... */
//         }]
//     };

// Copied from Problem 1.
function createPerson(firstName, lastName, age, gender) {
	return {
		firstName: firstName,
		lastName: lastName,
		age: age,
		gender: gender,

		toString: function toString() {
			return this.firstName + ' ' + this.lastName + ' Age: ' + this.age + ' Gender: ' + (this.gender? 'female' : 'male');
		}
	}
}

(function main() {
	var	males,
	result,
	people = [
			createPerson('One', 'Doe', 15, true),
			createPerson('Two', 'Doe', 18, false),
			createPerson('Three', 'Doe', 17, true),
			createPerson('Four', 'Doe', 19, false),
			createPerson('Five', 'Doe', 45, true),
			createPerson('Six', 'Doe', 27, false),
			createPerson('Seven', 'Doe', 36, true),
			createPerson('Eight', 'Doe', 21, false),
			createPerson('Nine', 'Doe', 13, true),
			createPerson('Ten', 'Doe', 16, false)
			];

	result = people.reduce(function(groups, person) {
		var firstLetter = person.firstName[0].toLowerCase();

		if (groups.hasOwnProperty(firstLetter)) {
			groups[firstLetter].push(person);
		} else {
			groups[firstLetter] = [person];
		}

		return groups;
	}, {});

	console.log(result);
})();