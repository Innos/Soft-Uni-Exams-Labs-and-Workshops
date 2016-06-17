var app = app || {};

app.userView = (function () {
    function showLoginPage(selector) {
        $.get('templates/login.html', function (temp) {
            $(selector).html(temp);
            $("#login-button").on('click', function () {
                var username = $("#username").val();
                var password = $("#password").val();

                Sammy(function () {
                    this.trigger('login', {username: username, password: password});
                });
            })
        })
    }

    function showRegisterPage(selector) {
        $.get('templates/register.html', function (temp) {
            $(selector).html(temp);
            $("#register-button").on('click', function () {
                var username = $("#username").val();
                var password = $("#password").val();
                var passwordConfirm = $("#confirm-password").val();
                if(password === passwordConfirm){
                    Sammy(function () {
                        this.trigger('register', {username: username, password: password});
                    });
                }
                else{
                    noty({text: "Passwords do not match!" ,layout: 'top', closeWith: ['click'], type: 'error',timeout:2000});
                }
            })
        })
    }

    return {
        load: function () {
            return {
                showLoginPage: showLoginPage,
                showRegisterPage: showRegisterPage
            }
        }
    }
}());