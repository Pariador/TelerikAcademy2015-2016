/* Task Description */
/*
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, !(author) and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error


var book = {
	title: 'TITLE',
	isbn: 'ISBN',
	author: 'AUTHOR',
	category: 'CATEGORY'
};
*/

function solve() {
	var library = (function () {
		var books = [],
			categories = [];

		function validateLength(book, prop) {
			if (book[prop].length < 2 || book[prop].length > 100) {
				throw new Error('Invalid book ' + prop + ' length.');
			}
		}

		function uniqueBookProp(book, prop) {
			var fail = books.some(function(otherBook) {
				return otherBook[prop] === book[prop];
			});

			if (fail) {
				throw new Error('Book ' + prop + ' must be unique.');
			}
		}

		function listBooks(filter) {
			var prop;

			if (typeof(filter) === 'object') {
				for (prop in filter) {
					return books.filter(function(book){
						return book[prop] === filter[prop];
					});
				}
			}

			return books.slice(0);
		}

		function addBook(book) {
			var isbnLen;

			// Check title.
			validateLength(book, 'title');
			uniqueBookProp(book, 'title');

			// Check category.
			validateLength(book, 'category');

			// Check author.
			if (book.author === '') {
				throw new Error('Must specify book author.');
			}

			// Check ISBN
			isbnLen = book.isbn.length;
			if (isbnLen !== 10 && isbnLen !== 13) {
				throw new Error('ISBN length must be either 10 or 13 digits.');
			}
			uniqueBookProp(book, 'isbn');

			book.ID = books.length + 1;
			books.push(book);

			if (!categories.some(function(cat){return cat === book.category;})) {
				categories.push(book.category);
			}

			return book;
		}

		function listCategories() {
			return categories.slice(0);
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}

module.exports = solve;