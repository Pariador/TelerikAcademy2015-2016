// You are given a text. Write a function that changes the text in all regions:
// <upcase>text</upcase> to uppercase.
// <lowcase>text</lowcase> to lowercase
// <mixcase>text</mixcase> to mix casing(random)

// Example: We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.

// The expected result:
// We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.
// Note: Regions can be nested.

function changeText(text) {
	var i,
		len,
		changed,
		match,
		upcase = text.match(/<upcase>([\s\S]*?)<\/upcase>/g),
		lowcase = text.match(/<lowcase>([\s\S]*?)<\/lowcase>/g),
		mixcase = text.match(/<mixcase>([\s\S]*?)<\/mixcase>/g);

	for (match of upcase) {
		changed = match.substring(8, match.length - 9).toUpperCase();
		text = text.replace(match, changed);
	}

	for (match of lowcase) {
		changed = match.substring(9, match.length - 10).toLowerCase();
		text = text.replace(match, changed);
	}

	for (match of mixcase) {
		changed = '';
		for (i = 9, len = match.length; i < len - 10; i+=1) {
			if (i % 2) {
				changed += match[i].toLowerCase();
			} else {
				changed += match[i].toUpperCase();
			}
		}

		text = text.replace(match, changed);
	}

	return text;
}

(function main() {
	var result,
		example = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYTHING</lowcase> else.";

	result = changeText(example);

	console.log(result);
})();