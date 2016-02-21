var app = app || {};

(function(eventsSystem){
    var Event = (function(){
        function Event(options){
            if(this.constructor === Event){
                throw new Error("Cannot instantiate abstract class Event!");
            }
            this.setTitle(options.title);
            this.setType(options.type);
            this.setDuration(options.duration);
            this.setDate(options.date);
        }

        Event.prototype.getTitle = function(){
            return this._title;
        };

        Event.prototype.setTitle = function(title){
            Validator.validateLettersAndSpaces(title);
            this._title = title;
        };

        Event.prototype.getType = function(){
            return this._type;
        };

        Event.prototype.setType = function(type){
            Validator.validateLettersAndSpaces(type);
            this._type = type;
        };

        Event.prototype.getDuration = function(){
            return this._duration;
        };

        Event.prototype.setDuration = function(duration){
            Validator.validateDigits(duration);
            this._duration = Number(duration);
        };

        Event.prototype.getDate = function(){
            return this._date;
        };

        Event.prototype.setDate = function(date){
            Validator.validateType(date,Date);
            this._date = date;
        };

        return Event;

    })();
    eventsSystem._Event = Event;
}(app));