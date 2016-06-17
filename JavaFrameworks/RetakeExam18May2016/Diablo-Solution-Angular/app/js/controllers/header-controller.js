"use strict";

angular.module("diablo.controllers")
    .controller('HeaderController', ['$scope','$location','authorizationService', 'identityService','notifyService', function ($scope, $location, authorizationService, identityService,notifyService) {
        $scope.identityService = identityService;

        $scope.logout = function(){
            authorizationService.logout().then(function success(data){
                notifyService.showInfo('Logout successful!');
                $location.path("/");
            });

        }
    }]);