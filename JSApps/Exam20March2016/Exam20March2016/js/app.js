var app = app || {};

(function() {
    app.router = Sammy(function () {

        var baseUrl = "https://baas.kinvey.com";
        var appId = "kid_Zk3_L3EakZ";
        var appSecret = "9da0fd1e43304df2b441f8db60f8b73b";

        var selector = '#container';
        var header = '#menu';

        var requester = app.requester.load();

        var kinveyCredentials = app.credentials.load(baseUrl,appId,appSecret);

        var data = {};
        data.userModel = app.userModel.load(kinveyCredentials,requester);
        data.lectureModel = app.lectureModel.load(kinveyCredentials,requester);

        var userView = app.userView.load();
        var homeView = app.homeView.load();
        var lectureView = app.lectureView.load();

        var userController = app.userController.load(data,userView);
        var homeController = app.homeController.load(data,homeView);
        var lectureController = app.lectureController.load(data,lectureView);

        this.before({except: {path: '#\/(register\/|login\/)?'}},function(){
            var sessionId = sessionStorage.getItem('sessionId');
            if(!sessionId){
                this.redirect("#/");
                return false;
            }
        });

        this.before({},function(){
            var sessionId = sessionStorage.getItem('sessionId');
            if(!sessionId) {
                homeController.loadGuestHeader(header);
            }
            else{
                homeController.loadHomeHeader(header);
            }
        });

        this.get('#/', function () {
            homeController.loadGuestPage(selector);
        });

        this.get('#/home/', function () {
            homeController.loadHomePage(selector);
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

        this.get('#/calendar/list/', function () {
            lectureController.loadCalendar(selector);
        });

        this.get('#/calendar/my/', function () {
            lectureController.loadPersonalCalendar(selector);
        });

        this.get('#/calendar/add/', function () {
            lectureController.loadAddLecturePage(selector);
        });

        this.get('#/calendar/edit/:id', function () {
            lectureController.loadEditLecturePage(selector,this.params['id']);
        });

        this.get('#/calendar/delete/:id', function () {
            lectureController.loadDeleteLecturePage(selector,this.params['id']);
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

        this.bind('addLecture',function(e,data){
            lectureController.addLecture(data);
        });

        this.bind('editLecture',function(e,data){
            lectureController.editLecture(data);
        });

        this.bind('deleteLecture',function(e,data){
            lectureController.deleteLecture(data);
        });

    });

    app.router.run('#/');

})();