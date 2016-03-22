// Problem 5. Youngest person
// Write a function that finds the youngest male person in a given array of people and prints his full name
// Use only array methods and no regular loops (for, while)
// Use Array#find

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
				createPerson('One', 'Two', 15, true),
				createPerson('Two', 'Three', 18, false),
				createPerson('Three', 'Four', 17, true),
				createPerson('Four', 'Five', 19, false),
				createPerson('Five', 'Six', 45, true),
				createPerson('Six', 'Seven', 27, false),
				createPerson('Seven', 'Eight', 36, true),
				createPerson('Eight', 'Nine', 21, false),
				createPerson('Nine', 'Ten', 13, true),
				createPerson('Ten', 'Eleven', 16, false)
				];

	males = people.filter(function(person) {
		return !person.gender;
	});

	if (males.length > 0) {
		result = males.reduce(function(youngest, person) {
			if (person.age < youngest.age) {
				return person;
			}

			return youngest;
		}, males[0]);

		console.log(result.toString());
	} else {
		console.log('None.');
	}
})();