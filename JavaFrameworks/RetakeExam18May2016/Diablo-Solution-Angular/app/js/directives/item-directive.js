"use strict";

angular.module("diablo.directives")
    .directive('item', [function () {
        return {
            restrict: 'A',
            replace: true,
            templateUrl: 'views/directives/item.html'
        };
    }]);