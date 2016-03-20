var app = app || {};

app.homeView = (function () {
    function showGuestPage(selector) {
        $.get('templates/welcome-guest.html', function (temp) {
            $(selector).html(temp);
        })
    }

    function showGuestHeader(selector) {
        $.get('templates/menu-login.html', function (temp) {
            $(selector).html(temp);
        })
    }

    function showHomePage(selector,data) {
        $.get('templates/welcome-user.html', function (temp) {
            var rendered = Mustache.render(temp,data);
            $(selector).html(rendered);
        })
    }

    function showHomeHeader(selector) {
        $.get('templates/menu-home.html', function (temp) {
            $(selector).html(temp);
        })
    }

    return {
        load: function () {
            return {
                showGuestPage: showGuestPage,
                showGuestHeader: showGuestHeader,
                showHomePage: showHomePage,
                showHomeHeader: showHomeHeader
            }
        }
    }
}());