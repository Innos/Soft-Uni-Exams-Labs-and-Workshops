"use strict";

angular.module('diablo.services')
    .factory('authorizationService', ['$http', '$q', 'baseUrl', 'identityService', 'headersService', 'appId', function ($http, $q, baseUrl, identityService, headersService, appId) {

        function login(user) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'user/' + appId + '/login';
            $http.post(url, user)
                .success(function success(data) {
                    identityService.setIdentity(data);
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function register(user) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'user/' + appId;
            $http.post(url, user)
                .success(function success(data) {
                    identityService.setIdentity(data);
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function logout() {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'user/' + appId + '/_logout';

            $http.post(url,null)
                .success(function success(data) {
                    identityService.removeIdentity();
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            login: login,
            register: register,
            logout: logout
        }
    }]);
