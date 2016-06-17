'use strict';

angular.module('diablo.services', []);
angular.module('diablo.filters', []);
angular.module('diablo.directives', []);
angular.module('diablo.controllers', ['ngRoute','diablo.services']);

angular.module('diablo', [
    'ngRoute',
    'diablo.services',
    'diablo.filters',
    'diablo.controllers',
    'diablo.directives'
])
    .config(['$routeProvider','$httpProvider', function ($routeProvider,$httpProvider) {
        $routeProvider.otherwise({redirectTo: '/'});

        $httpProvider.interceptors.push(['$q','notifyService',function ($q,notifyService){
            return{
                'request': function(config){
                    if(!navigator.onLine){
                        notifyService.showError("Error: No internet connection!");
                    }
                    return config;
                },
                'responseError': function(rejection){
                    if(navigator.onLine){
                        notifyService.showError("Error: ",rejection.data);
                    }
                    return $q.reject(rejection);
                }
            }
        }]);
    }])
    .constant("baseUrl", "https://baas.kinvey.com/")
    .constant("appId", "kid_bJrVNvaoGZ")
    .constant("appSecret", "bbe2fda7f8a34d36986309344437389f")
    .run(['$rootScope', '$location', '$route', 'identityService', 'notifyService', function ($rootScope, $location, $route, identityService, notifyService) {

        $rootScope.$on('$locationChangeStart',function(event){
            var allowedPaths = ['/','/login/','/register/'];
            if(allowedPaths.indexOf($location.path()) === -1 && !identityService.isLogged()){
                $location.path('/');
                notifyService.showInfo("You need to login or register to browse");
            }
        });
    }]);