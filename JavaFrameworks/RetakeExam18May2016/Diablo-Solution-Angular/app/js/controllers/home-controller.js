"use strict";

angular.module("diablo.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'views/welcome.html',
            controller: 'BaseController'
        });
    }])
    .controller('BaseController', ['$scope', '$location','authorizationService','identityService', 'notifyService', function ($scope,$location, authorizationService,identityService, notifyService) {

        $scope.identityService = identityService;
        if(identityService.isLogged()){
            $scope.username = identityService.getUsername();
        }
    }]);