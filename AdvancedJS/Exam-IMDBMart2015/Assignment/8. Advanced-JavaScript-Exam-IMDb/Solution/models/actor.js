var imdb = imdb || {};

(function (scope) {
	'use strict';
	
	var id = 0;
	function Actor(name, bio, born) {
		this._id = ++id;
		this.name = name;
		this.bio = bio;
		this.born = born;
	}

	scope.getActor = function (name, bio, born) {
		return new Actor(name, bio, born);
	};
}(imdb));