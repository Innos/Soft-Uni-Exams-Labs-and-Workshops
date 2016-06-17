var app = app || {};

app.itemsController = (function () {
    function ItemsController(dataModels, viewbag) {
        this.dataModels = dataModels;
        this._viewbag = viewbag;
    }

    ItemsController.prototype.loadStorePage = function (selector, heroId) {
        var _this = this;
        this.dataModels.itemsModel.getAll()
            .then(function (data) {
                _this._viewbag.showStorePage(selector, data, heroId);
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.description,
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            })
    };

    return {
        load: function (dataModels, viewbag) {
            return new ItemsController(dataModels, viewbag);
        }
    }

}());