"use strict";

angular.module("diablo.directives")
    .directive('hero', [function () {
        return {
            restrict: 'A',
            replace: true,
            templateUrl: 'views/directives/hero.html'
        };
    }]);