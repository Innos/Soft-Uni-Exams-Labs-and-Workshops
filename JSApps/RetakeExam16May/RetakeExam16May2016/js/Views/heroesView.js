var app = app || {};

app.heroesView = (function () {

    function showPersonalHeroes(selector, data) {
        if (data.length !== 0) {
            data = remapData(data);
            $.get('templates/heroes.html', function (temp) {
                var loadedTemplate = Mustache.render(temp, {heroes: data});
                $(selector).html(loadedTemplate);
            });
        } else {
            $.get('templates/no-heroes.html', function (temp) {
                var loadedTemplate = Mustache.render(temp);
                $(selector).html(loadedTemplate);
            });
        }
    }

    function showAddHeroPage(selector, data) {
        $.get('templates/add-hero.html', function (temp) {
            var loadedTemplate = Mustache.render(temp, {classes: data});
            $(selector).html(loadedTemplate);

            $('#addHero').on('click', function () {
                var name = $('#name').val();
                var heroClass = $('input[name=class]:checked').val();
                Sammy(function () {
                    this.trigger('addHero', {name: name, class: heroClass});
                })
            })
        })
    }

    function showHeroPage(selector, data) {
        data = remapDataWithItems(data);
        $.get('templates/hero.html', function (temp) {
            var loadedTemplate = Mustache.render(temp, data);
            $(selector).html(loadedTemplate);

            $('#addHero').on('click', function () {
                var name = $('#name').val();
                var heroClass = $('input[name=class]:checked').val();
                Sammy(function () {
                    this.trigger('addHero', {name: name, class: heroClass});
                })
            })
        })
    }

    function remapData(data) {
        return data.map(function (hero) {
            var imgUrl;
            if (hero.class.name.toLowerCase() === "barbarian") {
                imgUrl = "imgs/barbarian.png";
            } else if (hero.class.name.toLowerCase() === "amazon") {
                imgUrl = "imgs/amazon.png";
            }

            return {
                id: hero._id,
                name: hero.name,
                imageUrl: imgUrl
            }
        });
    }

    function remapDataWithItems(hero) {
        var items;
        if (hero.items.length > 0) {
            items = hero.items.map(function (item) {
                return {
                    name: item.name,
                    attackPoints: item["attack-points"],
                    defensePoints: item["defense-points"],
                    lifePoints: item["life-points"],
                    type: item.type.name
                }
            });
        }
        else {
            items = [];
        }

        var baseAttackPoints = hero["class"]["attack-points"],
            baseDefensePoints = hero["class"]["defense-points"],
            baseLifePoints = hero["class"]["life-points"];

        var attackPointsFromItems = 0, defensePointsFromItems = 0, lifePointsFromItems = 0;
        items.forEach(function (item) {
            attackPointsFromItems += Number(item.attackPoints);
            defensePointsFromItems += Number(item.defensePoints);
            lifePointsFromItems += Number(item.lifePoints);
        });

        var attackPoints = baseAttackPoints + attackPointsFromItems,
            defensePoints = baseDefensePoints + defensePointsFromItems,
            lifePoints = baseLifePoints + lifePointsFromItems;

        var imageUrl;
        var className = hero["class"]["name"].toLowerCase();

        if (className == "barbarian") {
            imageUrl = "imgs/barbarian.png"
        } else if (className == "amazon") {
            imageUrl = "imgs/amazon.png"
        }

        return {
            id: hero._id,
            name: hero.name,
            attackPoints: attackPoints,
            defensePoints: defensePoints,
            lifePoints: lifePoints,
            imageUrl: imageUrl,
            items: items
        }
    }


    return {
        load: function () {
            return {
                showPersonalHeroes: showPersonalHeroes,
                showAddHeroPage: showAddHeroPage,
                showHeroPage: showHeroPage
            }
        }
    }
}());