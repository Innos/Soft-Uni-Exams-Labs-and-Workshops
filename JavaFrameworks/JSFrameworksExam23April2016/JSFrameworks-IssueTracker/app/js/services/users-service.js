'use strict';

angular.module('issueTracker.services')
    .factory('usersService', ['$http', '$q', 'baseUrl', 'headersService', function ($http, $q, baseUrl, headersService) {

        function getAll() {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'users/';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getMyInfo() {
            headersService.setHeaders();

            var defered = $q.defer();
            var url = baseUrl + 'users/me';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getByQuery(query) {

            headersService.setHeaders();

            var defered = $q.defer();
            var url = baseUrl + 'users?' + 'filter=' + query;
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            getAll: getAll,
            getByQuery: getByQuery,
            getMyInfo: getMyInfo
        }
    }]);
