/* Task Description */
/*
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {
	var Person = (function () {
		var nameRegEx = /^[A-Za-z]{3,20}$/;

		function Person(firstname, lastname, age) {
			this.firstname = firstname;
			this.lastname = lastname;
			this.age = age;
		}

		Object.defineProperties(Person.prototype, {
			firstname: {
				get: function() {return this._firstname;},
				set: function(value) {
					if (!nameRegEx.test(value)) {
						throw new Error('Invalid firstname.');
					}

					this._firstname = value;
					return this;
				}
			},
			lastname: {
				get: function() {return this._lastname;},
				set: function(value) {
					if (!nameRegEx.test(value)) {
						throw new Error('Invalid lastname');
					}

					this._lastname = value;
					return this;
				}
			},
			fullname: {
				get: function() {return this.firstname + ' ' + this.lastname;},
				set: function(value) {
					var names = value.split(' ');

					this.firstname = names[0];
					this.lastname = names[1];
					return this;
				}
			},
			age: {
				get: function() {return this._age;},
				set: function(value) {
					value = +value;

					if (isNaN(value)) {
						throw new Error('Age must be a valid number.');
					}

					if (value < 0 || value > 150) {
						throw new Error('Age must be between 0 and 150.');
					}

					this._age = value;
					return this;
				}
			}
		});

		Person.prototype.introduce = function introduce() {
			return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
		};

		return Person;
	} ());
	return Person;
}

module.exports = solve;