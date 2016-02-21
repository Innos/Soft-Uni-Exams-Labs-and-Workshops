var imdb = imdb || {};

(function(scope){

    var counter = 1;

    var Review = (function(){
        function Review(author,content,date){
            this._id = counter++;
            this.author = author;
            this.content = content;
            this.date = date;
        }

        return Review;
    })();

    scope.getReview = function(author,content,date){
        return new Review(author,content,date);
    }
})(imdb);