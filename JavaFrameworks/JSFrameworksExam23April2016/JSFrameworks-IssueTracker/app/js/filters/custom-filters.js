"use strict";

angular.module('issueTracker.filters')
    .filter('byFunction', [function () {
        return function(items, filterFunction,scope) {
            if (items) {
                var result = items.filter(filterFunction);
                scope.filteredCount = result.length;
                console.log(scope.filteredCount);
                return result;
            }
        }
    }]);
//.filter({
//    unique: ['$parse', function ($parse) {
//        return function (collection, property) {
//
//            if (!Array.isArray(collection)) {
//                return collection;
//            }
//
//            //store all unique identifiers
//            var uniqueItems = [],
//                get = $parse(property);
//
//            return (isUndefined(property))
//                //if it's a kind of primitive array
//                ? collection.filter(function (elm, pos, self) {
//                return self.indexOf(elm) === pos;
//            })
//                //else compare with equals
//                : collection.filter(function (elm) {
//                var prop = get(elm);
//                if (some(uniqueItems, prop)) {
//                    return false;
//                }
//                uniqueItems.push(prop);
//                return true;
//            });
//
//            //check if the unique identifier already exists
//            function some(array, member) {
//                if (isUndefined(member)) {
//                    return false;
//                }
//                return array.some(function (el) {
//                    return el === member;
//                });
//            }
//
//            function isUndefined(property) {
//                return property === 'undefined';
//            }
//        }
//    }]
//})
//.filter({
//    timeFormat: [function () {
//        return function (value) {
//            var hours = value.hours < 10 ? '0' + value.hours : value.hours;
//            var minutes = value.minutes < 10 ? '0' + value.minutes : value.minutes;
//            var seconds = value.seconds < 10 ? '0' + value.seconds : value.seconds;
//            return hours + ":" + minutes + ":" + seconds;
//        }
//    }]
//})
//.filter({
//    filterWithDay: ['$filter', function ($filter) {
//        return function (collection, value) {
//            if (value instanceof Date) {
//                return collection.filter(function (el) {
//                    if (el.date.getYear() === date.getYear() && el.date.getMonth() === date.getMonth() && el.date.getDay() === date.getDay()) {
//                        return true;
//                    }
//                    return false;
//                })
//            }
//            else {
//                return $filter('filter')(collection, value, false);
//            }
//        }
//    }]
//})
//.filter({
//    uniqueDay: ['$parse', function ($parse) {
//        return function (collection, property) {
//
//            var uniqueItems = [],
//                get = $parse(property);
//
//            return collection.filter(function (el) {
//                var prop = get(el);
//                if (exists(uniqueItems, prop)) {
//                    return false;
//                }
//                uniqueItems.push(prop);
//                return true;
//            });
//
//            //check if the unique identifier already exists
//            function exists(collection, prop) {
//                return collection.some(function (el) {
//                    return el.getYear() === prop.getYear() && el.getMonth() === prop.getMonth() && el.getDay() === prop.getDay();
//                })
//            }
//        }
//    }]
//});
