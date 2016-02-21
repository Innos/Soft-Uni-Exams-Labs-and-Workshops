var imdb = imdb || {};

(function(scope){

    var counter = 1;

    var Genre = (function(){
        function Genre(name){
            this._id = counter++;
            this.name = name;
            this._movies = [];
        }

        Genre.prototype.addMovie = function(movie){
            this._movies.push(movie);
        };

        Genre.prototype.deleteMovie = function(movie){
            var index = this._movies.indexOf(movie);
            this._movies.splice(index,1);
        };

        Genre.prototype.deleteMovieById = function(id){
            this._movies = this._movies.filter(function(el){
                return el._id !== id;
            })
        };

        Genre.prototype.getMovies = function(){
            return this._movies;
        };

        return Genre;
    })();


    scope.getGenre = function(name){
        return new Genre(name);
    }
})(imdb);
