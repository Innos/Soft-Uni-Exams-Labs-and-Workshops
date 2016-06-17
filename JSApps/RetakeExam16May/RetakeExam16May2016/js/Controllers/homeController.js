var app = app|| {};

app.homeController = (function (){
    function HomeController(dataModels,viewbag){
        this._viewbag = viewbag;
        this.dataModels = dataModels;
    }

    HomeController.prototype.loadGuestPage = function(selector){
        this._viewbag.showGuestPage(selector);
    };

    HomeController.prototype.loadGuestHeader = function(selector){
        this._viewbag.showGuestHeader(selector);
    };

    HomeController.prototype.loadHomePage = function(selector){
        var user = this.dataModels.credentials.getCurrentUser();
        this._viewbag.showHomePage(selector,user);
    };

    HomeController.prototype.loadHomeHeader = function(selector){
        this._viewbag.showHomeHeader(selector);
    };

    return {
        load: function(dataModels,viewbag){
            return new HomeController(dataModels,viewbag);
        }
    }
}());