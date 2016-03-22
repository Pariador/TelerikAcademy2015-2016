// Problem 4. Average age of females
// Write a function that calculates the average age of all females, extracted from an array of persons
// Use Array#filter
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
	var females,
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

	females = people.filter(function(person) {
		return person.gender;
	});

	result = females.reduce(function(sum, person) {
		return sum + person.age;
	}, 0) / females.length;

	console.log('Average age of females: ' + result);
})();