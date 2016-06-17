"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/heroes/:id', {
            resolve:{
                heroData:['$q','$route','heroesService','notifyService',function($q,$route,heroesService,notifyService){

                    var defered = $q.defer();

                    var id = $route.current.params['id'];
                    heroesService.getHero(id).then(function success(data) {

                        data.attackPoints = data.class.attackPoints;
                        data.defensePoints = data.class.defensePoints;
                        data.lifePoints = data.class.lifePoints;

                        data.items.forEach(function(item){
                            data.attackPoints += item.attackPoints;
                            data.defensePoints += item.defensePoints;
                            data.lifePoints += item.lifePoints;
                        });

                        defered.resolve(data);
                    });

                    return defered.promise;
                }]
            },
            templateUrl: 'views/hero.html',
            controller: 'HeroController'
        });
    }])
    .controller('HeroController', ['$scope','$routeParams', 'notifyService', 'heroesService','heroData', function ($scope,$routeParams, notifyService, heroesService,heroData) {

        $scope.hero = heroData;
        $scope.items = heroData.items;

    }]);