var app = app || {};

(function(eventsSystem){
    var Party = (function(){
        function Party(options){
            eventsSystem._Event.call(this,options);
            this._isCatered = !!options.isCatered;
            this._isBirthday = !!options.isBirthday;
            this.setOrganiser(options.organiser);
        }

        Party.extends(eventsSystem._Event);

        Party.prototype.getOrganiser = function(){
            return this._organiser;
        };

        Party.prototype.setOrganiser = function(organiser){
            Validator.validateType(organiser,eventsSystem._Employee);
            this._organiser = organiser;
        };

        Party.prototype.checkIsCatered = function(){
            return this._isCatered;
        };

        Party.prototype.checkIsBirthday = function(){
            return this._isBirthday;
        };

        return Party;

    })();
    eventsSystem._Party = Party;
    eventsSystem.party = function(options){
        return new Party(options);
    }
}(app));