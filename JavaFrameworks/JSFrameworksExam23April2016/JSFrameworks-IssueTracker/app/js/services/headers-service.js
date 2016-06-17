'use strict';

angular.module('issueTracker.services')
    .factory('headersService', ['$http', 'identityService', function ($http, identityService) {

        function setHeaders() {
            $http.defaults.headers.common.Authorization = 'Bearer ' + identityService.getAccessToken();
        }

        return {
            setHeaders: setHeaders
        }
    }]);