var InvalidArgumentException = (function(){

    function InvalidArgumentException(message) {
        this.name = 'InvalidArgumentException';
        this.message = message || '';
        this.stack = (new Error()).stack;
    }
    InvalidArgumentException.prototype = Object.create(Error.prototype);

    return InvalidArgumentException;
})();

