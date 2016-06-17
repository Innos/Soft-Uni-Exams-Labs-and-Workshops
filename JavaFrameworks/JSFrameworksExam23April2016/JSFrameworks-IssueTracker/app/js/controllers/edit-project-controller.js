"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/:id/edit', {
            title: 'Project',
            resolve: {
                access: ['$q','$location', '$route', 'identityService', 'notifyService', 'projectsService', function ($q,$location, $route, identityService, notifyService, projectsService) {

                    var defered = $q.defer();

                    projectsService.getById($route.current.params.id)
                        .then(function success(project) {
                            var userId = identityService.getId();
                            if (project.Lead.Id !== userId && identityService.isAdmin() === 'false') {
                                notifyService.showError("Error insufficient authorization!");
                                $location.path('/');
                                defered.reject();
                            }
                            defered.resolve();
                        });
                    return defered.promise;
                }]
            },
            templateUrl: 'views/edit-project.html',
            controller: 'EditProjectController'
        });
    }])
    .controller('EditProjectController', ['$scope', '$routeParams', '$rootScope', '$location', 'projectsService', 'identityService', 'usersService', 'labelsService', 'notifyService',
        function ($scope, $routeParams, $rootScope, $location, projectsService, identityService, usersService, labelsService, notifyService) {

            $scope.isAdmin = null;
            $scope.loadingUsers = true;
            $scope.loadingProject = true;

            usersService.getAll().then(function success(data) {
                $scope.loadingUsers = false;
                $scope.users = data;
            }, function error(err) {
                notifyService.showError('Error accessing users:', err);
            });

            $scope.reloadProject = function () {
                projectsService.getById($routeParams.id).then(function success(data) {
                    $scope.project = data;
                    $rootScope.$broadcast("pageChanged", data.Name);
                    if (identityService.isAdmin() === 'true') {
                        $scope.isAdmin = true;
                    }

                    $scope.loadingProject = false;
                    $scope.combinedPriorities = data.Priorities.map(function (el) {
                        return el.Name;
                    }).join();
                }, function error(err) {
                    notifyService.showError("Error resolving issue: ", err);
                });
            };

            //edit Project
            $scope.editProject = function () {
                var newPriorities = [];
                if($scope.combinedPriorities !== undefined){
                    var priorities = $scope.combinedPriorities.split(',');
                    priorities.forEach(function (el) {
                        newPriorities.push({Name: el})
                    });
                }

                var changedProject = {
                    Name: $scope.project.Name,
                    Description: $scope.project.Description,
                    LeadId: $scope.project.Lead.Id,
                    priorities: newPriorities,
                    labels: $scope.project.Labels
                };
                projectsService.updateProject($scope.project.Id, changedProject).then(
                    function success(data) {
                        $scope.reloadProject();
                        notifyService.showInfo("Project edited successfully!");
                    }, function error(err) {
                        notifyService.showError("Error could not edit project: ", err);
                    }
                )
            };

            //Labels

            $scope.transformChip = function (chip) {

                //check for duplicates
                var duplicate = null;
                if (angular.isObject(chip)) {
                    $scope.project.Labels.forEach(function (el) {
                        if (el.Name === chip.Name) {
                            duplicate = el;
                            return;
                        }
                    });
                }
                else {
                    $scope.project.Labels.forEach(function (el) {
                        if (el.Name === chip) {
                            duplicate = el;
                            return;
                        }
                    });
                }

                // if the chip is a duplicate return the existing chip
                if (duplicate) {
                    return duplicate;
                }

                if (angular.isObject(chip)) {
                    return chip;
                }

                // If it isn't return a new one
                return {Name: chip}

            };

            $scope.getLabels = function (searchText) {
                var label = searchText.substring(searchText.indexOf(',') + 1 || 0);
                return labelsService.getByQuery(label);
            };

            $scope.reloadProject();

        }]);