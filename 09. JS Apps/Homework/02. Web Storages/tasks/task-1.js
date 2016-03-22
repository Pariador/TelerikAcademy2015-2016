function solve() {
	var SCORES_STORAGE_NAME = 'shipsHighScores',
		player = {},
		endCallback,
		secretNumber,
		gameReady = false;

	function saveScores(scores) {
		window.localStorage.setItem(SCORES_STORAGE_NAME, JSON.stringify(scores));
	}

	function loadScores() {
		var scoresStr = window.localStorage.getItem(SCORES_STORAGE_NAME);

		if (scoresStr === null) {
			return [];
		}

		var scoresArr = JSON.parse(scoresStr);

		return scoresArr;
	}

	function init(playerName, endCallbackParam) {
		player.name = playerName;
		player.score = 0;

		endCallback = endCallbackParam;

		secretNumber = '' + (((Math.random() * 9000) + 1000) | 0);
		console.log(secretNumber);

		gameReady = true;
	}

	function end() {
		var highScores = loadScores();

		highScores.push(player);

		saveScores(highScores);

		gameReady = false;

		if (typeof(endCallback) === 'function') {
			endCallback();
		}
	}

	function guess(number) {
		if (!gameReady) {
			throw new Error('A new game must be initialized before guess() call.');
		}

		var i,
			len,
			numberStr = '' + number,
			result = {
				sheep: 0,
				rams: 0
			};

		for (i = 0; i < 4; i+=1) {
			for (j = 0; j < 4; j+=1) {
				// debugger;
				if (numberStr[i] === secretNumber[j]) {
					if (i === j) {
						result.rams += 1;
					} else {
						result.sheep += 1;
					}
				}
			}
		}

		if (result.rams === 4) {
			end();
		}

		player.score += 1;

		return result;
	}

	return {
		init: init,
		guess: guess,
		save: saveScores,
		getHighScores: loadScores
	};
}

(function main() {
	var game = solve(),
		playerIndex = 0,
		input = document.getElementById('input'),
		output = document.getElementById('output'),
		guess = document.getElementById('guess'),
		start = document.getElementById('start'),
		scores = document.getElementById('scores');

	start.onclick = function() {
		var inputStr = input.value;

		if (inputStr === '') {
			inputStr = 'Player[' + playerIndex + ']';
			playerIndex+=1;
		}

		game.init(inputStr);
	}
	// start.onclick();

	scores.onclick = function() {
		var scores = game.getHighScores();

		output.innerHTML = JSON.stringify(scores);
	}

	guess.onclick = function() {
		var inputStr = input.value,
			result,
			outputStr;

		try {
			result = game.guess(inputStr);

			outputStr = JSON.stringify(result);
		} catch(err) {
			outputStr = err.message;
			debugger;
		}

		output.innerHTML = outputStr;
	}
})();

// module.exports = solve;