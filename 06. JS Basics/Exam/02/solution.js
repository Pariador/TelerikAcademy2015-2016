function solve(input) {
	var i,
		len,
		startRow,
		startCol,
		endRow,
		endCol,
		figure,
		results = [],
		rows = +input[0],
		cols = +input[1],
		board = input.splice(2, rows).map(function(line){return line.split('');}),
		movesCount = +input[2],
		moves = input.slice(3).map(function(line){return line.split(' ');});
		moveBishop = function() {
			var curR = startRow,
				curC = startCol;

			while (1) {
				curR -= 1;
				curC -= 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			curR = startRow;
			curC = startCol;
			while (1) {
				curR -= 1;
				curC += 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			curR = startRow;
			curC = startCol;
			while (1) {
				curR += 1;
				curC += 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			curR = startRow;
			curC = startCol;
			while (1) {
				curR += 1;
				curC -= 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			return false;
		}
		moveRook = function() {
			var curR = startRow,
				curC = startCol;

			if ((startRow !== endRow) && (startCol !== endCol)) {
				return false;
			}

			while (1) {
				curR -= 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			curR = startRow;
			curC = startCol;
			while (1) {
				curC += 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			curR = startRow;
			curC = startCol;
			while (1) {
				curR += 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			curR = startRow;
			curC = startCol;
			while (1) {
				curC -= 1;

				if ((curR < 0) || (curR >= rows) || (curC < 0) || (curC >= cols)) {
					break;
				}

				if (board[curR][curC] !== '-') {
					break;
				}

				if (curR === endRow && curC === endCol) {
					return true;
				}

			}

			return false;
		}

		for (i = 0; i < movesCount; i+=1) {
			startRow = (rows - 1) - (+moves[i][0][1] - 1);
			startCol = moves[i][0].charCodeAt(0) - 97;

			endRow = (rows - 1) - (+moves[i][1][1] - 1);
			endCol = moves[i][1].charCodeAt(0) - 97;

			figure = board[startRow][startCol];

			// debugger;
			switch (figure) {
				case 'R':
						if (moveRook()) {
							results.push('yes');

							// board[startRow][startCol] = '-';
							// board[endRow][endCol] = 'R';
						} else {
							results.push('no');
						}
				break;
				case 'B':
						if (moveBishop()) {
							results.push('yes');

							// board[startRow][startCol] = '-';
							// board[endRow][endCol] = 'B';

						} else {
							results.push('no');
						}
				break;
				case 'Q':
						if (moveRook() || moveBishop()) {
								results.push('yes');

							// board[startRow][startCol] = '-';
							// board[endRow][endCol] = 'Q';
						} else {
								results.push('no');
						}
				break;
				default:  results.push('no');
				// debugger;
			}
		}
		return results.join('\n');
}

// (function tests() {
// 	var i,
// 		len,
// 		result,
// 		tests = [
// 					[
// 						'3',
// 						'4',
// 						'--R-',
// 						'B--B',
// 						'Q--Q',
// 						'12',
// 						'd1 b3',
// 						'a1 a3',
// 						'c3 b2',
// 						'a1 c1',
// 						'a1 b2',
// 						'a1 c3',
// 						'a2 b3',
// 						'd2 c1',
// 						'b1 b2',
// 						'c3 b1',
// 						'a2 a3',
// 						'd1 d3'
// 					],
// 					[
// 						'5',
// 						'5',
// 						'Q---Q',
// 						'-----',
// 						'-B---',
// 						'--R--',
// 						'Q---Q',
// 						'10',
// 						'a1 a1',
// 						'a1 d4',
// 						'e1 b4',
// 						'a5 d2',
// 						'e5 b2',
// 						'b3 d5',
// 						'b3 a2',
// 						'b3 d1',
// 						'b3 a4',
// 						'c2 c5'
// 					]
// 				];

// 	for (i = 0, len = tests.length; i < len; i+=1) {
// 		if (false) {debugger;}
// 		result = solve(tests[i]);

// 		console.log('----------------------------------\nTest ' + i + ':\n' + result);
// 	}
// })();