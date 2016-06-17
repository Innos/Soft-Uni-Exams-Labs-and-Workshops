"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/:id/add-issue', {
            title:"Add Issue",
            resolve: {
                showModal: ['$uibModal', '$route', function ($uibModal, $route) {
                    var modalInstance = $uibModal.open({
                        animation: true,
                        templateUrl: 'views/modal/add-issue.html',
                        controller: 'AddIssueController',
                        resolve: {
                            id: function () {
                                return $route.current.params['id'];
                            }
                        }
                    });
                }]
            }
        });
    }])
    .controller('AddIssueController', ['$scope', '$uibModalInstance', '$location','projectsService', 'issuesService','usersService','labelsService', 'notifyService', 'id',
        function ($scope, $uibModalInstance, $location, projectsService, issuesService,usersService,labelsService, notifyService, id) {

            $scope.issue = {};
            $scope.issue.ProjectId = id;
            $scope.loadingProject = true;
            $scope.loadingUsers = true;

            projectsService.getById(id).then(function success(data){
                $scope.loadingProject = false;
                $scope.project = data;
            },function error(err){
                notifyService.showError('Error accessing project:', err);
            });

            usersService.getAll().then(function success(data){
                $scope.loadingUsers = false;
                $scope.users = data;
            },function error(err){
                notifyService.showError('Error accessing users:', err);
            });


            $scope.addIssue = function () {
                var newIssue = {
                    Title: $scope.issue.Title,
                    Description:$scope.issue.Description,
                    ProjectId: $scope.issue.ProjectId,
                    AssigneeId: $scope.issue.newAssignee.Id,
                    PriorityId: $scope.issue.PriorityId,
                    Labels: $scope.issue.Labels,
                    DueDate:$scope.issue.DueDate
                };

                issuesService.postIssue(newIssue).then(function success(data) {
                    $uibModalInstance.close();
                    $location.path('/projects/' + id);
                    notifyService.showInfo('Issue added successfully');
                }, function error(err) {
                    $uibModalInstance.dismiss('cancel');
                    $location.path('/projects/' + id);
                    notifyService.showError('Error adding issue:', err);
                });
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
                $location.path('/projects/' + id);
            };


            //Datepicker
            $scope.today = function() {
                $scope.issue.DueDate = new Date();
            };
            $scope.today();

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

            $scope.issue.Labels = [];

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

        }]);