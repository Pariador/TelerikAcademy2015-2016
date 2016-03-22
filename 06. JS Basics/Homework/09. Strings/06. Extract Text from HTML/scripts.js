// Problem 6. Extract text from HTMLa
// Write a function that extracts the content of a html page given as text.
// The function should return anything that is in a tag, without the tags.

function pageToText() {
	var result = document.documentElement.outerHTML;

	result = result.replace(/<.*?>/g, '');
	result = result.replace(/\s+/g, ' ');

	return result;
}

(function main() {
	console.log(pageToText());
})();