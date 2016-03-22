// Problem 7. Parse URL
// Write a script that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
// Return the elements in a JSON object.

// Example:
// URL	result
// http://telerikacademy.com/Courses/Courses/Details/239	{ protocol: http,
// server: telerikacademy.com
// resource: /Courses/Courses/Details/239

function parseURL(url) {
	var regex = /^(.*):\/\/(?:(.*?)(?:(\/.*$)|$))/g,
		result = regex.exec(url);

	return {
		protocol: result[1],
		server: result[2],
		resourse: result[3] === undefined? null : result[3]
	}
}

(function main() {
	var firstUrl = 'http://telerikacademy.com/Courses/Courses/Details/239',
		secondUrl = 'http://telerikacademy.com';

	console.log(parseURL(firstUrl));
	console.log(parseURL(secondUrl));
})();