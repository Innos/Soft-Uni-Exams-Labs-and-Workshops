var app = app || {};

app.itemsModel = (function() {
    function Items(credentials, requester) {
        this._requester = requester;
        this.serviceUrl = credentials.baseUrl + "/appdata/" + credentials.appId + "/items/";
        this.itemTypesUrl = credentials.baseUrl + "/appdata/" + credentials.appId + "/item-types/";
        this.credentials = credentials;
    }

    Items.prototype.getAll = function () {
        var url = this.serviceUrl + '?resolve=type&retainReferences=false';
        return this._requester.get(url, this.credentials.getHeaders(false,true))
    };

    Items.prototype.listAvailableItemTypes = function () {
        var url = this.itemTypesUrl;
        return this._requester.get(url, this.credentials.getHeaders(false, true));
    };

    return {
        load: function (credentials, requester) {
            return new Items(credentials, requester);
        }
    }
})();