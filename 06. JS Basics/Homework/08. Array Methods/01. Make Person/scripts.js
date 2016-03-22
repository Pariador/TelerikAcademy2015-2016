// Problem 1. Make person
// Write a function for creating persons.
// Each person must have firstname, lastname, age and gender (true is female, false is male)
// Generate an array with ten person with different names, ages and genders

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
	var i,
		people = [];

	for (i = 0; i < 10; i+=1) {
		people.push(createPerson('Alex', '#' + i, (i + 1) * 3, !(i % 2)));
		console.log(people[i].toString());
	}
})();