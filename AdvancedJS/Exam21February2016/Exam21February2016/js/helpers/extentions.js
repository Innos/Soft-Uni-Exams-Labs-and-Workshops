Function.prototype.extends = function(parent){
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};
//Encapsulate them in a validation module maybe?
var Validator = function(){
    function validateLettersAndSpaces(string){
        if(typeof(string) !== 'string'){
            throw new TypeError("Input parameter must be of type string!");
        }
        if(!(/^[a-zA-Z\s]+$/.test(string))){
            throw new InvalidArgumentException("Input parameter must contain only letters and spaces!");
        }
    }

    function validateDigits(number){
        if(typeof(number) !== 'number'){
            throw new TypeError("Input parameter must be a valid number");
        }
        if(!(/^\d+$/.test(number))){
            throw new InvalidArgumentException("Input parameter must contain only digits!");
        }
    }

    function validateType(element,type){
        if(!(element instanceof type)){
            var message = "Input type must be a valid " + type.name;
            throw new TypeError(message);
        }
    }
    return {
        validateLettersAndSpaces:validateLettersAndSpaces,
        validateDigits:validateDigits,
        validateType:validateType
    }
}();
