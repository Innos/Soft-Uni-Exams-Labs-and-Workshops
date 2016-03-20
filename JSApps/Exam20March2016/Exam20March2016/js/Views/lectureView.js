var app = app || {};

app.lectureView = (function () {
    function showCalendar(selector, data) {
        $.get('templates/calendar.html', function (temp) {
            $(selector).html(temp);
            $("#editLecture").hide();
            $("#deleteLecture").hide();
            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: Date.now(),
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            $.sammy(function () {
                                this.trigger('redirectUrl', {url: '#/calendar/add/'});
                            })
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);
                    });
                    $('#events-modal').modal();
                }
            });
        })
    }

    function showPersonalCalendar(selector, data) {
        $.get('templates/calendar.html', function (temp) {
            $(selector).html(temp);
            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: Date.now(),
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            $.sammy(function () {
                                this.trigger('redirectUrl', {url: '#/calendar/add/'});
                            })
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);
                        $('#editLecture').on('click', function () {
                            $.sammy(function(){
                                this.trigger('redirectUrl', {url:'#/calendar/edit/' + calEvent._id})
                            })
                        });
                        $('#deleteLecture').on('click', function () {
                            $.sammy(function(){
                                this.trigger('redirectUrl', {url:'#/calendar/delete/' + calEvent._id})
                            })
                        })
                    });
                    $('#events-modal').modal();
                }
            });
        })
    }

    function attachEventListeners(){

    }

    function showAddLecturePage(selector) {
        $.get('templates/add-lecture.html', function (temp) {
            $(selector).html(temp);
            $("#addLecture").on('click', function () {
                var title = $("#title").val();
                var start = $("#start").val();
                var end = $("#end").val();

                if (!title) {
                    noty({
                        text: "Title cannot be empty!",
                        layout: 'top',
                        closeWith: ['click'],
                        type: 'error',
                        timeout: 2000
                    });
                }
                else if (!Date.parse(start) || !Date.parse(end)) {
                    noty({
                        text: "Date is not valid!",
                        layout: 'top',
                        closeWith: ['click'],
                        type: 'error',
                        timeout: 2000
                    });
                }
                else {
                    $.sammy(function () {
                        this.trigger('addLecture', {title: title, start: start, end: end});
                    })
                }
            })
        })
    }

    function showEditLecturePage(selector,data) {
        $.get('templates/edit-lecture.html', function (temp) {
            var rendered = Mustache.render(temp,data);
            $(selector).html(rendered);
            $("#editLecture").on('click', function () {
                var title = $("#title").val();
                var start = $("#start").val();
                var end = $("#end").val();
                var id = $("#editLecture").attr('data-id');
                if (!title) {
                    noty({
                        text: "Title cannot be empty!",
                        layout: 'top',
                        closeWith: ['click'],
                        type: 'error',
                        timeout: 2000
                    });
                }
                else if (!Date.parse(start) || !Date.parse(end)) {
                    noty({
                        text: "Date is not valid!",
                        layout: 'top',
                        closeWith: ['click'],
                        type: 'error',
                        timeout: 2000
                    });
                }
                else {
                    $.sammy(function () {
                        this.trigger('editLecture', {id: id, title: title, start: start, end: end});
                    })
                }
            })
        })
    }

    function showDeleteLecturePage(selector,data) {
        $.get('templates/delete-lecture.html', function (temp) {
            var rendered = Mustache.render(temp,data);
            $(selector).html(rendered);
            $("#deleteLecture").on('click', function () {
                var id = $("#deleteLecture").attr('data-id');

                $.sammy(function () {
                    this.trigger('deleteLecture', {id: id});
                })
            })
        })
    }


    return {
        load: function () {
            return {
                showCalendar: showCalendar,
                showPersonalCalendar: showPersonalCalendar,
                showAddLecturePage: showAddLecturePage,
                showEditLecturePage: showEditLecturePage,
                showDeleteLecturePage: showDeleteLecturePage
            }
        }
    }
}());