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
				var genreId,
					genre,
					moviesHtml;

				genreId = parseInt(ev.target.getAttribute('data-id'));
				genre = data.filter(function (genre) {
					return genre._id === genreId;
				})[0];

				moviesHtml = loadMovies(genre.getMovies());
				moviesContainer.innerHTML = moviesHtml.outerHTML;
				var movies = Array.prototype.slice.call(moviesContainer.firstElementChild.childNodes);
				appendDetailListeners(movies,genre,detailsContainer);
				moviesContainer.setAttribute('data-genre-id', genreId);
			}
		});

		// Task 2 - Add event listener for movies boxes

		// Task 3 - Add event listener for delete button (delete movie button or delete review button)
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
			
			moviesUl.appendChild(liMovie);
		});

		return moviesUl;
	}

	function appendDetailListeners(movies,genre,detailsContainer) {
		movies.forEach(function(el){
			el.addEventListener("click",function(){
				var movieId = parseInt(this.getAttribute('data-id'));
				var movie = genre.getMovies().filter(function (movie) {
					return movie._id === movieId;
				})[0];

				var container = document.createElement("div");
				var actors = loadActors(movie.getActors());
				var reviews = loadReviews(movie);
				container.appendChild(actors);
				container.appendChild(reviews);
				detailsContainer.innerHTML = container.innerHTML;
			});
		});
	}

	function loadActors(actors){
		var actorsContainer = document.createElement('section'),
		    title = document.createElement("h2"),
			list = document.createElement("ul");
		title.textContent = "Actors";

		actors.forEach(function (actor) {
			var liActor = document.createElement('li');
			liActor.innerHTML = '<h4>' + actor.name + '</h4>';
			liActor.innerHTML += '<div><strong>Bio</strong>: ' + actor.bio + '</div>';
			liActor.innerHTML += '<div><strong>Born</strong>: ' + actor.born + '</div>';
			list.appendChild(liActor);
		});
		actorsContainer.appendChild(title);
		actorsContainer.appendChild(list);

		return actorsContainer;
	}

	function loadReviews(movie){
		var reviews = movie.getReviews();
		var reviewsContainer = document.createElement('section'),
			title = document.createElement("h2"),
			list = document.createElement("ul");
		title.textContent = "Reviews";

		reviews.forEach(function (review) {
			var liReview = document.createElement('li');
			liReview.innerHTML = '<h4>' + review.author + '</h4>';
			liReview.innerHTML += '<div>Bio: ' + review.content + '</div>';
			liReview.innerHTML += '<div>Born: ' + review.date + '</div>';
			var button = document.createElement('button');
            button.innerHTML = 'Delete Review';
            //console.log(button);
            button.addEventListener('click', function() {
                console.log('asdasd')
            });
			liReview.appendChild(button);
			list.appendChild(liReview);
		});
		reviewsContainer.appendChild(title);
		reviewsContainer.appendChild(list);

		return reviewsContainer;
	}

	scope.loadHtml = loadHtml;
}(imdb));