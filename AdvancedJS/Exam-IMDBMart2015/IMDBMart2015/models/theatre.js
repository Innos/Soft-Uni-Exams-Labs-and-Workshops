var imdb = imdb || {};

(function(scope){

    var counter = 1;

    var Theatre = (function(){
        function Theatre(title,length,rating,country,isPuppet){
            scope._Movie.call(this,title,length,rating,country);
            this._id = counter++;
            this.isPuppet = isPuppet || false;
        }

        Theatre.extends(scope._Movie);

        return Theatre;
    })();


    scope.getTheatre = function(title,length,rating,country,isPupet){
        return new Theatre(title,length,rating,country,isPupet);
    }
})(imdb);