var imdb = imdb || {};

(function (scope) {
	'use strict';
	
	var id = 0;
	function Review(author, content, date) {
		this._id = ++id;
		this.author = author;
		this.content = content;
		this.date = date;
	}

	scope.getReview = function (author, content, date) {
		return new Review(author, content, date);
	};
}(imdb));