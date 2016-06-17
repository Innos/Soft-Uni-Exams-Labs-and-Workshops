'use strict';

angular.module('issueTracker.services')
    .factory('identityService', [function () {

        function setIdentity(user) {
            sessionStorage.setItem('id',user.Id);
            sessionStorage.setItem('username',user.Username);
            sessionStorage.setItem('isAdmin',user.isAdmin);
            sessionStorage.setItem('isLoggedIn',true);
        }

        function setAccessToken(accessToken){
            sessionStorage.setItem('accessToken',accessToken);
        }

        function removeIdentity() {
            sessionStorage.removeItem('id');
            sessionStorage.removeItem('username');
            sessionStorage.removeItem('isAdmin');
            sessionStorage.removeItem('isLoggedIn');
            sessionStorage.removeItem('accessToken');
        }

        function getId() {
            return sessionStorage.getItem('id');
        }

        function getUsername() {
            return sessionStorage.getItem('username');
        }

        function isAdmin() {
            return sessionStorage.getItem('isAdmin');
        }

        function isLogged() {
            return sessionStorage.getItem('isLoggedIn');
        }

        function getAccessToken(){
            return sessionStorage.getItem('accessToken');
        }

        return {
            setIdentity: setIdentity,
            setAccessToken:setAccessToken,
            removeIdentity: removeIdentity,
            getId: getId,
            getUsername: getUsername,
            getAccessToken:getAccessToken,
            isAdmin: isAdmin,
            isLogged: isLogged
        }
    }]);
