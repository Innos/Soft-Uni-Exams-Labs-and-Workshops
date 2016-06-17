'use strict';

angular.module('diablo.services')
    .factory('headersService', ['$http', 'identityService','appId','appSecret', function ($http, identityService,appId,appSecret) {

        function setHeaders() {
            if(identityService.isLogged()){
                $http.defaults.headers.common.Authorization = 'Kinvey ' + identityService.getAccessToken();
            }
            else{
                var token = appId + ":" + appSecret;
                $http.defaults.headers.common.Authorization = 'Basic ' + btoa(token);
            }
        }

        return {
            setHeaders: setHeaders
        }
    }]);