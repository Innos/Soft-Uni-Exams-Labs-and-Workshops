var app = app || {};

app.heroesController = (function () {
    function HeroesController(dataModels, viewbag) {
        this.dataModels = dataModels;
        this._viewbag = viewbag;
    }

    HeroesController.prototype.loadMyHeroesPage = function (selector) {
        var _this = this;
        this.dataModels.heroesModel.getMyHeroes()
            .then(function (data) {
                _this._viewbag.showPersonalHeroes(selector, data);
            }, function (error) {
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            }).done();
    };

    HeroesController.prototype.loadAddHeroPage = function (selector) {
        var _this = this;
        this.dataModels.heroesModel.listAvailableClasses()
            .then(function (data) {
                _this._viewbag.showAddHeroPage(selector, data);
            }, function (error) {
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            }).done();
    };

    HeroesController.prototype.loadHeroPage = function (selector,id) {
        var _this = this;
        this.dataModels.heroesModel.getHero(id)
            .then(function (data) {
                _this._viewbag.showHeroPage(selector, data);
            }, function (error) {
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            }).done();
    };

    HeroesController.prototype.loadStorePage = function (selector,id) {
        var _this = this;
        this.dataModels.heroesModel.getHero(id)
            .then(function (data) {
                _this._viewbag.showStorePage(selector, data);
            }, function (error) {
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            }).done();
    };

    HeroesController.prototype.addItem = function (data) {
        var _this = this;
        this.hasItem(data.heroId, data.type).then(function (result) {
            if (result === false) {
                _this.buyItem(data);
            } else {
                noty({
                    text: 'You already have: ' + result.name + '. Do you want to throw it and buy this item instead?',
                    type: 'confirm',
                    buttons: [
                        {
                            addClass: 'btn btn-primary', text: 'Yes', onClick: function ($noty) {
                            $noty.close();
                            _this.dataModels.heroesModel.removeItem(data.heroId, result.id).then(function (_) {
                                _this.buyItem(data);
                            });
                        }
                        },
                        {
                            addClass: 'btn btn-danger', text: 'Cancel', onClick: function ($noty) {
                            $noty.close();
                        }
                        }
                    ]
                })
            }
        });
    };


    HeroesController.prototype.buyItem = function (data) {
        this.dataModels.heroesModel.addItem(data).then(function (response) {
            noty({
                theme: 'relax',
                text: 'Item bought successfully!',
                type: 'success',
                timeout: 2000,
                closeWith: ['click']
            });
            Sammy(function () {
                this.trigger('redirectUrl', {url: '#/heroes/' + data.heroId})
            })
        }, function (error) {
            noty({
                theme: 'relax',
                text: error.responseJSON.description,
                type: 'error',
                timeout: 2000,
                closeWith: ['click']
            });
        });
    };

    HeroesController.prototype.hasItem = function (heroId, type) {
        return this.dataModels.heroesModel.getItems(heroId).then(function (heroItems) {
            var heroItemsTypes = heroItems.map(function (item) {
                return item.type;
            });
            var indexInArray = $.inArray(type, heroItemsTypes);
            if (indexInArray != -1) {
                return heroItems[indexInArray];
            }
            return false;
        });
    };



    HeroesController.prototype.addHero = function (data) {
        var result = {
            name: data.name,
            class: {
                "_type": "KinveyRef",
                "_id": data.class,
                "_collection": "hero-classes"
            },
            items: []
        };

        this.dataModels.heroesModel.addHero(result)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: 'Add hero successful!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/heroes/list/'})
                })
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.description,
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };




    return {
        load: function (dataModels, viewbag) {
            return new HeroesController(dataModels, viewbag);
        }
    }

}());