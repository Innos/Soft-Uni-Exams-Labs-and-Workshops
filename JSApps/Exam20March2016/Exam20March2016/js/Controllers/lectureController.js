var app = app || {};

app.lectureController = (function () {
    function LectureController(dataModels, viewbag) {
        this.dataModels = dataModels;
        this._viewbag = viewbag;
    }

    LectureController.prototype.loadCalendar = function (selector) {
        var _this = this;
        this.dataModels.lectureModel.getAll()
            .then(function (data) {
                _this._viewbag.showCalendar(selector, data);
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

    LectureController.prototype.loadAddLecturePage = function (selector) {
        this._viewbag.showAddLecturePage(selector);
    };

    LectureController.prototype.loadEditLecturePage = function (selector, id) {
        var _this = this;
        this.dataModels.lectureModel.get(id)
            .then(function (data) {
                _this._viewbag.showEditLecturePage(selector, data);
            }, function (error) {
                noty({
                    text: "Event could not be found",
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: "#/calendar/my/"});
                })
            })
    };

    LectureController.prototype.loadDeleteLecturePage = function (selector, id) {
        var _this = this;
        this.dataModels.lectureModel.get(id)
            .then(function (data) {
                _this._viewbag.showDeleteLecturePage(selector,data);
            }, function (error) {
                noty({
                    text: "Event could not be found",
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: "#/calendar/my/"});
                })
            })

    };

    LectureController.prototype.loadPersonalCalendar = function (selector) {
        var _this = this;
        var currentUserId = this.dataModels.userModel.getCurrentUser().userId;
        this.dataModels.lectureModel.query('?query={"_acl.creator":' + '"' + currentUserId + '"}')
            .then(function (data) {
                _this._viewbag.showPersonalCalendar(selector, data);
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

    LectureController.prototype.addLecture = function (data) {
        var _this = this;
        var lecturer = this.dataModels.userModel.getCurrentUser().username;
        var lecture = new LectureInputModel(data.title, data.start, data.end, lecturer);
        this.dataModels.lectureModel.add(lecture)
            .then(function (success) {
                noty({text: 'Event added successfully!',layout: 'top', closeWith: ['click'], type: 'info', timeout:2000});
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: "#/calendar/my/"});
                })
            }, function (error) {
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            })
    };

    LectureController.prototype.editLecture = function (data) {
        var _this = this;
        var id = data.id;
        var lecturer = this.dataModels.userModel.getCurrentUser().username;
        var lecture = new LectureInputModel(data.title, data.start, data.end, lecturer);
        this.dataModels.lectureModel.edit(id, lecture)
            .then(function (success) {
                noty({text: 'Event edited successfully!',layout: 'top', closeWith: ['click'], type: 'info', timeout:2000});
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: "#/calendar/my/"});
                })
            },function(error){
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            })
    };

    LectureController.prototype.deleteLecture = function (data) {
        var _this = this;
        var id = data.id;
        this.dataModels.lectureModel.delete(id)
            .then(function (success) {
                noty({text: 'Event deleted successfully!',layout: 'top', closeWith: ['click'], type: 'info', timeout:2000});
                $.sammy(function () {
                    this.trigger('redirectUrl', {url: "#/calendar/my/"});
                })
            },function(error){
                noty({
                    text: error.responseJSON.description,
                    layout: 'top',
                    closeWith: ['click'],
                    type: 'error',
                    timeout: 2000
                });
            })
    };

    return {
        load: function (dataModels, viewbag) {
            return new LectureController(dataModels, viewbag);
        }
    }

}());