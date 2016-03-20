var LectureInputModel = (function(){
    function LectureInputModel(title,start,end,lecturer){
        this.title = title;
        this.start = start;
        this.end = end;
        this.lecturer = lecturer;
    }

    return LectureInputModel;
})();