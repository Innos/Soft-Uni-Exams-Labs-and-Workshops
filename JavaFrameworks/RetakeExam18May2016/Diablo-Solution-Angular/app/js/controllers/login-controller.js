"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/login/', {
            templateUrl: 'views/login.html',
            controller: 'LoginController'
        });
    }])
    .controller('LoginController', ['$scope', '$location','authorizationService', 'notifyService', function ($scope,$location, authorizationService, notifyService) {

        $scope.login = function(user){
            authorizationService.login(user).then(function success(data){
                notifyService.showInfo("Logged in successfully!");
                $location.path("/");
            })

        }

    }]);