var app = app || {};

(function(eventsSystem){
    var Course = (function(){
        function Course(name,numberOfLectures){
            this.setName(name);
            this.setNumberOfLectures(numberOfLectures);
        }

        Course.prototype.getName = function(){
            return this._name;
        };

        Course.prototype.setName = function(name){
            Validator.validateLettersAndSpaces(name);
            this._name = name;
        };

        Course.prototype.getNumberOfLectures = function(){
            return this._numberOfLectures;
        };

        Course.prototype.setNumberOfLectures = function(numberOfLectures){
            Validator.validateDigits(numberOfLectures);
            this._numberOfLectures = Number(numberOfLectures);
        };

        return Course;

    })();
    eventsSystem._Course = Course;
    eventsSystem.course = function(name,numberOfLectures){
        return new Course(name,numberOfLectures);
    }
}(app));