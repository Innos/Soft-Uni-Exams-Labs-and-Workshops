var app = app || {};

app.userController = (function () {
    function UserController(dataModels, viewbag) {
        this.dataModels = dataModels;
        this._viewbag = viewbag;
    }

    UserController.prototype.loadLoginPage = function(selector){
        this._viewbag.showLoginPage(selector);
    };

    UserController.prototype.loadRegisterPage = function(selector){
        this._viewbag.showRegisterPage(selector);
    };

    UserController.prototype.login = function (data) {
        var _this = this;
        this.dataModels.userModel.login(data)
            .then(function (success) {
                noty({text: 'Logged in successfully!',layout: 'top', closeWith: ['click'], type: 'success', timeout:2000});
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: '#/'});
                });
            },function(error){
                noty({text: error.responseJSON.description ,layout: 'top', closeWith: ['click'], type: 'error',timeout:2000});
            });
    };

    UserController.prototype.logout = function () {
        var _this = this;
        this.dataModels.userModel.logout()
            .then(function (success) {
                noty({text: 'Logged out successfully!',layout: 'top', closeWith: ['click'], type: 'success', timeout:2000});
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: '#/'});
                })
            },function (error){
                noty({text: error.responseJSON.description ,layout: 'top', closeWith: ['click'], type: 'error',timeout:2000});
            });
    };

    UserController.prototype.register = function(data){
        var _this = this;
        this.dataModels.userModel.register(data)
            .then(function(success){
                noty({text: 'Registered successfully!',layout: 'top', closeWith: ['click'], type: 'success',timeout:2000});
                $.sammy(function(){
                    this.trigger('redirectUrl',{url:'#/'});
                });
            },function(error){
                noty({text: error.responseJSON.description ,layout: 'top', closeWith: ['click'], type: 'error',timeout:2000});
            })
    };

    return {
        load: function(dataModels,viewbag){
            return new UserController(dataModels,viewbag);
        }
    }

}());