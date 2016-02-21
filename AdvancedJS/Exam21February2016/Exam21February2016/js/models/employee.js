var app = app || {};

(function(eventsSystem){
    var Employee = (function(){
        function Employee(name,workHours){
            this.setName(name);
            this.setWorkhours(workHours);
        }

        Employee.prototype.getName = function(){
            return this._name;
        };

        Employee.prototype.setName = function(name){
            Validator.validateLettersAndSpaces(name);
            this._name = name;
        };

        Employee.prototype.getWorkhours = function(){
            return this._workHours;
        };

        Employee.prototype.setWorkhours = function(workHours){
            Validator.validateDigits(workHours);
            this._workHours = Number(workHours);
        };

        return Employee;

    })();
    eventsSystem._Employee = Employee;
    eventsSystem.employee = function(name,workHours){
        return new Employee(name,workHours);
    }
}(app));