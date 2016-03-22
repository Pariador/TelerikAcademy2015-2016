// Problem 5. Youngest person
// Write a function that finds the youngest person in a given array of people and prints his/hers full name
// Each person has properties firstname, lastname and age.

// Example:
// var people = [
//   { firstname : 'Gosho', lastname: 'Petrov', age: 32 },
//   { firstname : 'Bay', lastname: 'Ivan', age: 81},… ];

function youngestPerson(people) {
	var i,
		len,
		findIndex = 0,
		findAge = people[0].age;

	for (i = 1, len = people.length; i < len; i+=1) {
		if (people[i].age < findAge) {
			findAge = people[i].age;
			findIndex = i;
		}
	}

	return people[findIndex].firstName + ' ' + people[findIndex].lastName;
}

(function main() {
	var people = [
 					 { firstName : 'Gosho', lastName: 'Petrov', age: 32 },
 					 { firstName : 'Pesho', lastName: 'Ivanov', age: 28 },
 					 { firstName : 'Kid', lastName: 'Squid', age: 5 },
 					 { firstName : 'Nameless', lastName: 'LastNameless', age: 21 },
 					 { firstName : 'Anny', lastName: 'Fox', age: 26 },

					];

	console.log('Yougest person: ' + youngestPerson(people));
})();