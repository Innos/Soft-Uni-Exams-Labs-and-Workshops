"use strict";

angular.module('issueTracker.services')
    .factory('authorizationService', ['$http', '$q', 'baseUrl', 'identityService', 'usersService', 'headersService', function ($http, $q, baseUrl, identityService, usersService, headersService) {

        function login(user) {
            var defered = $q.defer();
            var url = baseUrl + 'api/Token';
            var data = 'Username=' + user.Email + '&Password=' + user.Password + '&grant_type=password';
            $http.post(url, data, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}})
                .success(function success(data) {
                    identityService.setAccessToken(data.access_token);
                    usersService.getMyInfo().then(function success(userData) {
                        identityService.setIdentity(userData);
                        defered.resolve(data);
                    }, function error(err) {
                        defered.reject(err);
                    });
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function register(user) {
            var defered = $q.defer();
            var url = baseUrl + 'api/Account/Register';
            $http.post(url, user)
                .success(function success() {
                    login(user).then(function success(userData) {
                        defered.resolve(userData);
                    }, function error(err) {
                        defered.reject(err);
                    })
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function changePassword(passwordData) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'api/Account/ChangePassword';

            $http.post(url, passwordData)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function logout() {
            identityService.removeIdentity();
        }

        return {
            login: login,
            register: register,
            logout: logout,
            changePassword: changePassword
        }
    }]);
