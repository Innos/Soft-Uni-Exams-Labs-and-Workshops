var app = app || {};

(function(eventsSystem){
    var Lecture = (function(){
        function Lecture(options){
            eventsSystem._Event.call(this,options);
            this.setTrainer(options.trainer);
            this.setCourse(options.course);
        }

        Lecture.extends(eventsSystem._Event);

        Lecture.prototype.getTrainer = function(){
            return this._trainer;
        };

        Lecture.prototype.setTrainer = function(trainer){
            Validator.validateType(trainer,eventsSystem._Trainer);
            this._trainer = trainer;
        };

        Lecture.prototype.getCourse = function(){
            return this._course;
        };

        Lecture.prototype.setCourse = function(course){
            Validator.validateType(course,eventsSystem._Course);
            this._course = course;
        };

        return Lecture;

    })();
    eventsSystem._Lecture = Lecture;
    eventsSystem.lecture = function(options){
        return new Lecture(options);
    }
}(app));