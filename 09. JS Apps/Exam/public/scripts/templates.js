import $ from 'jquery';
import handlebars from 'handlebars';

var loadedTemplates = {};

export function getTemplate(name) {
	return new Promise(function(resolve, reject) {
		if (loadedTemplates[name]) {
			return resolve(loadedTemplates[name]);
		}

		$.ajax({
			url: '../templates/' + name + '.handlebars',
			method: 'GET',
			contentType: 'text/html',
			success: function(templateStr) {
				var template = handlebars.compile(templateStr);
				loadedTemplates[name] = template;
				resolve(template);
			},
			error: function() {
				reject(new Error('GET template failed.'));
			}
		});
	});
}