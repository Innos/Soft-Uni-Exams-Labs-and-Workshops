"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/heroes/list', {
            resolve:{
                heroesData: ['$q','heroesService','notifyService',function($q,heroesService,notifyService){
                    var defered = $q.defer();
                    heroesService.getMyHeroes().then(function success(data) {
                        defered.resolve(data);
                    });

                    return defered.promise;
                }]
            },
            templateUrl: 'views/heroes.html',
            controller: 'MyHeroesController'
        });
    }])
    .controller('MyHeroesController', ['$scope', 'notifyService', 'heroesService','heroesData', function ($scope, notifyService, heroesService,heroesData) {

        $scope.heroes = heroesData;
    }]);