var imdb = imdb || {};

(function (scope) {
	'use strict';
	
	var id = 0;
	function Movie(title, length, rating, country) {
		this._id = ++id;
		this.title = title;
		this.length = length;
		this.rating = rating;
		this.country = country;
		this._actors = [];
		this._reviews = [];
	}

	Movie.prototype.addActor = function (actor) {
		this._actors.push(actor);
	}

	Movie.prototype.getActors = function () {
		return this._actors;
	}

	Movie.prototype.addReview = function (review) {
		this._reviews.push(review);
	}

	Movie.prototype.deleteReview = function (review) {
		var index = this._reviews.indexOf(review);
		this._reviews.splice(index, 1);
	}

	Movie.prototype.deleteReviewById = function (reviewId) {
		var review = this._reviews.filter(function (review) {
			return review._id === reviewId;
		});

		this.deleteReview(review);
	}

	Movie.prototype.getReviews = function () {
		return this._reviews;
	}

	scope._Movie = Movie;
	scope.getMovie = function (name, length, rating, country) {
		return new Movie(name, length, rating, country);
	};
}(imdb));