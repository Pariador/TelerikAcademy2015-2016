import $ from 'jquery';
import CryptoJS from 'CryptoJS';
import {SERVER_URLS, CURRENT_USER_KEY} from 'CONSTANTS';

var cookies = {
	getAllCookies: function() {
		return new Promise(function(resolve, reject) {
			$.ajax({
				url: SERVER_URLS.COOKIES.ROOT,
				contentType: 'application/json',
				success: function(resopnse) {
					resolve(resopnse.result);
				},
				error: function() {
					reject(new Error('Failed to get cookies'));
				}
			});
		});
	},
	getMyCookie: function() {
		return new Promise(function(resolve, reject) {
			var currentUser = getCurrentUser();
			if (currentUser === null) {
				reject(new Error("User not logged in."));
			}

			var authKey = getCurrentUser().authKey;
			$.ajax({
				url: SERVER_URLS.COOKIES.MY_COOKIE,
				contentType: 'application/json',
				headers: {"x-auth-key": authKey},
				success: function(response) {
					resolve(response.result);
				},
				error: function() {
					reject(new Error('Getting my cookie failed.'));
				}
			});
		});
	},
	shareCookie: function(cookie) {
		return new Promise(function(resolve, reject) {
			var authKey = getCurrentUser().authKey;
			$.ajax({
				url: SERVER_URLS.COOKIES.ROOT,
				method: 'POST',
				contentType: 'application/json',
				headers: {"x-auth-key": authKey},
				data: JSON.stringify(cookie),
				success: function(response) {
					resolve(response.result);
				},
				error: function() {
					reject(new Error('Failed to share cookie.'));
				}
			});
		});
	},
	rateCookie: function(liked ,id) {
		var type;
		if (liked) {
			type = 'like';
		} else {
			type = 'dislike';
		}

		var authKey = getCurrentUser().authKey;
		return new Promise(function(resolve, reject) {
			$.ajax({
				url: SERVER_URLS.COOKIES.ROOT + '/' + id,
				method: 'PUT',
				contentType: 'application/json',
				headers: {"x-auth-key": authKey},
				data: JSON.stringify({type: type}),
				success: function(response) {
					resolve(response.result);
				},
				error: function() {
					reject(new Error('Failed to rate cookie.'));
				}
			});
		});
	},
	getAllCategories: function() {
		return new Promise(function(resolve, reject) {
			$.ajax({
				url: SERVER_URLS.COOKIES.CATEGORIES,
				method: 'GET',
				contentType: 'application/json',
				success: function(response) {
					resolve(response.result);
				},
				error: function() {
					reject(new Error('Failed to get categories.'));
				}
			});
		});
	}
};


localStorage.setItem(CURRENT_USER_KEY, JSON.stringify(null));

function setCurrentUser(user) {
	localStorage.setItem(CURRENT_USER_KEY, JSON.stringify(user));
}

function getCurrentUser() {
	var userJSON = localStorage.getItem(CURRENT_USER_KEY);
	return JSON.parse(userJSON);
}

var users = {
	getAll: function() {
		return new Promise(function(resolve, reject) {
			$.ajax({
				url: SERVER_URLS.USERS.ROOT,
				contentType: 'application/json',
				success: function(users) {
					resolve(users);
				},
				error: function() {
					reject(new Error('Getting users failed.'));
				}
			});
		});
	},
	register: function(username, password) {
		return new Promise(function(resolve, reject) {
			var passHash = CryptoJS.SHA1(password).toString();

			$.ajax({
				url: SERVER_URLS.USERS.ROOT,
				method: 'POST',
				contentType: 'application/json',
				data: JSON.stringify({username: username, passHash: passHash}),
				success: function(response) {
					resolve(response.result.username);
				},
				error: function() {
					reject(new Error('Failed to register user.'));
				}
			});
		});
	},
	login: function(username, password) {
		return new Promise(function(resolve, reject) {
			var passHash = CryptoJS.SHA1(password).toString();

			$.ajax({
				url: SERVER_URLS.USERS.LOGIN,
				method: 'PUT',
				contentType: 'application/json',
				data: JSON.stringify({username: username, passHash: passHash}),
				success: function(response) {
					setCurrentUser(response.result);
					resolve(response.result);
				},
				error: function() {
					reject(new Error('Failed to login user.'));
				}
			});
		});
	},
	logout: function() {
		return new Promise(function(resolve, reject) {
			setCurrentUser(null);
			resolve();
		});
	},
	getCurrentUser: function() {
		return Promise.resolve(getCurrentUser());
	}
};

export {cookies, users};