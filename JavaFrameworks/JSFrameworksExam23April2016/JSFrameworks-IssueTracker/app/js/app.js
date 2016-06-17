'use strict';

angular.module('issueTracker.services', []);
angular.module('issueTracker.filters', []);
angular.module('issueTracker.directives', []);
angular.module('issueTracker.controllers', ['ngRoute','ngMaterial','issueTracker.filters']);

angular.module('issueTracker', [
    'ngRoute',
    'ngMaterial',
    'issueTracker.services',
    'issueTracker.filters',
    'issueTracker.controllers',
    'issueTracker.directives',
    'ui.bootstrap.pagination',
    'ui.bootstrap.modal',
    'ui.bootstrap.tpls',
    'ui.bootstrap.datepickerPopup'
])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
    }])
    .constant("baseUrl", "http://softuni-issue-tracker.azurewebsites.net/")
    .constant("separatorImage", "resources/images/separator.png")
    .run(['$rootScope','$location','$route','$http','identityService','notifyService', function ($rootScope,$location,$route,$http,identityService,notifyService) {
        $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
            if(current.$$route){
                $rootScope.title = current.$$route.title;
            }
        });

        $rootScope.$on('$locationChangeStart',function(event){
            if($location.path() != "/" && !identityService.isLogged()){
                $location.path("/");
                notifyService.showInfo("You need to login or register to start");
            }

            if(($location.path() === "/projects/add" || $location.path() === "/projects") && identityService.isAdmin() === 'false'){
                $location.path('/');
                notifyService.showError("Insufficient privilidges!");
            }

        });
    }]);