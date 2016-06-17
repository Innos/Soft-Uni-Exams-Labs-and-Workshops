"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/register/', {
            templateUrl: 'views/register.html',
            controller: 'HomeController'
        });
    }])
    .controller('HomeController', ['$scope','$location', 'authorizationService', 'notifyService', function ($scope,$location, authorizationService, notifyService) {

        $scope.register = function(user){
            if(user.password !== user.confirmPassword){
                notifyService.showError("Passwords do not match!");
            }
            else{
                var newUser = {
                    username: user.username,
                    password: user.password
                };
                authorizationService.register(newUser).then(function success(data){
                    notifyService.showInfo("Registered in successfully!");
                    $location.path("/");
                });

            }
        }
    }]);