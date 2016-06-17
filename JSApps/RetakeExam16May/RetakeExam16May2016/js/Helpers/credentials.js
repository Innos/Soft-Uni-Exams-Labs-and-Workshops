var app = app|| {};

app.credentials = (function(){
    function Credentials(baseUrl,appId,appSecret){
        this.baseUrl = baseUrl;
        this.appId = appId;
        this.appSecret = appSecret;
    }

    Credentials.prototype.getHeaders = function (contentType,useSession){
        var headers = {};
        if(contentType){
            headers['Content-Type'] = "application/json";
        }
        if(useSession){
            headers['Authorization'] = "Kinvey " + this.getCurrentUser().authToken;
        }
        else{
            var token = this.appId + ":" + this.appSecret;
            headers['Authorization'] = "Basic " + btoa(token);
        }
        return headers;
    };

    Credentials.prototype.getCurrentUser = function () {
        var authToken = sessionStorage.getItem('sessionId');
        var id = sessionStorage.getItem('userId');
        var name =sessionStorage.getItem('username');

        return {
            'authToken':authToken,
            'userId': id,
            'username': name
        };
    };

    Credentials.prototype.isLogged = function(){
        return !!sessionStorage.getItem('sessionId');
    };

    Credentials.prototype.setCurrentUser = function(sessionAuth,userId,username){
        sessionStorage.setItem('sessionId',sessionAuth);
        sessionStorage.setItem('userId',userId);
        sessionStorage.setItem('username',username);
    };


    Credentials.prototype.clear = function (){
        sessionStorage.removeItem('sessionId');
        sessionStorage.removeItem('userId');
        sessionStorage.removeItem('username');
    };

    return {
        load: function(baseUrl,appId,appSecret){
            return new Credentials(baseUrl,appId,appSecret);
        }
    }
}());
