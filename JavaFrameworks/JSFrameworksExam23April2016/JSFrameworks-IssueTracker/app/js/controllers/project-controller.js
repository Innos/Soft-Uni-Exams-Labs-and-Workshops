"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/:id', {
            title: 'Project',
            templateUrl: 'views/project.html',
            controller: 'ProjectController'
        });
    }])
    .controller('ProjectController', ['$scope',
        '$rootScope',
        '$routeParams',
        '$uibModal',
        'identityService',
        'notifyService',
        'projectsService',
        'issuesService',
        function ($scope,
                  $rootScope,
                  $routeParams,
                  $uibModal,
                  identityService,
                  notifyService,
                  projectsService,
                  issuesService) {


            $scope.issuesParams = {
                pageNumber: 1,
                pageSize: 5
            };

            $scope.isAuthorized = null;
            $scope.issuesLoading = true;
            $scope.projectLoading = true;

            // on load
            var id = $routeParams['id'];

            projectsService.getById(id).then(
                function success(data) {
                    $scope.project = data;
                    $scope.projectLoading = false;
                    if (data.Lead.Id === identityService.getId() || identityService.isAdmin() === 'true') {
                        $scope.isAuthorized = true;
                    }
                    $scope.labels = data.Labels.map(function (el) {
                        return el.Name;
                    });
                    $rootScope.$broadcast("pageChanged", data.Name);
                }, function error(err) {
                    notifyService.showError("Error accessing Project: ", err);
                }
            );

            $scope.reloadPage = function () {
                if (!$scope.allIssues) {
                    projectsService.getAllIssuesByProjectId(id).then(
                        function success(data) {
                            $scope.issuesLoading = false;
                            $scope.originalIssues = data;
                            $scope.myIssues = data.filter(function (el) {
                                return el.Assignee.Id === identityService.getId();
                            });
                            issuesService.getByQuery('Comments.Any(AuthorId == "' + identityService.getId() + '") and Project.Id == ' + id).then(
                                function success(data) {
                                    $scope.commentedIssues = data.Issues;
                                }, function error(err) {
                                    notifyService.showError("Error accessing issues: ", err);
                                });
                            $scope.openIssues = data.filter(function (el) {
                                return el.Status.Name === "Open";
                            });
                            $scope.dueTodayIssues = data.filter(function (el) {
                                var date = new Date(el.DueDate);
                                var today = new Date();
                                if (date.getYear() === today.getYear() && date.getMonth() === today.getMonth() && date.getDate() === today.getDate()) {
                                    return true;
                                }
                            });

                            $scope.allIssues = $scope.originalIssues;
                            changePage();
                        }, function error(err) {
                            notifyService.showError("Error accessing issues: ", err);
                        });
                }
                else {
                    changePage();
                }
            };

            function changePage() {
                var start = ($scope.issuesParams.pageNumber - 1) * $scope.issuesParams.pageSize;
                var end = $scope.issuesParams.pageNumber * $scope.issuesParams.pageSize;
                if (end > $scope.allIssues.length) {
                    end = $scope.allIssues.length;
                }
                $scope.issues = $scope.allIssues.slice(start, end);
            }

            $scope.filters = [
                {Name: 'MyIssues', func: myIssueFilter},
                {Name: 'All', func: allFilter}
            ];

            $scope.myFilter = $scope.filters[0];

            function myIssueFilter(value,index,array){
                console.log(value.Assignee.Id);
                console.log(identityService.getId());
                if(value.Assignee.Id === identityService.getId()){
                    return true;
                }
                return false;
            }

            function allFilter(value,index,array){
                return true;
            }

            $scope.currentVal = "mine";

            $scope.onChangeFilter = function(val){
                $scope.issuesParams = {
                    pageNumber: 1,
                    pageSize: 5
                };
                if(val==="mine"){
                    $scope.allIssues = $scope.myIssues;
                }
                if(val==="all"){
                    $scope.allIssues = $scope.originalIssues;
                }
                if(val==="commented"){
                    $scope.allIssues = $scope.commentedIssues;
                }
                if(val==="open"){
                    $scope.allIssues = $scope.openIssues;
                }
                if(val==="today"){
                    $scope.allIssues = $scope.dueTodayIssues;
                }
                $scope.reloadPage();
            };

            $scope.reloadPage();

        }
    ])
;