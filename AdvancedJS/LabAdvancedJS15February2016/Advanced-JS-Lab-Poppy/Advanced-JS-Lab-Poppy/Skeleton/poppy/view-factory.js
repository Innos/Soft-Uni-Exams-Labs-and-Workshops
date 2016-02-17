var viewFactory = (function(){
    var CLOSE_BUTTON_TEXT = '×',
        POSITIONS = {
            'topLeft': 'poppy-top-left',
            'topRight': 'poppy-top-right',
            'bottomLeft': 'poppy-bottom-left',
            'bottomRight': 'poppy-bottom-right'
        },
        POPUP_TYPES = {
            'error': 'poppy-error',
            'info': 'poppy-info',
            'success': 'poppy-success',
            'warning': 'poppy-warning'
        };

    function createPopupView(popup) {
        var popupData = popup._popupData,
            positionClass = POSITIONS[popupData.position],
            typeClass = POPUP_TYPES[popupData.type],
            autoHide = popupData.autoHide || false,
            timeout = popupData.timeout,
            close = popupData.closeButton || false,
            title = popupData.title,
            message = popupData.message,
            callback = popupData.callback;

        var containerNode = document.createElement('div'),
            popupNode = document.createElement('div'),
            button = document.createElement('button'),
            titleNode = document.createElement('div'),
            messageNode = document.createElement('div');

        attachClasses();

        if (close === true) {
            button.textContent = CLOSE_BUTTON_TEXT;
            button.setAttribute('type', 'button');
            button.className += "poppy-close-button";
            popupNode.appendChild(button);
        }

        containerNode.appendChild(popupNode);
        popupNode.appendChild(titleNode);
        popupNode.appendChild(messageNode);

        return containerNode;

        function attachClasses() {
            containerNode.className += positionClass + ' poppy-container';
            popupNode.className += typeClass;
            titleNode.className += "poppy-title";
            titleNode.textContent = title;
            messageNode.className += "poppy-message";
            messageNode.textContent = message;
        }
    }

    return {
        createPopupView:createPopupView
    }
})();


