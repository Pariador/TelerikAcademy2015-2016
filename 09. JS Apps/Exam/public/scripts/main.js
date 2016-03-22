import $ from 'jquery';
import Sammy from 'Sammy';
import {URLS} from 'CONSTANTS';
import * as homeController from 'homeController';
import * as myCookieController from 'myCookieController';
import {users} from 'database';
import toastr from 'toastr';
import {getTemplate} from 'templates';

var $formContainer = $('#form-container');
var $theForm = $formContainer.children('#the-form');
var $registerBtn = $theForm.children('#register');
var $loginBtn = $theForm.children('#login');

$loginBtn.on('click', function() {
	var username = $theForm.find('#username-input').val();
	var password = $theForm.find('#password-input').val();
	users.login(username, password)
	.then(function(user) {
		toastr.success('Successful login.');
		return Promise.all([getTemplate('logout'), Promise.resolve(user.username)]);
	}, function() {
		toastr.error('Failed login.');
	})
	.then(function(results) {
		var template = results[0];
		var username = results[1];

		var $logOutBtn = $(template(username))
					.appendTo($formContainer)
					.children("#logout");

		$logOutBtn.on('click', function() {
			users.logout()
			.then(function() {
				toastr.success('Successful logout.');
				$logOutBtn.parent().remove();
			}, function() {
				toastr.error('Failed logout.');
			});
		});
	});
});

$registerBtn.on('click', function() {
	var username = $theForm.find('#username-input').val();
	var password = $theForm.find('#password-input').val();

	users.register(username, password)
	.then(function() {
		toastr.success("Successful register.");
	}, function() {
		toastr.error("Failed register.");
	});
});

var sammyApp = Sammy('#content', function() {
	var i, len;
	// Home redirects;
	var redirects = URLS.HOME.REDIRECTS;
	for (i = 0, len = redirects.length; i < len; i+=1) {
		this.get(redirects[i], function() {
			this.redirect('#/home');
		});
	}

	this.get(URLS.HOME.ROOT, homeController.root);

	this.get(URLS.MY_COOKIE.ROOT, myCookieController.root);
});

sammyApp.run(URLS.HOME.ROOT);