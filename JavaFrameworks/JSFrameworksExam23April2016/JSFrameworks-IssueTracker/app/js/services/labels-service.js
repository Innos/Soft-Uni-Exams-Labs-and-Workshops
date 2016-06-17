'use strict';

angular.module('issueTracker.services')
    .factory('labelsService', ['$http', '$q', 'baseUrl', 'headersService', function ($http, $q, baseUrl, headersService) {


        function getByQuery(query) {

            headersService.setHeaders();

            var defered = $q.defer();
            var url = baseUrl + 'labels?' + 'filter=' + query;
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
            getByQuery: getByQuery,
        }
    }]);
