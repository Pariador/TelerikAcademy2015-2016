function solve() {
	return function(selector, isCaseSensitive) {
		var i,
			len,
			container = document.querySelector(selector),
			addControls = document.createElement('div'),
			searchControls = document.createElement('div'),
			resultControls = document.createElement('div');

		container.className = 'items-control';

		addControls.className = 'add-controls';
		container.appendChild(addControls);

		searchControls.className = 'search-controls';
		container.appendChild(searchControls);

		resultControls.className = 'result-controls';
		container.appendChild(resultControls);

		var itemsList = document.createElement('div');
		itemsList.className = 'items-list';

		resultControls.appendChild(itemsList);


		addControls.innerHTML += '<label>Enter text</label>';
		var addInput = document.createElement('input');
		addControls.appendChild(addInput);
		var addButton = document.createElement('button');
		addButton.className = 'button';
		addButton.innerHTML = 'Add';
		addControls.appendChild(addButton);

		addButton.addEventListener('click', function(info) {
			var listItem = document.createElement('div');

			listItem.className = 'list-item';
			listItem.innerHTML = '<span class="text-content">' + addInput.value + '</span>';

			var removeButton = document.createElement('button');
			removeButton.className = 'button';
			removeButton.innerHTML = 'X';
			removeButton.addEventListener('click', function(info) {
				this.parentElement.remove();
			} , false);

			listItem.appendChild(removeButton);

			itemsList.appendChild(listItem);
		}, false)

		searchControls.innerHTML += '<label>Search</label>';
		var searchInput = document.createElement('input');
		searchControls.appendChild(searchInput);

		searchInput.addEventListener('change', function() {
			var i,
				len,
				html,
				value
				items = itemsList.getElementsByClassName('list-item');

			for (i = 0, len = items.length; i < len; i+=1) {
				value = this.value;
				html = items[i].getElementsByClassName('text-content')[0].innerHTML;

				if ((isCaseSensitive !== undefined) && !isCaseSensitive) {
					value = value.toLowerCase();
					html = html.toLowerCase();
				}

				if (html.indexOf(value) === -1) {
					items[i].style.display = 'none';
				} else {
					items[i].style.display = '';
				}
			}
		} , false);
	}
}

// module.exports = solve;