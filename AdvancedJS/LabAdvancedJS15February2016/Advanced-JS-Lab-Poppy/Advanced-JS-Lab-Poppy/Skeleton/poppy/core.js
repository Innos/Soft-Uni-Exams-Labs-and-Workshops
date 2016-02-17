var poppy = (function(){
    function pop(type, title, message,callback) {
        var popup;
        switch (type) {
            case 'success':
                popup = new data.Success(title,message,type);
                break;
            case 'info':
                popup = new data.Info(title,message,type);
                break;
            case 'error':
                popup = new data.Error(title,message,type);
                break;
            case 'warning':
                popup = new data.Warning(title,message,type,callback);
                break;
        }

        // generate view from view factory
        var view = viewFactory.createPopupView(popup);

        processPopup(view, popup);
    }

    function fadeOut(el){
        el.style.opacity = 0;
        setTimeout(function(){
            var parent = el.parentNode;
            parent.removeChild(el);
        },1000);


    }

    function fadeIn(el){
        var body = document.body;
        body.appendChild(el);
        el.style.transition = "opacity 1000ms";
        el.style.opacity = 0;

        setTimeout(function(){
            el.style.opacity = 1;
        },500);
    }

    function processPopup(domView, popup) {
        fadeIn(domView);

        switch (popup._popupData.type) {
            case 'success':
                setTimeout(function() {
                    fadeOut(domView)
                },popup._popupData.timeout);
                break;
            case 'info':
                var closeButton = domView.querySelector(".poppy-close-button");
                closeButton.addEventListener("click",(function(){
                    var called = false;
                    return function(){
                        if(!called){
                            setTimeout(function(){
                                fadeOut(domView);
                            },popup._popupData.timeout);
                            called = true;
                        }
                    }
                })());
                break;
            case 'error':
                domView.addEventListener("click",function(){
                    fadeOut(domView);
                });
                break;
            case 'warning':
                domView.addEventListener("click",popup._popupData.callback);
                break;
        }
    }

    return{
        pop:pop
    }
})();


