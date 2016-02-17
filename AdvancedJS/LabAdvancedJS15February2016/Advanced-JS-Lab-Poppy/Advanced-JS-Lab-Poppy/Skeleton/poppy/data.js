var data = (function(){
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var Popup = (function (){
        function Popup(title,message,type){
            if(this.constructor === "Popup"){
                throw new Error("Cannot instantiate abstract class!")
            }
            this._popupData = {};
            this._popupData.type = type;
            this._popupData.title = title;
            this._popupData.message = message;
        }
        return Popup;
    })();

    var SuccessPopup = (function(){
        var TIMEOUT = 3000;
        function SuccessPopup(title,message,type){
            Popup.call(this,title,message,type);
            this._popupData.position = 'bottomLeft';
            this._popupData.autoHide = true;
            this._popupData.timeout = TIMEOUT;
        }

        SuccessPopup.extends(Popup);
        return SuccessPopup;
    })();

    var InfoPopup = (function(){
        var TIMEOUT = 3000;
        function InfoPopup(title,message,type){
            Popup.call(this,title,message,type);
            this._popupData.position = 'topLeft';
            this._popupData.timeout = TIMEOUT;
            this._popupData.closeButton = true;
        }

        InfoPopup.extends(Popup);
        return InfoPopup;
    })();

    var ErrorPopup = (function(){
        function ErrorPopup(title,message,type){
            Popup.call(this,title,message,type);
            this._popupData.position = 'topRight';
        }

        ErrorPopup.extends(Popup);
        return ErrorPopup;
    })();

    var WarningPopup = (function(){
        function WarningPopup(title,message,type,callback){
            Popup.call(this,title,message,type);
            this._popupData.position = 'bottomRight';
            this._popupData.callback = callback;
        }

        WarningPopup.extends(Popup);
        return WarningPopup;
    })();

    return {
        Success: SuccessPopup,
        Info: InfoPopup,
        Error: ErrorPopup,
        Warning: WarningPopup
    }
})();
