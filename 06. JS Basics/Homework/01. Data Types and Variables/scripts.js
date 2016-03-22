var allTheLiterals = [
						1,
						NaN,
						3.14,
						'I am a string! Deal with it.',
						undefined,
						Infinity,
						null,
						['An', 'array', 'of', 'strings.'],
						{ firstName: 'Simple', lastName: 'Obj'}
					];

var stringsWithQuotes = [ "Don't.",
						'Can\'t.',
						'"Look behind you.", she said.',
						"\"Are you serious?\", said I."
						];

console.log('All Literals:');
for(var variable of allTheLiterals) {
	console.log(variable);
}

console.log('\ntypeof on all literals:');
for(var variable of allTheLiterals) {
	console.log(typeof(variable));
}

console.log('\nStrings with quotes:');
for(var str of stringsWithQuotes) {
	console.log(str);
}