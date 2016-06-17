"use strict";

angular.module("issueTracker.controllers")
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/issues/:id', {
            title: 'Issue',
            templateUrl: 'views/issue.html',
            controller: 'IssueController'
        });
    }])
    .controller('IssueController', ['$scope', '$routeParams', '$rootScope', 'projectsService', 'issuesService', 'identityService', 'notifyService',
        function ($scope, $routeParams, $rootScope, projectsService, issuesService, identityService, notifyService) {

            var id = $routeParams['id'];

            $scope.canEdit = null;
            $scope.canPost = null;

            $scope.reloadIssue = function () {
                $scope.loadingIssue = true;

                issuesService.getById(id).then(function success(data) {
                    $scope.issue = data;
                    $scope.loadingIssue = false;
                    $scope.labels = $scope.issue.Labels.map(function (el) {
                        return el.Name;
                    });
                    $scope.deadline = Date.parse($scope.issue.DueDate);
                    if (data.Author.Id === identityService.getId() || data.Assignee.Id === identityService.getId() || identityService.isAdmin() === 'true') {
                        $scope.canEdit = true;
                    }
                    $rootScope.$broadcast("pageChanged", data.Title);
                    $scope.isClosed = data.Status.Name === "Closed" ? "btn-danger" : "btn-success";

                    // resolve if the user can Post Comments
                    if ($scope.issue.Author.Id === identityService.getId() || identityService.isAdmin()==='true') {
                        $scope.canPost = true;
                    }
                    if (!$scope.canPost) {
                        issuesService.getMyIssues().then(function success(data) {
                            if (data.Issues.some(function (el) {
                                    return el.Project.Id === $scope.issue.Project.Id;
                                })) {
                                $scope.canPost = true;
                            }
                        }, function error(err) {
                            notifyService.showError("Error could not resolve issues: ", err);
                        });
                    }

                }, function error(err) {
                    notifyService.showError("Error loading issue:", err);
                });
            };

            $scope.changeStatus = function (statusId) {
                issuesService.changeStatus($scope.issue.Id, statusId).then(function success(data) {
                    notifyService.showInfo("Status changed successfully!");
                    $scope.reloadIssue();
                }, function error(err) {
                    notifyService.showError("Error could not change status: ", err);
                })
            };

            $scope.reloadComments = function () {
                issuesService.getComments(id).then(function success(data) {
                    $scope.comments = data;
                }, function error(err) {
                    notifyService.showError("Error could not resolve comments: ", err);
                })
            };

            $scope.postComment = function (commentText) {
                var newComment = {
                    Text: commentText
                };
                issuesService.postComment(id, newComment).then(function success(data) {
                    notifyService.showInfo("Comment posted succesfully!");
                    $scope.reloadComments();
                }, function error(err) {
                    notifyService.showError("Error could not post comment: ", err);
                })
            };

            $scope.reloadIssue();
            $scope.reloadComments();
        }]);