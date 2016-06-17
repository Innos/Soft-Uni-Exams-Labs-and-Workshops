"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/profile/password', {
            title: 'Profile',
            templateUrl: 'views/profile.html',
            controller: 'ProfileController'
        });
    }])
    .controller('ProfileController', ['$scope', '$rootScope','$location', 'authorizationService', 'identityService', 'notifyService','separatorImage',
        function ($scope, $rootScope,$location, authorizationService, identityService, notifyService,separatorImage) {

            $scope.separatorImage = separatorImage;

            $rootScope.$broadcast("pageChanged", "Profile");

            $scope.changePassword = function(passwordData){
                authorizationService.changePassword(passwordData).then(function success(data){
                    $location.path('/');
                    notifyService.showInfo("Password changed successfully!");
                },function error(err){
                    notifyService.showError("Error changing password: ",err);
                })
            }

        }]);