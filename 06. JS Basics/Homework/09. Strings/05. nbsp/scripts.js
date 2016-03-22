// Problem 5. nbsp
// Write a function that replaces non breaking white-spaces in a text with &nbsp;

(function main() {
	var text = 'Lorem ipsum dolor sit amet, consectetur adipisicing elit.';

	text = text.replace(/ /g, '&nbsp;');

	console.log(text);
})();