var app = app || {};

app.requester = (function(){
    function Requester(){
    }

    Requester.prototype.post = function(url, data, headers) {
        return makeRequest("POST", url, data, headers);
    };

    Requester.prototype.get = function(url, headers) {
        return makeRequest("GET", url, null, headers);
    };

    Requester.prototype.put = function(url, data, headers) {
        return makeRequest("PUT", url, data, headers);
    };

    Requester.prototype.delete = function(url, headers) {
        return makeRequest("DELETE", url, null, headers);
    };

    function makeRequest(method, url, data, headers) {
        data = data || null;
        var token,
            defer = Q.defer(),
            options = {
                method: method,
                url: url,
                headers: headers,
                data: JSON.stringify(data),
                success: function (data) {
                    defer.resolve(data);
                },
                error: function (error) {
                    defer.reject(error);
                }
            };

        $.ajax(options);

        return defer.promise;
    }

    return {
        load: function(){
            return new Requester();
        }
    }
})();