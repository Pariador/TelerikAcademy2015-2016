// Problem 8. Replace tags
// Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…[/URL].

function replaceAnchors(html) {
	return html.replace(/<a.*?(?:href\s*=\s*(".*").*?)?>(.*?)<\/a>/g, function() {
		var result = '[URL';

		if (arguments[1]) {
			result += '=' + arguments[1];
		}

		return result + ']' + arguments[2] + '[/URL]';
	});
}

(function main() {
	var result,
		example = document.getElementById('example').innerHTML.trim();

	console.log(replaceAnchors(example));
})();