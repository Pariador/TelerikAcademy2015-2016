/*
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName`, `lastName` and `age` properties
*   **finds** the students whose age is between 18 and 24
*   **prints**  the fullname of found students, sorted lexicographically ascending
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {
	return function(students) {
		function getFullName(student) {
			return student.firstName + ' ' + student.lastName;
		}

		var i, len;

		var studentsFilteredByAge = _.reject(students, function(student) {
			return student.age < 18 || 24 < student.age;
		});

		var stortedSudents = _.sortBy(studentsFilteredByAge, function(student) {
			return getFullName(student);
		});

		for (i = 0, len = stortedSudents.length; i< len; i+=1) {
			console.log(getFullName(stortedSudents[i]));
		}
	}
}

module.exports = solve;
