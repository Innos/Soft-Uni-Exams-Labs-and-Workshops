'use strict';

angular.module('issueTracker.services')
    .factory('issuesService', ['$http', '$q', 'baseUrl', 'identityService','headersService', function ($http, $q, baseUrl, identityService,headersService) {

        function getIssues(id,requestParams) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'issues/' + id;
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getAll() {
            return getIssues("");
        }

        function getById(id) {
            return getIssues(id)
        }

        function getMyIssues(requestParams) {
            headersService.setHeaders();

            var pageSize = requestParams.pageSize || 10;
            var pageNumber = requestParams.pageNumber || 1;

            var defered = $q.defer();
            var url = baseUrl + 'issues/me?orderBy=DueDate desc' + '&pageSize=' + pageSize + '&pageNumber=' + pageNumber;
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getByQuery(query, requestParams) {
            headersService.setHeaders();

            var pageSize = 10000;
            var pageNumber = 1;

            if(requestParams){
                pageSize = requestParams.pageSize;
                pageNumber = requestParams.pageNumber;
            }

            var defered = $q.defer();
            var url = baseUrl + 'issues?' + 'filter=' + query + '&pageSize=' + pageSize + '&pageNumber=' + pageNumber;
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function postIssue(issue) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'issues';
            $http.post(url, issue)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function updateIssue(id, issue) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'issues/' + id;
            $http.put(url, issue)
                .success(function success(data) {
                    defered.resolve();
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function changeStatus(id, statusId) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'issues/' + id + "/changeStatus?statusId=" + statusId;
            $http.put(url)
                .success(function success(data) {
                    defered.resolve();
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function postComment(id, comment) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'issues/' + id + '/comments';
            $http.post(url,comment)
                .success(function success(data) {
                    defered.resolve();
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getComments(id) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'issues/' + id + '/comments';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            getAll: getAll,
            getById: getById,
            getByQuery: getByQuery,
            getMyIssues: getMyIssues,
            postIssue: postIssue,
            updateIssue: updateIssue,
            changeStatus: changeStatus,
            postComment:postComment,
            getComments:getComments
        }
    }]);
