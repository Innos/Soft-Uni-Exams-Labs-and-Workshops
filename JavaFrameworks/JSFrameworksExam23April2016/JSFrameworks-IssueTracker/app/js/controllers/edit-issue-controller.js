"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/issues/:id/edit', {
            title: 'Issue',
            resolve: {
                access: ['$q','$location', '$route', 'identityService', 'notifyService', 'issuesService', function ($q,$location, $route, identityService, notifyService, issuesService) {
                    var defered = $q.defer();

                    issuesService.getById($route.current.params.id)
                        .then(function success(issue){
                            var userId = identityService.getId();
                            if(issue.Assignee.Id !== userId && issue.Author.Id !== userId && identityService.isAdmin() ==='false'){
                                notifyService.showError("Error insufficient authorization!");
                                $location.path('/');
                                defered.reject();
                            }
                            defered.resolve();
                        });

                    return defered.promise;
                }]
            },
            templateUrl: 'views/edit-issue.html',
            controller: 'EditIssueController'
        });
    }])
    .controller('EditIssueController', ['$scope','$routeParams','$rootScope', '$location','projectsService','identityService', 'issuesService','usersService','labelsService', 'notifyService',
        function ($scope,$routeParams,$rootScope, $location,projectsService, identityService, issuesService,usersService,labelsService, notifyService) {

            $scope.canEdit = null;
            $scope.canChangeStatus = null;
            $scope.loadingIssue = true;
            $scope.loadingUsers = true;
            $scope.loadingProject = true;

            usersService.getAll().then(function success(data){
                $scope.loadingUsers = false;
                $scope.users = data;
            },function error(err){
                notifyService.showError('Error accessing users:', err);
            });

            $scope.reloadIssue = function(){
                issuesService.getById($routeParams.id).then(function success(data){
                    $scope.issue = data;
                    $rootScope.$broadcast("pageChanged", data.Title);
                    if(data.Author.Id === identityService.getId() || identityService.isAdmin() === 'true'){
                        $scope.canEdit = true;
                    }
                    if(data.Assignee.Id === identityService.getId()){
                        $scope.canChangeStatus = true;
                    }
                    $scope.isClosed = data.Status.Name === "Closed" ? "btn-danger" : "btn-success";
                    $scope.currentDueDate = new Date(data.DueDate);

                    $scope.loadingIssue = false;
                    projectsService.getById($scope.issue.Project.Id).then(
                        function success(project){
                            $scope.loadingProject = false;
                            $scope.priorities = project.Priorities;
                        },function error(err){
                            notifyService.showError("Error resolving project: ",err);
                        }
                    )
                },function error(err){
                    notifyService.showError("Error resolving issue: ",err);
                });
            };

            //edit Issue
            $scope.editIssue = function(){
                var changedIssue = {
                    Title: $scope.issue.Title,
                    Description: $scope.issue.Description,
                    DueDate: $scope.currentDueDate,
                    PriorityId: $scope.issue.Priority.Id,
                    AssigneeId: $scope.issue.Assignee.Id,
                    Labels: $scope.issue.Labels
                };
                issuesService.updateIssue($scope.issue.Id,changedIssue).then(
                    function success(data){
                        $scope.reloadIssue();
                        notifyService.showInfo("Issue edited successfully!");
                    },function error(err){
                        notifyService.showError("Error could not edit issue: ",err);
                    }
                )
            };

            $scope.changeStatus = function (statusId) {
                issuesService.changeStatus($scope.issue.Id, statusId).then(function success(data) {
                    notifyService.showInfo("Status changed successfully!");
                    $scope.reloadIssue();
                }, function error(err) {
                    notifyService.showError("Error could not change status: ", err);
                })
            };


            //Datepicker
            $scope.today = function() {
                $scope.issue.DueDate = new Date();
            };

            $scope.openDatepicker = function() {
                $scope.datepicker.opened = true;
            };

            $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
            $scope.format = $scope.formats[0];
            $scope.altInputFormats = ['M!/d!/yyyy'];

            $scope.datepicker = {
                opened: false
            };

            $scope.dateOptions = {
                formatYear: 'yy',
                maxDate: new Date(2020, 5, 22),
                minDate: new Date(),
                startingDay: 1
            };


            //Labels

            $scope.transformChip = function(chip) {

                //check for duplicates
                var duplicate = null;
                if(angular.isObject(chip)){
                    $scope.issue.Labels.forEach(function(el){
                        if(el.Name === chip.Name){
                            duplicate = el;
                            return;
                        }
                    });
                }
                else{
                    $scope.issue.Labels.forEach(function(el){
                        if(el.Name === chip){
                            duplicate = el;
                            return;
                        }
                    });
                }

                // if the chip is a duplicate return the existing chip
                if(duplicate){
                    return duplicate;
                }

                if (angular.isObject(chip)) {
                    return chip;
                }

                // If it isn't return a new one
                return { Name: chip }

            };

            $scope.getLabels = function(searchText){
                var label = searchText.substring(searchText.indexOf(',')+ 1 || 0);
                return labelsService.getByQuery(label);
            };

            $scope.reloadIssue();

        }]);