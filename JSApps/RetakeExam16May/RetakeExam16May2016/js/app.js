var app = app || {};

(function() {
    app.router = Sammy(function () {

        var baseUrl = "https://baas.kinvey.com";
        var appId = "kid_bJrVNvaoGZ";
        var appSecret = "bbe2fda7f8a34d36986309344437389f";

        var selector = '#container';
        var header = '#menu';

        var requester = app.requester.load();

        var kinveyCredentials = app.credentials.load(baseUrl,appId,appSecret);

        var data = {};
        data.credentials = kinveyCredentials;
        data.userModel = app.userModel.load(kinveyCredentials,requester);
        data.heroesModel = app.heroesModel.load(kinveyCredentials,requester);
        data.itemsModel = app.itemsModel.load(kinveyCredentials,requester);

        var userView = app.userView.load();
        var homeView = app.homeView.load();
        var heroesView = app.heroesView.load();
        var itemsView = app.itemsView.load();

        var userController = app.userController.load(data,userView);
        var homeController = app.homeController.load(data,homeView);
        var heroesController = app.heroesController.load(data,heroesView);
        var itemsController = app.itemsController.load(data,itemsView);

        this.before({except: {path: '#\/(register\/|login\/)?'}},function(){
            var sessionId = sessionStorage.getItem('sessionId');
            if(!sessionId){
                this.redirect("#/");
                return false;
            }
        });

        this.before({},function(){
            if(!kinveyCredentials.isLogged()) {
                homeController.loadGuestHeader(header);
            }
            else{
                homeController.loadHomeHeader(header);
            }
        });

        this.get('#/', function () {
            if(kinveyCredentials.isLogged()){
                homeController.loadHomePage(selector);
            }
            else{
                homeController.loadGuestPage(selector);
            }
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/heroes/list/', function () {
            heroesController.loadMyHeroesPage(selector);
        });

        this.get('#/heroes/add/', function () {
            heroesController.loadAddHeroPage(selector);
        });

        this.get('#/heroes/:id', function () {
            heroesController.loadHeroPage(selector,this.params['id']);
        });

        this.get('#/heroes/:id/store', function () {
            itemsController.loadStorePage(selector,this.params['id']);
        });

        this.bind('redirectUrl',function(e,data){
            this.redirect(data.url);
        });

        this.bind('login',function(e,data){
            userController.login(data);
        });

        this.bind('register',function(e,data){
            userController.register(data);
        });

        this.bind('addHero',function(e,data){
            heroesController.addHero(data);
        });

        this.bind('addItem',function(e,data){
            heroesController.addItem(data);
        });

    });

    app.router.run('#/');

})();