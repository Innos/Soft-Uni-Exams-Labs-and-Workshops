var app = app || {};

app.lectureModel = (function() {
    function Lecture(credentials, requester) {
        this._requester = requester;
        this.serviceUrl = credentials.baseUrl + "/appdata/" + credentials.appId + "/lectures/";
        this.credentials = credentials;
    }

    Lecture.prototype.getAll = function () {
        return this._requester.get(this.serviceUrl, this.credentials.getHeaders(false,true))
    };

    Lecture.prototype.get = function (id) {
        var url = this.serviceUrl + id;
        return this._requester.get(url, this.credentials.getHeaders(false,true))
    };

    Lecture.prototype.query = function (query) {
        var url = this.serviceUrl + query;
        return this._requester.get(url, this.credentials.getHeaders(false,true))
    };

    Lecture.prototype.add = function (data) {
        return this._requester.post(this.serviceUrl, data, this.credentials.getHeaders(true,true));
    };

    Lecture.prototype.edit = function (id,data) {
        var url = this.serviceUrl + id;
        return this._requester.put(url, data, this.credentials.getHeaders(true, true));
    };

    Lecture.prototype.delete = function (id) {
        var url = this.serviceUrl + id;
        return this._requester.delete(url, this.credentials.getHeaders(false, true));
    };

    return {
        load: function (credentials, requester) {
            return new Lecture(credentials, requester);
        }
    }
})();