'use strict';

angular.module('issueTracker.services')
    .factory('projectsService', ['$http', '$q', 'baseUrl', 'identityService','headersService', function ($http, $q, baseUrl, identityService,headersService) {

        function getProjects(id) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'projects/' + id;
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
            return getProjects("");
        }

        function getById(id) {
            return getProjects(id)
        }

        function getAllIssuesByProjectId(id) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'projects/' + id + '/issues';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getMyProjects(requestParams) {
            headersService.setHeaders();
            var pageSize = requestParams.pageSize || 10;
            var pageNumber = requestParams.pageNumber || 1;

            var defered = $q.defer();

            var id = identityService.getId();

            var url = baseUrl + 'projects?' + 'filter=LeadId=\"' + id + '\"' + ' or Issues.Any(AssigneeId==\"' + id + '\")' + '&pageSize=' + pageSize + '&pageNumber=' + pageNumber;
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

            var url = baseUrl + 'projects?' + 'filter=' + query + '&pageSize=' + pageSize + '&pageNumber=' + pageNumber;
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function postProject(project) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'projects';
            $http.post(url, project)
                .success(function success(data) {
                    defered.resolve();
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function updateProject(id, project) {
            headersService.setHeaders();
            var defered = $q.defer();
            var url = baseUrl + 'projects/' + id;
            $http.put(url, project)
                .success(function success(data) {
                    defered.resolve();
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            getAll: getAll,
            getAllIssuesByProjectId:getAllIssuesByProjectId,
            getById: getById,
            getByQuery: getByQuery,
            getMyProjects:getMyProjects,
            postProject: postProject,
            updateProject: updateProject
        }
    }]);
