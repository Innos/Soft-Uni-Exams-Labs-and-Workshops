var app = app || {};

app.heroesModel = (function() {
    function Heroes(credentials, requester) {
        this._requester = requester;
        this.serviceUrl = credentials.baseUrl + "/appdata/" + credentials.appId + "/heroes/";
        this.heroClassesUrl = credentials.baseUrl + "/appdata/" + credentials.appId + "/hero-classes/";
        this.credentials = credentials;
    }

    Heroes.prototype.getMyHeroes = function () {
        var url = this.serviceUrl + '?resolve=class&retainReferences=false&query={"_acl.creator":' + '"' + this.credentials.getCurrentUser().userId + '"}';
        return this._requester.get(url, this.credentials.getHeaders(false,true))
    };

    Heroes.prototype.getHero = function (id) {
        var url = this.serviceUrl + id + '?resolve=class,items,items.type&retainReferences=false';
        return this._requester.get(url, this.credentials.getHeaders(false,true))
    };

    Heroes.prototype.getHeroWithoutResolving = function (id) {
        var url = this.serviceUrl + id;
        return this._requester.get(url, this.credentials.getHeaders(false,true))
    };

    Heroes.prototype.addHero = function (data) {
        return this._requester.post(this.serviceUrl, data, this.credentials.getHeaders(true,true));
    };

    Heroes.prototype.getItems = function (id) {
        var url = this.serviceUrl + id + "?resolve=items,items.type&retainReferences=false";
        return this._requester.get(url, this.credentials.getHeaders(false,true)).then(function (data) {
            if (data.items.length > 0) {
                return data.items.map(function (item) {
                    return {
                        id: item._id,
                        name: item.name,
                        type: item.type.name
                    }
                });
            } else {
                return data.items;
            }
        });
    };

    Heroes.prototype.addItem = function (data) {
        var _this = this;
        return this.getHeroWithoutResolving(data.heroId).then(function (hero) {
            hero.items.push({
                "_type": "KinveyRef",
                "_id": data.itemId,
                "_collection": "items"
            });

            var url = _this.serviceUrl + data.heroId;
            return _this._requester.put(url, hero, _this.credentials.getHeaders(true,true));
        })
    };

    Heroes.prototype.removeItem = function (heroId, itemId) {
        var _this = this;
        return this.getHeroWithoutResolving(heroId).then(function (hero) {
            var itemIds = hero.items.map(function (item) {
                return item._id;
            });
            var indexOfItem = itemIds.indexOf(itemId);
            hero.items.splice(indexOfItem, 1);

            var url = _this.serviceUrl + heroId;
            return _this._requester.put(url, hero, _this.credentials.getHeaders(true,true));
        })
    };


    Heroes.prototype.listAvailableClasses = function () {
        var url = this.heroClassesUrl;
        return this._requester.get(url, this.credentials.getHeaders(false, true));
    };

    return {
        load: function (credentials, requester) {
            return new Heroes(credentials, requester);
        }
    }
})();