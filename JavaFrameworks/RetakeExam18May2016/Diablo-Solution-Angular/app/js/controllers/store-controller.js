"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/heroes/:id/store', {
            resolve:{
                itemsData:['$q','itemsService','notifyService',function($q,itemsService,notifyService){

                    var defered = $q.defer();

                    itemsService.getAll().then(function success(data) {
                        defered.resolve(data);
                    });

                    return defered.promise;

                }]
            },
            templateUrl: 'views/store.html',
            controller: 'StoreController'
        });
    }])
    .controller('StoreController', ['$scope', '$location', '$routeParams', 'heroesService', 'itemsService', 'identityService', 'notifyService','itemsData',
        function ($scope, $location, $routeParams, heroesService, itemsService, identityService, notifyService,itemsData) {

            $scope.items = itemsData;

            var id = $routeParams['id'];

            $scope.buyItem = function (item) {
                heroesService.getItems(id).then(function success(data) {
                    var duplicateItemIndex = hasItem(data,item.type.name);
                    if (duplicateItemIndex !== -1) {
                        notifyService.showPrompt('You already have: ' + data[duplicateItemIndex].name + '. Do you want to throw it and buy this item instead?',
                            function yes($noty) {
                                $noty.close();
                                heroesService.removeItem(id, data[duplicateItemIndex]._id).then(function success(data) {
                                    heroesService.addItem(id, item._id).then(function success(data){
                                        notifyService.showInfo("Item bought successfully!");
                                        $location.path("/heroes/" + id);
                                    });

                                })
                            }, function no($noty) {
                                $noty.close();
                            })
                    } else {
                        heroesService.addItem(id, item._id).then(function success(data){
                            notifyService.showInfo("Item bought successfully!");
                            $location.path("/heroes/" + id);
                        });

                    }
                });
            };

            function hasItem(items,typeName) {
                var itemTypes = items.map(function (item) {
                    return item.type.name;
                });

                return itemTypes.indexOf(typeName);
            }
        }]);