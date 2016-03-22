function solve(input) {
	var i,
		c,
		len,
		leftIndex,
		rightIndex,
		resultNum,
		newNums,
		firstLine = input[0].split(' '),
		numCount = +firstLine[0],
		transforms = +firstLine[1],
		numbers = input[1].split(' ').map(function(str){return +str;});

	for (c = 0; c < transforms; c+=1) {
		newNums = [];

		for (i = 0; i < numCount; i+=1) {
			debugger;
			// get Left/Right
			if (!i) {
				leftIndex = numCount - 1;
			} else {
				leftIndex = i - 1;
			}

			if (i === numCount - 1) {
				rightIndex = 0;
			} else {
				rightIndex = i + 1;
			}

			// -------
			if (!numbers[i]) {
				resultNum = Math.abs(numbers[leftIndex] - numbers[rightIndex]);
			} else if (numbers[i] === 1) {
				resultNum = numbers[leftIndex] + numbers[rightIndex];
			} else if (numbers[i] % 2) {
				resultNum = Math.min(numbers[leftIndex], numbers[rightIndex]);
			} else {
				resultNum = Math.max(numbers[leftIndex], numbers[rightIndex]);
			}

			newNums.push(resultNum);
		}

		numbers = newNums;
	}

	return numbers.reduce(function(sum, number) {
		return sum += number;
	}, 0);
}

// (function tests() {
// 	var i,
// 		len,
// 		result,
// 		tests = [
// 					[
// 						'5 1',
// 						'9 0 2 4 1'
// 					],
// 					[
// 						'10 3',
// 						'1 9 1 9 1 9 1 9 1 9'
// 					],
// 					[
// 						'10 10',
// 						'0 1 2 3 4 5 6 7 8 9'
// 					]
// 				];

// 	for (i = 0, len = tests.length; i < len; i+=1) {
// 		if (false) {debugger;}
// 		result = solve(tests[i]);

// 		console.log('----------------------------------\nTest ' + i + ':\n' + result);
// 	}
// })();