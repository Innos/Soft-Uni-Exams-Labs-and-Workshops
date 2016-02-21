var app = app || {};

(function(eventsSystem){
    var Hall = (function(){
        function Hall(name,capacity){
            this.setName(name);
            this.setCapacity(capacity);
            this.parties = [];
            this.lectures = [];
        }

        Hall.prototype.getName = function(){
            return this._name;
        };

        Hall.prototype.setName = function(name){
            Validator.validateLettersAndSpaces(name);
            this._name = name;
        };

        Hall.prototype.getCapacity = function(){
            return this._capacity;
        };

        Hall.prototype.setCapacity = function(capacity){
            Validator.validateDigits(capacity);
            this._capacity = Number(capacity);
        };

        Hall.prototype.addEvent = function(event){
            if(event instanceof eventsSystem._Party){
                this.parties.push(event);
            }
            else if(event instanceof eventsSystem._Lecture){
                this.lectures.push(event);
            }
        };

        return Hall;

    })();
    eventsSystem.hall = function(name,capacity){
        return new Hall(name,capacity);
    }
}(app));