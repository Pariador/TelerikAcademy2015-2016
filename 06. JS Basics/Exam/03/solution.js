function solve(input) {
	var i,
		j,
		len,
		match,
		statement,
		props,
		statements = [],
		statRegEx = /([^]*?)\s*\{([^]*?)\}/g,
		propRegEx = /(\S+)\s*:\s*(\S+)\s*;/g,
		input = input.map(function(line){return line.trim();}).join(''),
		result = '';

	for (;;) {
		match = statRegEx.exec(input);

		if (match === null) {
			break;
		}

		statement = {selector: match[1].replace(/\s*([>~+])\s*/g, function(match, sign){return sign;}).replace(/\s+/g, ' '), properties: match[2].trim()};

		statements.push(statement);
	}

	for (statement of statements) {
		props = [];

		for (;;) {
			match = propRegEx.exec(statement.properties);

			if (match === null) {
				break;
			}

			props.push({name: match[1].trim(), value: match[2].trim()});
		}

		statement.properties = props;

	}

	for (i = 0, len = statements.length; i < len - 1; i+=1) {
		if (statements[i] === null) {
			continue;
		}

		for (j = i + 1; j < len; j+=1) {
			if (statements[j] === null) {
				continue;
			}

			if (statements[i].selector === statements[j].selector) {
				statements[i].properties = statements[i].properties.concat(statements[j].properties);
				// debugger;
				statements[j] = null;
			}
		}
	}

	statements = statements.filter(function(st){return st !== null;});

	for (statement of statements) {
		for (i = statement.properties.length - 1; i >= 1; i-=1) {
			if (statement.properties[i] === null) {
				continue;
			}

			for (j = i - 1; j >= 0; j-=1) {
				if (statement.properties[j] === null) {
					continue;
				}

				if (statement.properties[i].name === statement.properties[j].name) {
					statement.properties[j] = null;
				}
			}
		}
		statement.properties = statement.properties.filter(function(prp){return prp !== null;});
	}
	// debugger;
	statements = statements.map(function(st) {
		var prop,
			result = '' + st.selector + '{';

		// When changed with a normal for loop something goes wrong. O_O
		for (prop of st.properties) {
			result += prop.name + ':' + prop.value + ';';
		}

		return result += '}';
	});

	result = statements.join('');
	// result = result.substr(0, result.length - 2) + '}';
	result = result.replace(/\;\}/g, '}');
	debugger;
	return result;
}

// (function tests() {
// 	var i,
// 		len,
// 		result,
// 		tests = [
// 					[
// 						'#the-big-b{',
// 						' color: yellow;',
// 						' size: big;',
// 						'}',
// 						'.muppet{',
// 						' powers: all;',
// 						' skin: fluffy;',
// 						'}',
// 						' .water-spirit {',
// 						' powers: water;',
// 						' alignment : not-good;',
// 						'}',
// 						'all{',
// 						' meant-for: nerdy-children;',
// 						'}',
// 						'.muppet {',
// 						'powers: everything;',
// 						'}',
// 						'all .muppet {',
// 						'alignment : good ;',
// 						'}',
// 						' .muppet+ .water-spirit{',
// 						' power: everything-a-muppet-can-do-and-water;',
// 						'}'
// 					]
// 				];

// 	for (i = 0, len = tests.length; i < len; i+=1) {
// 		if (false) {debugger;}
// 		result = solve(tests[i]);

// 		console.log('----------------------------------\nTest ' + i + ':\n' + result);
// 	}
// })();