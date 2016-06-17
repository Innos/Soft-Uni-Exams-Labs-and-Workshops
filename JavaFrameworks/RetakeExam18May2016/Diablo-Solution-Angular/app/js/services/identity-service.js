'use strict';

angular.module('diablo.services')
    .factory('identityService', [function () {

        function setIdentity(user) {
            sessionStorage.setItem('accessToken',user._kmd.authtoken);
            sessionStorage.setItem('id',user._id);
            sessionStorage.setItem('username',user.username);
            sessionStorage.setItem('isLoggedIn',true);
        }

        function removeIdentity() {
            sessionStorage.removeItem('id');
            sessionStorage.removeItem('username');
            sessionStorage.removeItem('isLoggedIn');
            sessionStorage.removeItem('accessToken');
        }

        function getId() {
            return sessionStorage.getItem('id');
        }

        function getUsername() {
            return sessionStorage.getItem('username');
        }

        function isLogged() {
            return sessionStorage.getItem('isLoggedIn');
        }

        function getAccessToken(){
            return sessionStorage.getItem('accessToken');
        }

        return {
            setIdentity: setIdentity,
            removeIdentity: removeIdentity,
            getId: getId,
            getUsername: getUsername,
            isLogged: isLogged,
            getAccessToken:getAccessToken
        }
    }]);
