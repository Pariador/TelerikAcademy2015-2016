
/*
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName` and `lastName` properties
*   **Finds** all students whose `firstName` is before their `lastName` alphabetically
*   Then **sorts** them in descending order by fullname
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   Then **prints** the fullname of found students to the console
*   **Use underscore.js for all operations**
*/

function solve() {
	return function(students) {
		function getFullName(student) {
			return student.firstName + ' ' + student.lastName;
		}

		var i, len;

		var studentsWithLastNameBeforeFirst = _.filter(students, function(student) {
			return student.firstName < student.lastName;
		});

		var sortedStudents = _.sortBy(studentsWithLastNameBeforeFirst, function(student) {
			return getFullName(student);
		});
		sortedStudents.reverse();

		for (i = 0, len = sortedStudents.length; i < len; i+=1) {
			console.log(getFullName(sortedStudents[i]));
		}
	}
}

module.exports = solve;