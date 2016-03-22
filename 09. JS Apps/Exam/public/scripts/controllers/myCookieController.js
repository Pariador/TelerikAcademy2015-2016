import {getTemplate} from 'templates';
import {cookies, users} from 'database';
import {URLS} from 'CONSTANTS';
import toastr from 'toastr';
import $ from 'jquery';


export function root() {
	var self = this;
	cookies.getMyCookie()
	.then(function(cookie) {
		self.$element().html('');
		self.$element().html(JSON.stringify(cookie));
	}, function() {
		self.redirect(URLS.HOME.ROOT);
		toastr.error('You must be logged in to see your cookie.');
	});
}