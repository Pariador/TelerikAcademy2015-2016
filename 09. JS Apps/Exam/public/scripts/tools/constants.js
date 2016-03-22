var URLS = {
	HOME: {
		ROOT: '#/home',
		REDIRECTS: ['#/']
	},
	MY_COOKIE: {
		ROOT: '#/my-cookie'
	}
};

var SERVER_URLS = {
	COOKIES: {
		ROOT: 'api/cookies',
		MY_COOKIE: 'api/my-cookie',
		CATEGORIES: 'api/categories'
	},
	USERS: {
		ROOT: 'api/users',
		LOGIN: 'api/auth'
	}
};

var CURRENT_USER_KEY = 'COOKIE_APP_CURRENT_USER';

export {URLS, SERVER_URLS};