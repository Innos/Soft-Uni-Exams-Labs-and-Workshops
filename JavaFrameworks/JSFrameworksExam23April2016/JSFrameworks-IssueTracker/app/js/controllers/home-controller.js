"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            title: 'Home',
            templateUrl: 'views/home.html',
            controller: 'HomeController'
        });
    }])
    .controller('HomeController', ['$scope',
        '$rootScope',
        'authorizationService',
        'identityService',
        'notifyService',
        'projectsService',
        'issuesService',
        'separatorImage',
        function ($scope,
                  $rootScope,
                  authorizationService,
                  identityService,
                  notifyService,
                  projectsService,
                  issuesService,
                  separatorImage) {

            $scope.projectsLoading = true;
            $scope.issuesLoading = true;

            $scope.projectParams = {
                pageNumber: 1,
                pageSize: 10
            };

            $scope.issuesParams = {
                pageNumber: 1,
                pageSize: 12
            };

            $scope.reloadProjects = function () {
                $scope.projectsLoading = true;
                projectsService.getMyProjects($scope.projectParams).then(
                    function success(data) {
                        $scope.myProjects = data;
                        $scope.projectsLoading = false;
                    }, function error(err) {
                        notifyService.showError("Error: Could not access Projects on the server!", err);
                    }
                );
            };

            $scope.reloadIssues = function () {
                $scope.issuesLoading = true;
                issuesService.getMyIssues($scope.issuesParams).then(
                    function success(data) {
                        $scope.myIssues = data;
                        $scope.issuesLoading = false;
                    }, function error(err) {
                        notifyService.showError("Error: Could not access Issues on the server!", err);
                    }
                );
            };

            // new load checks here
            if (identityService.isLogged()) {
                $rootScope.$broadcast("pageChanged", "Dashboard");
                if(identityService.isAdmin()==='true'){
                    $scope.isAdmin = true;
                }
                $scope.reloadIssues();
                $scope.reloadProjects();
            }

            $scope.separatorImage = separatorImage;

            $scope.identityService = identityService;

            $scope.login = function (user) {
                authorizationService.login(user)
                    .then(function success() {
                        $scope.reloadIssues();
                        $scope.reloadProjects();
                        $rootScope.$broadcast("pageChanged", "Dashboard");
                        notifyService.showInfo("Logged in successfully!");
                    }, function error(err) {
                        notifyService.showError("Could not log in:", err);
                    })
            };

            $scope.register = function (user) {
                authorizationService.register(user)
                    .then(function success() {
                        $scope.reloadIssues();
                        $scope.reloadProjects();
                        $rootScope.$broadcast("pageChanged", "Dashboard");
                        notifyService.showInfo("Registered successfully!");
                    }, function error(err) {
                        notifyService.showError("Could not register:", err);
                    })
            };

            $scope.isAdmin = function(){
                return identityService.isAdmin()==='true';
            };

        }]);