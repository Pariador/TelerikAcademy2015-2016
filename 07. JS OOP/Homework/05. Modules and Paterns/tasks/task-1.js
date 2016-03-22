/* Task Description */
/*
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
	function countObjectProps(obj) {
		var prop,
			count = 0;

		for (prop in obj) {
			count+=1;
		}

		return count;
	}

	var Course = (function() {
		var nextStudentID = 1;

		function validateTitle(title) {
			if (!/^\S+(?: \S+)*$/.test(title)) {
				throw new Error('Titles must have at least one char, not start or end with space and not contain consecutive spaces.\nInvalid title: ' + title);
			}
		}

		return {
			init: function(courseTitle, presentations) {
				this.title = courseTitle;
				this.presentations = presentations;

				this._students = {};

				return this;
			},

			// Properties
			get title() {
				return this._title;
			},
			set title(value) {
				validateTitle(value);

				this._title = value;
			},

			get presentations() {
				return this._presentations.slice();
			},
			set presentations(values) {
				if (!values.length) {
					throw new Error('Each course must have at least one presentation.');
				}

				values.forEach(validateTitle);

				this._presentations = values.slice();
			},

			// Methods
			addStudent: function(name) {
				var studentID,
					names = /^([A-Z][\S]*) ([A-Z][\S]*)$/.exec(name);

				if (!names) {
					throw new Error('Invalid student name: ' + name);
				}

				studentID = nextStudentID;
				nextStudentID += 1;

				this._students[studentID] = {
					firstname: names[1],
					lastname: names[2],
					homeworks: {}
				};

				return studentID;
			},

			getAllStudents: function() {
				var id,
					student,
					result = [];

				for (id in this._students) {
					student = Object.create(this._students[id]);
					student.id = +id;
					result.push(student);
				}

				return result;
			},

			submitHomework: function(studentID, homeworkID) {
				if (homeworkID < 1 || homeworkID > this._presentations.length) {
					throw new Error('Invalid homeworkID.');
				}

				if (this._students.hasOwnProperty(studentID)) {
					this._students[studentID].homeworks[homeworkID] = true;
				} else {
					throw new Error('Invalid studentID.');
				}

				return this;
			},

			pushExamResults: function(results) {
				var i,
					len,
					scoreProp = 'examScore';

				if (!Array.isArray(results)) {
					throw new Error('Reselts need to be in an array.');
				}

				for (i = 0, len = results.length; i < len; i+=1) {
					if (this._students.hasOwnProperty(results[i].studentID)) {
						if (!this._students[results[i].studentID].hasOwnProperty(scoreProp)) {
							this._students[results[i].studentID][scoreProp] = results[i].score;
						} else {
							throw new Error('Student ' + results[i].studentID + ' already has an ' + scoreProp + '.');
						}
					} else {
						throw new Error('Invalid student ID.');
					}
				}

				for (id in this._students) {
					if (!this._students[id].hasOwnProperty(scoreProp)) {
						this._students[id][scoreProp] = 0;
					}
				}

				return this;
			},

			getTopStudents: function() {
				var topTenStudents,
					students = this.getAllStudents(),
					studentCompare = function(first, second) {
						var homeworkDifference,
							scoreDifference = first.examScore - second.examScore;

						if (!scoreDifference) {
							homeworkDifference = countObjectProps(first.homeworks) - countObjectProps(second.homeworks);

							return homeworkDifference;
						}

						return scoreDifference;
					};

				students.sort(studentCompare).reverse();
				topTenStudents = students.slice(0, 10);


				return topTenStudents;
			}
		};
	})();

	return Course;
}

// solve();
module.exports = solve;