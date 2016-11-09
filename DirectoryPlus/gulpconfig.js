module.exports = {    
    gitbranch: 'Master',
	isProduction: process.env.NODE_ENV === 'production', //From Windows command line:SET NODE_ENV=production. MAC: EXPORT NODE_ENV=production
	webroot: './',
	scssSource: './components/scss/main.scss',
	cssFileName: 'directory.css',
	jsSource: [
        './components/scripts/directory.base.js',      
		'./components/scripts/directory.onready.js',       
	],
	jsFileName: 'directory.js',
    banner: ['/**',
            ' * <%= package.name %> - <%= package.description %>',
            ' * @version v<%= package.version %>',
            ' * @link <%= package.repository.url %>',
            ' * @author <%= package.author %>',
            ' * Copyright ' + new Date().getFullYear() + '. <%= package.license %> licensed.',
            ' * Built: ' + new Date() + '.',
            ' */',
            ''
    ].join('\n')
};
