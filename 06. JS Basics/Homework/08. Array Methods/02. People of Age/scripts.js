// Problem 2. People of age
// Write a function that checks if an array of person contains only people of age (with age 18 or greater)
// Use only array methods and no regular loops (for, while)

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
	var ofAge,
		firstArr = [createPerson('John', 'Doe', 23, false), createPerson('Lily', 'Anderson', 25, true)],
		secondArr = [createPerson('Dorian', 'Silversmith', 18, false), createPerson('Miria', 'Smith', 17, true)];

	ofAge = function(person) {
		return person.age >= 18;
	}

	console.log('First arr: ' + firstArr.every(ofAge));
	console.log('Second arr: ' + secondArr.every(ofAge));
})();