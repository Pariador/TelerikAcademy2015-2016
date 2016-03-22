// Problem 12. Generate list
// Write a function that creates a HTML <ul> using a template for every HTML <li>.
// The source of the list should be an array of elements.
// Replace all placeholders marked with –{…}– with the value of the corresponding property of the object.

// Example:
// HTML:
// <div data-type="template" id="list-item">
//  <strong>-{name}-</strong> <span>-{age}-</span>
// </div>

// JavaScript:
// var people = [{name: 'Peter', age: 14},…];
// var tmpl = document.getElementById('list-item').innerHtml;
// var peopleList = generateList(people, template);
// peopleList = '<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>'

function generateList(arr, template) {
	var item,
		liContent,
		result = '<ul>';

	for (item of arr) {
		liContent = template.replace(/-{(\w+)}-/g, function(match, prop) {
			return item[prop];
		});

		result+= '<li>' + liContent + '</li>';
	}

	return result + '</ul>';
}

(function main() {
	var template = '<strong>-{name}-</strong><span>-{age}-</span>',
		people = [
					{name: 'John', age: 0},
					{name: 'Jane', age: 1},
					{name: 'Bane', age: 2},
					{name: 'Mane', age: 3},
					{name: 'Lame', age: 4}
				];
	console.log(generateList(people, template));
})();