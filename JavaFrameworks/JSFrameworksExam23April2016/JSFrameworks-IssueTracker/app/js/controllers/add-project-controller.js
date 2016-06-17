"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/add', {
            title: "Add Project",
            resolve: {
                access: ['$q', '$location', '$route', '$uibModal', 'identityService', 'notifyService', 'projectsService', function ($q, $location, $route, $uibModal, identityService, notifyService, projectsService) {

                    var defered = $q.defer();

                    if (identityService.isAdmin() === 'false') {
                        notifyService.showError("Error insufficient authorization!");
                        $location.path('/');
                        defered.reject();
                    }
                    defered.resolve();

                    var modalInstance = $uibModal.open({
                        animation: true,
                        templateUrl: 'views/modal/add-project.html',
                        controller: 'AddProjectController'
                    });

                    return defered.promise;

                }]
            }
        });
    }])
    .controller('AddProjectController', ['$scope', '$uibModalInstance', '$location', 'projectsService', 'issuesService', 'usersService', 'labelsService', 'notifyService',
        function ($scope, $uibModalInstance, $location, projectsService, issuesService, usersService, labelsService, notifyService) {

            $scope.project = {};
            $scope.loadingUsers = true;

            usersService.getAll().then(function success(data) {
                $scope.loadingUsers = false;
                $scope.users = data;
            }, function error(err) {
                notifyService.showError('Error accessing users:', err);
            });

            $scope.addProject = function () {

                var newPriorities = [];
                if ($scope.project.Priorities !== undefined) {
                    var prioritiesText = $scope.project.Priorities.split(',');
                    prioritiesText.forEach(function (el) {
                        newPriorities.push({Name: el})
                    });
                }

                var newProject = {
                    Name: $scope.project.Name,
                    Description: $scope.project.Description,
                    ProjectKey: $scope.project.ProjectKey,
                    LeadId: $scope.project.newLead.Id,
                    priorities: newPriorities,
                    Labels: $scope.project.Labels
                };

                projectsService.postProject(newProject).then(function success(data) {
                    $uibModalInstance.close();
                    $location.path('/projects');
                    notifyService.showInfo('Project added successfully');
                }, function error(err) {
                    $uibModalInstance.dismiss('cancel');
                    $location.path('/projects');
                    notifyService.showError('Error adding project:', err);
                });
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
                $location.path('/projects');
            };

            $scope.changeProjectKey = function () {
                $scope.project.ProjectKey = "";
                var initials = $scope.project.Name.split(' ');
                initials.forEach(function (el) {
                    $scope.project.ProjectKey += el.charAt(0);
                });
            };

            //Labels

            $scope.project.Labels = [];

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

        }]);