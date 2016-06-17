'use strict';

angular.module('diablo.services')
    .factory('itemsService', ['$http', '$q', 'baseUrl','headersService','appId', function ($http, $q, baseUrl,headersService,appId) {

        function getServiceUrl() {
            return baseUrl + "appdata/" + appId + "/items";
        }

        function getAll(){
            headersService.setHeaders();
            var defered = $q.defer();
            var url = getServiceUrl() + '?resolve=type&retainReferences=false';
            $http.get(url)
                .success(function success(data){
                    defered.resolve(data);
                })
                .error(function error(err){
                    defered.reject(err);
                });

            return defered.promise;
        }

        function listTypes() {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'appdata/' + appId + '/item-types';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function (err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            getAll: getAll,
            listTypes:listTypes
        }
    }]);
