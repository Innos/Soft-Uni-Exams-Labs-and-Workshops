var imdb = imdb || {};

(function (scope) {
	function loadHtml(selector, data) {
		var container = document.querySelector(selector),
			moviesContainer = document.getElementById('movies'),
			detailsContainer = document.getElementById('details'),
			genresUl = loadGenres(data);
		
		container.appendChild(genresUl);

		genresUl.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI') {
				var genre,
					genreId,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});

		moviesContainer.addEventListener('click', function (ev) {
			if (ev.target.tagName === 'LI' || ev.target.parentElement.tagName === 'LI') {
				var movie,
					movieId,
					movieIdStr,
					detailsHtml;

				movieIdStr = ev.target.getAttribute('data-id') || ev.target.parentElement.getAttribute('data-id');
				movieId = parseInt(movieIdStr);
				

				movie = getMovieById(data, movieId);
				
				detailsContainer.setAttribute('data-movie-id', movieId);
				detailsHtml = loadDetails(movie.getActors(), movie.getReviews());
				detailsContainer.innerHTML = detailsHtml.outerHTML;
			}
		});

		moviesContainer.addEventListener('click', function (ev) {
			if (ev.target.getAttribute('class').indexOf('delete-movie') > -1) {
				var genre,
					genreId,
					movieId,
					movieLi;
				
				movieId = parseInt(ev.target.getAttribute('data-id'));
				genreId = parseInt(moviesContainer.getAttribute('data-genre-id'));

				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];
				genre.deleteMovieById(movieId);

				// Remove movie from DOM
				movieLi = ev.target.parentElement;
				movieLi.parentElement.removeChild(movieLi);

				ev.stopPropagation();
			}
		})

		detailsContainer.addEventListener('click', function (ev) {
			if (ev.target.getAttribute('class').indexOf('delete') > -1) {
				var movie,
					movieId,
					reviewId,
					reviewLi;

				movieId = parseInt(detailsContainer.getAttribute('data-movie-id'));
				reviewId = parseInt(ev.target.getAttribute('data-id'));

				movie = getMovieById(data, movieId);
				movie.deleteReviewById(reviewId);

				// Remove review from DOM
				reviewLi = ev.target.parentElement;
				reviewLi.parentElement.removeChild(reviewLi);
			}
		});

		var detailsContainer = document.querySelector('#details');
	}

	function getMovieById(data, movieId) {
		var movies = [],
			moviesArr,
			movie;

		moviesArr = data.map(function (genre) {
			return genre._movies;
		});

		moviesArr.forEach(function (mArr) {
			movies = movies.concat(mArr);
		});

		movie = movies.filter(function (movie) {
			return movie._id === movieId;
		})[0];

		return movie;
	}

	function loadGenres(genres) {
		var genresUl = document.createElement('ul');
		genresUl.setAttribute('class', 'nav navbar-nav');
		genres.forEach(function (genre) {
			var liGenre = document.createElement('li');
			liGenre.innerHTML = genre.name;
			liGenre.setAttribute('data-id', genre._id);
			genresUl.appendChild(liGenre);
		});

		return genresUl;
	}

	function loadMovies(movies) {
		var moviesUl = document.createElement('ul');
		movies.forEach(function (movie) {
			var liMovie = document.createElement('li');
			liMovie.setAttribute('data-id', movie._id);

			liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
			liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
			liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
			liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
			liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
			liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';
			liMovie.innerHTML += '<button class="delete-movie" data-id="' + movie._id + '">Delete movie</button>';

			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	function loadDetails(actors, reviews) {
		var div,
			actorsHtmlTag,
			reviewsHtmlTag;
		div = document.createElement('div');
		div.innerHTML += '<h2>Actors</h2>';
		actorsHtmlTag = getActors(actors);
		div.appendChild(actorsHtmlTag);
		div.innerHTML += '<h2>Reviews</h2>';
		reviewsHtmlTag = getReviews(reviews);
		div.appendChild(reviewsHtmlTag);

		return div;
	}

	function getActors(actors) {
		var actorsUl = document.createElement('ul');
		actors.forEach(function (actor) {
			var liActor = document.createElement('li');
			liActor.setAttribute('data-id', actor._id);

			liActor.innerHTML = '<h4>' + actor.name + '</h4>';
			liActor.innerHTML += '<div><strong>Bio:</strong> ' + actor.bio + '</div>';
			liActor.innerHTML += '<div><strong>Born:</strong> ' + actor.born + '</div>';

			actorsUl.appendChild(liActor);
		});

		return actorsUl;
	}

	function getReviews(reviews) {
		var reviewsUl = document.createElement('ul');
		reviews.forEach(function (review) {
			var liReview = document.createElement('li');
			liReview.setAttribute('data-id', review._id);

			liReview.innerHTML = '<h4>' + review.author + '</h4>';
			liReview.innerHTML += '<div>Bio: ' + review.content + '</div>';
			liReview.innerHTML += '<div>Born: ' + review.date + '</div>';
			liReview.innerHTML += '<button class="delete" data-id="' + review._id + '">Delete review</button>';

			reviewsUl.appendChild(liReview);
		});

		return reviewsUl;
	}

	scope.loadHtml = loadHtml;
}(imdb));