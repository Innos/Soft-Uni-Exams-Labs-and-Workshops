(function (imdb) {
	'use strict';
	imdb.generateData();
	var genres = imdb.getGenres();

	imdb.loadHtml('#genres', genres);

	console.log(genres);
}(imdb));