'use strict';

angular.module('diablo.services')
    .factory('notifyService', function () {
    return {
        showPrompt: function (msg,successCallback,cancelCallback){
            noty({
                text: msg,
                type: 'confirm',
                buttons: [
                    {
                        addClass: 'btn btn-primary', text: 'Yes', onClick: successCallback
                    },
                    {
                        addClass: 'btn btn-danger', text: 'Cancel', onClick: cancelCallback
                    }
                ]
            })
        },
        showInfo: function (msg) {
            noty({text: msg, type: 'success', layout: 'topCenter', timeout: 1000});
        }, showError: function (msg, serverError) {
            // Collect errors to display from the server response
            var errors = [];
            if (serverError && serverError.error) {
                errors.push(serverError.error);
            }
            if(serverError && serverError.error_description){
                errors.push(serverError.error_description);
            }
            if(serverError && serverError.description){
                errors.push(serverError.description);
            }
            if (serverError && serverError.ModelState) {
                var modelStateErrors = serverError.ModelState;
                for (var propertyName in modelStateErrors) {
                    var errorMessages = modelStateErrors[propertyName];
                    var trimmedName = propertyName.substr(propertyName.indexOf('.') + 1);
                    for (var i = 0; i < errorMessages.length; i++) {
                        var currentError = errorMessages[i];
                        errors.push(trimmedName + ' - ' + currentError);
                    }
                }
            }
            if (errors.length > 0) {
                msg = msg + ":<br>" + errors.join("<br>");
            }
            noty({text: msg, type: 'error', layout: 'topCenter', timeout: 5000}
            );
        }
    }
});