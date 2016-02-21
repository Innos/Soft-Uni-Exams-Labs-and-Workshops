var app = app || {};

(function(eventsSystem){
    var Trainer = (function(){
        function Trainer(name,workHours){
            eventsSystem._Employee.call(this,name,workHours);
            this.courses = [];
            this.feedbacks = [];
        }

        Trainer.extends(eventsSystem._Employee);

        Trainer.prototype.addFeedback = function(feedback){
            if(typeof(feedback) !== 'string'){
                throw new Error("Input parameter must be a valid string!");
            }
            this.feedbacks.push(feedback);
        };

        Trainer.prototype.addCourse = function(course){
            Validator.validateType(course,eventsSystem._Course);
            this.courses.push(course);
        };

        return Trainer;

    })();
    eventsSystem._Trainer = Trainer;
    eventsSystem.trainer = function(name,workHours){
        return new Trainer(name,workHours);
    }
}(app));