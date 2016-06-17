'use strict';

angular.module('diablo.services')
    .factory('heroesService', ['$http', '$q', 'baseUrl', 'identityService', 'headersService', 'appId', function ($http, $q, baseUrl, identityService, headersService, appId) {

        function getServiceUrl() {
            return baseUrl + "appdata/" + appId + "/heroes/";
        }

        function getMyHeroes() {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = getServiceUrl() + '?resolve=class&retainReferences=false&query={"_acl.creator":' + '"' + identityService.getId() + '"}';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;

        }

        function getHero(id) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = getServiceUrl() + id + '?resolve=class,items,items.type&retainReferences=false';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function addHero(heroData) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = getServiceUrl();
            var hero = {
                name: heroData.name,
                class: {
                    "_type": "KinveyRef",
                    "_id": heroData.classId,
                    "_collection": "hero-classes"
                },
                items: []
            };
            $http.post(url, hero)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getItems(id) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = getServiceUrl() + id + "?resolve=items,items.type&retainReferences=false";
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data.items);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function addItem(heroId, itemId) {
            headersService.setHeaders();
            var defered = $q.defer();
            getHero(heroId).then(function success(hero) {
                hero.items.push({
                    "_type": "KinveyRef",
                    "_id": itemId,
                    "_collection": "items"
                });
                var url = getServiceUrl() + heroId;
                $http.put(url, hero)
                    .success(function success(data) {
                        defered.resolve(data);
                    })
            }, function error(err) {
                defered.reject(err);
            });

            return defered.promise;
        }

        function removeItem(heroId, itemId) {
            headersService.setHeaders();
            var defered = $q.defer();
            getHero(heroId).then(function success(hero) {
                var itemIds = hero.items.map(function (item) {
                    return item._id;
                });
                var itemIndex = itemIds.indexOf(itemId);
                hero.items.splice(itemIndex, 1);
                var url = getServiceUrl() + heroId;
                $http.put(url, hero)
                    .success(function success(data) {
                        defered.resolve(data);
                    })
            }, function error(err) {
                defered.reject(err);
            });

            return defered.promise;
        }

        function listClasses() {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'appdata/' + appId + '/hero-classes';
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
            getMyHeroes: getMyHeroes,
            getHero: getHero,
            addHero: addHero,
            getItems: getItems,
            addItem: addItem,
            removeItem: removeItem,
            listClasses: listClasses
        }
    }]);
