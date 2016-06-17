var app = app || {};

app.userModel = (function () {
    function User(credentials, requester) {
        this._requester = requester;
        this.serviceUrl = credentials.baseUrl + "/user/" + credentials.appId + "/";
        this.credentials = credentials;
    }

    User.prototype.login = function (data) {
        var url = this.serviceUrl + "login";
        var _this = this;
        return this._requester.post(url, data, this.credentials.getHeaders(true)).then(function success(data){
            _this.credentials.setCurrentUser(data._kmd.authtoken,data._id,data.username);
        });
    };

    User.prototype.register = function (data) {
        var _this = this;
        return this._requester.post(this.serviceUrl, data, this.credentials.getHeaders(true)).then(function success(data){
            _this.credentials.setCurrentUser(data._kmd.authtoken,data._id,data.username);
        });
    };

    User.prototype.logout = function () {
        var url = this.serviceUrl + "_logout";
        var _this = this;
        return this._requester.post(url, null, this.credentials.getHeaders(false, true)).then(function success(data){
            _this.credentials.clear();
        });
    };

    return {
        load: function (credentials, requester) {
            return new User(credentials, requester);
        }
    }
}());