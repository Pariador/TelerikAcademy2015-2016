/*
Create a function that:
*   **Takes** a collection of books
    *   Each book has propeties `title` and `author`
        **  `author` is an object that has properties `firstName` and `lastName`
*   **finds** the most popular author (the author with biggest number of books)
*   **prints** the author to the console
	*	if there is more than one author print them all sorted in ascending order by fullname
		*   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {
	return function(books) {
		function getFullName(author) {
			return author.firstName + ' ' + author.lastName;
		}

		var bookCountsByAuthor = _.chain(books)
								.groupBy(function(book) {
									return getFullName(book.author);
								})
								.mapObject(function(books) {
									return books.length;
								})
								.value();

		var maxBooksCount = _.max(bookCountsByAuthor);

		var mostPopularAuthors = [];
		_.each(bookCountsByAuthor, function(bookCount, author) {
			if (bookCount === maxBooksCount) {
				mostPopularAuthors.push(author);
			}
		});

		_.chain(mostPopularAuthors)
		.sortBy()
		.each(function(author) {
			console.log(author);
		});
	}
}

module.exports = solve;
