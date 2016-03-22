/*
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {
	return function(students) {
		function getFullName(student) {
			return student.firstName + ' ' + student.lastName;
		}

		function getAverageMark(marks) {
			var sum = _.reduce(marks, function(sum, grade) {
				return sum + grade;
			});

			var avg = sum / marks.length;
			return avg;
		}

		var studentWithHigherstAverageMark = _.max(students, function(student) {
			return getAverageMark(student.marks);
		});

		var fullName = getFullName(studentWithHigherstAverageMark);
		var averageMark = getAverageMark(studentWithHigherstAverageMark.marks);
		console.log(fullName + ' has an average score of ' + averageMark);
	}
}

module.exports = solve;
