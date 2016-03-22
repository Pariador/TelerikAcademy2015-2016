// Problem 2. HTML binding
// Write a function that puts the value of an object into the content/attributes of HTML tags.
// Add the function to the String.prototype

// Example 1:
// input

//     var str = '<div data-bind-content="name"></div>';
//     str.bind(str, {name: 'Steven'});
// output
//     <div data-bind-content="name">Steven</div>

// Example 2:
// input
//     var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>'
//     str.bind(str, {name: 'Elena', link: 'http://telerikacademy.com'});
// output
//     <a data-bind-content="name" data-bind-href="link" data-bind-class="name" href="http://telerikacademy.com" class="Elena">Elena</а>

// New attributes are added after the current ones if the attibutes aren't alredy present on the element.
// If they are present then the old ones are replaced with the new ones or if the attibute is 'class'
// the new value is added to the current value of 'class'.
// New content is added to the old content.
String.prototype.htmlBind = function htmlBind(obj) {
	// matches html elements
	return this.replace(/<([A-Za-z]+?)([\s\S]*?)>([\s\S]*?)<\/\1>/g, function(element, tagName, attributes, content) {
		var match,
			type,
			value,
			attr,
			newAttrRegEx,
			// matches data-bind attributes
			dataBindRegEx = /data-bind-([A-Za-z]+?)\s*=\s*"(\w+?)"/g;

		for(;;) {
			match = dataBindRegEx.exec(attributes);
			if (!match) {
				break;
			}
			type = match[1];
			value = obj[match[2]];

			if (type === 'content') {
				content+=value;
			} else {
				// matches a certain attribute
				newAttrRegEx = new RegExp('(?:"|\\s+)' + type + '\\s*=\\s*"([\\s\\S]*?)"');
				attr = ' ' + type + '="'+ value + '"';
				if (newAttrRegEx.test(attributes)) {
					if (type === 'class') {
						attributes = attributes.replace(newAttrRegEx, function(classAttr, classValue) {
							return ' class="' + classValue + ' ' + value + '"';
						});
					} else {
						attributes = attributes.replace(newAttrRegEx, attr);
					}
				} else {
					attributes += attr;
				}
			}
		}

		return '<' + tagName + attributes + '>' + content + '</' + tagName + '>';
	});
};

(function main() {
	var result,
		tests = [
					'<div data-bind-content="name"></div>'.htmlBind({name: 'JOHN'}),
					'<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>'.htmlBind({name: 'Elena', link: 'http://telerikacademy.com'}),
					'<div data-bind-content="name">PREcontent</div>'.htmlBind({name: 'POSTcontent'}),
					'<div id="The Square" data-bind-style="newStyle" class="shape" data-bind-id="newID" data-bind-class="newClass"></div>'
					.htmlBind({newStyle: 'stylez', newID: 'The Circle', newClass: 'round'}),
					'<div>content</div><a data-bind-id="id"></a>'.htmlBind({id: 'IDETNTITY'})
				];

	for (result of tests) {
		console.log(result);
	}
})();