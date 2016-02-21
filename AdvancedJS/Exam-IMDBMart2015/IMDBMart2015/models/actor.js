var imdb = imdb || {};

(function(scope){

    var counter = 1;

    var Actor = (function(){
        function Actor(name,bio,born){
            this._id = counter++;
            this.name = name;
            this.bio = bio;
            this.born = born;
        }
        return Actor;
    })();

    scope.getActor = function(name,bio,born){
        return new Actor(name,bio,born);
    }
})(imdb);