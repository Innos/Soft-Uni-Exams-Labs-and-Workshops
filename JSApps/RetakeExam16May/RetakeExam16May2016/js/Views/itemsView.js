var app = app || {};

app.itemsView = (function () {
    function showStorePage(selector, items, heroId) {
        $.get('templates/store.html', function (temp) {
            var loadTemplate = Mustache.render(temp, {items: items});
            $(selector).html(loadTemplate);

            $(".buy").on('click', function () {
                var itemId = $(this).attr('data-id');
                var type = $(this).attr('data-type');
                Sammy(function () {
                    this.trigger('addItem', {itemId: itemId, heroId: heroId, type: type})
                })
            })
        })
    }

    return {
        load: function () {
            return {
                showStorePage: showStorePage
            }
        }
    }
}());