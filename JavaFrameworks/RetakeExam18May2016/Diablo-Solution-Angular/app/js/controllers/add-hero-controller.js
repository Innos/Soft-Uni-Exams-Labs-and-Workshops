"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/heroes/add', {
            resolve: {
                classesData: ['$q', 'heroesService', function ($q, heroesService) {

                    var defered = $q.defer();

                    heroesService.listClasses().then(function success(data) {
                        defered.resolve(data);
                    });

                    return defered.promise;
                }]
            },
            templateUrl: 'views/add-hero.html',
            controller: 'AddHeroController'
        });
    }])
    .controller('AddHeroController', ['$scope', '$location', 'heroesService', 'notifyService', 'classesData',
        function ($scope, $location, heroesService, notifyService,classesData) {
            $scope.classes = classesData;

            $scope.addHero = function (hero) {
                heroesService.addHero(hero).then(function success(data) {
                    notifyService.showInfo("Hero added successfully!");
                    $location.path("/heroes/list");
                })
            }

        }]);