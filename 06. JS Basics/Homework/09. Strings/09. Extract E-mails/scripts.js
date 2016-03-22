// Problem 9. Extract e-mails
// Write a function for extracting all email addresses from given text.
// All sub-strings that match the format @… should be recognized as emails.
// Return the emails as array of strings.

function extractEmails(text) {
	return text.match(/\S+@\S+/g);
}

(function main() {
	var text = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse scelerisque sapien orci, nec convallis abapirry-2582@yopmail.com ipsum convallis nec. Etiam efficitur convallis augue eleifend ornare. uwepemmule-4227@yopmail.com Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque ac ubigelonne-2869@yopmail.com sapien sit amet enim mollis aliquam. Maecenas semper laoreet risus eget ultrices. In massa neque, vulputate ac mi in, blandit pulvinar neque.';

	console.log(extractEmails(text));
})();