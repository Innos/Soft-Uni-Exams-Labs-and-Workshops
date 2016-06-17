"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects', {
            title: 'Projects',
            resolve: {
                access: ['$q','$location', '$route', 'identityService', 'notifyService', 'projectsService', function ($q,$location, $route, identityService, notifyService, projectsService) {

                    var defered = $q.defer();

                    if (identityService.isAdmin() === 'false') {
                        notifyService.showError("Error insufficient authorization!");
                        $location.path('/');
                        defered.reject();
                    }
                    defered.resolve();

                    return defered.promise;
                }]
            },
            templateUrl: 'views/all-projects.html',
            controller: 'AllProjectsController'
        });
    }])
    .controller('AllProjectsController', ['$scope',
        '$rootScope',
        '$routeParams',
        'notifyService',
        'projectsService',
        function ($scope,
                  $rootScope,
                  $routeParams,
                  notifyService,
                  projectsService) {


            $scope.projectsParams = {
                pageNumber: 1,
                pageSize: 10
            };

            $scope.projectsLoading = true;

            // on load
            $rootScope.$broadcast("pageChanged", "All Projects");

            $scope.reloadPage = function () {
                if(!$scope.allProjects){
                    projectsService.getAll().then(
                        function success(data) {
                            $scope.projectsLoading = false;
                            $scope.allProjects = data;
                            changePage();
                        }, function error(err) {
                            notifyService.showError("Error accessing projects: ", err);
                        });
                }
                else{
                    changePage();
                }
            };

            function changePage(){

                var start = ($scope.projectsParams.pageNumber - 1) * $scope.projectsParams.pageSize;
                var end = $scope.projectsParams.pageNumber * $scope.projectsParams.pageSize;
                if(end > $scope.allProjects.length){
                    end = $scope.allProjects.length;
                }
                $scope.projects = $scope.allProjects.slice(start,end);
            }

            $scope.reloadPage();
        }]);