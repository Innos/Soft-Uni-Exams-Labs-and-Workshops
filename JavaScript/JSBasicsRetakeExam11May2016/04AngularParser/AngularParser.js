function calculateAngular(input) {
    var appRegex = /^\$app=\'([^\']+)\'$/;
    var elementRegex = /^\$(controller|model|view)=\'([^\']+)\'\&app=\'([^\']+)\'$/;
    var all = {};
    var angular = {};
    for (var i = 0; i < input.length; i++) {
        var appMatch = appRegex.exec(input[i]);
        var elementMatch = elementRegex.exec(input[i]);
        if (appMatch) {
            if(all[appMatch[1]] === undefined){
                angular[appMatch[1]] = {controllers: [], models: [], views: []};
            }
            else{
                angular[appMatch[1]] = all[appMatch[1]];
            }
        }
        else if (elementMatch) {
            var app = elementMatch[3];
            var element = elementMatch[1];
            var elementName = elementMatch[2];

            if(angular[app] !== undefined){
                if (element === "controller") {
                        angular[app].controllers.push(elementName);

                }
                else if (element === "model") {
                        angular[app].models.push(elementName);


                }
                else if (element === "view") {
                        angular[app].views.push(elementName);

                }
            }
            else{
                if (all[app] === undefined) {
                    all[app] = {controllers: [], models: [], views: []};
                }
                if (element === "controller") {
                        all[app].controllers.push(elementName);

                }
                else if (element === "model") {
                        all[app].models.push(elementName);


                }
                else if (element === "view") {
                        all[app].views.push(elementName);

                }
            }
        }
    }



    function sort(object) {
        var keys = Object.keys(object);
        keys.sort(function (a, b) {
            var result = object[b].controllers.length - object[a].controllers.length;
            if (result === 0) {
                result = object[a].models.length - object[b].models.length;
            }
            return result;
        });
        var obj = {};
        for (var j = 0; j < keys.length; j++) {
            object[keys[j]].controllers.sort(stringSort);
            object[keys[j]].models.sort(stringSort);
            object[keys[j]].views.sort(stringSort);
            obj[keys[j]] = object[keys[j]];

        }
        return obj;
    }

    function stringSort(a, b) {
        return a.localeCompare(b);
    }

    angular = sort(angular);


    console.log(JSON.stringify(angular));

}

//var arr = ["$app='My Application'","$controller='My Controller'&app='My Application'","$view='My View'&app='My Application'","$model='My Model'&app='My Application'"];
//calculateAngular(arr);

var arr = ["$app='Panda Tea Party'",
    "$controller='Vitkors controller'&app='SPA'",
    "$controller='Pagination Controller'&app='Marketing Detective'",
    "$view='Vitkors View'&app='Diablo'",
    "$model='App Model'&app='Marketing Detective'",
    "$view='Responsive-design View'&app='Diablo'",
    "$controller='Register Controller'&app='Panda Tea Party'",
    "$view='Responsive-design View'&app='Panda Tea Party'",
    "$controller='Responsive-design Controller'&app='IssueTracker'",
    "$view='Register View'&app='Trello'",
    "$view='App View'&app='Marketing Detective'",
    "$model='Register Model'&app='Panda Tea Party'",
    "$view='Generator View'&app='Trello'",
    "$controller='Vitkors controller'&app='Supermarket Website'",
    "$model='Responsive-design Model'&app='Diablo'",
    "$model='View Model'&app='SPA'",
    "$view='Vitkors View'&app='Trello'",
    "$view='Login View'&app='Diablo'",
    "$model='Responsive-design Model'&app='Softuni Calendar'",
    "$controller='Pagination Controller'&app='Supermarket Website'",
    "$model='App Model'&app='Choko racoon party'",
    "$view='Your dads tvs View'&app='Office Notes'",
    "$model='App Model'&app='Softuni Calendar'",
    "$app='Supermarket Website'",
    "$model='View Model'&app='Panda Tea Party'",
    "$app='Trello'",
    "$view='View View'&app='League of Assholes'",
    "$view='Pagination View'&app='Diablo'",
    "$model='Vitkors Model'&app='Panda Tea Party'",
    "$view='Generator View'&app='Softuni Calendar'",
    "$controller='Responsive-design Controller'&app='Panda Tea Party'",
    "$controller='Content Controller'&app='Marketing Detective'",
    "$model='Pagination Model'&app='bla'",
    "$model='Register Model'&app='Office Notes'",
    "$controller='Generator Controller'&app='Marketing Detective'",
    "$view='Register View'&app='Office Notes'",
    "$model='Pagination Model'&app='Supermarket Website'",
    "$model='Pagination Model'&app='Marketing Detective'",
    "$view='Generator View'&app='SPA'",
    "$view='Vitkors View'&app='SPA'",
    "$view='Vitkors View'&app='bla'",
    "$model='Login Model'&app='Diablo'",
    "$view='Content View'&app='IssueTracker'",
    "$controller='Register Controller'&app='Supermarket Website'",
    "$view='Your dads tvs View'&app='SPA'",
    "$model='App Model'&app='Supermarket Website'",
    "$model='Pagination Model'&app='Panda Tea Party'",
    "$model='Vitkors Model'&app='bla'",
    "$model='Login Model'&app='Marketing Detective'",
    "$controller='Pagination Controller'&app='Github'",
    "$model='View Model'&app='IssueTracker'",
    "$model='Vitkors Model'&app='Github'",
    "$model='Your dads tvs Model'&app='Github'",
    "$model='Content Model'&app='Panda Tea Party'",
    "$view='Pagination View'&app='Panda Tea Party'",
    "$view='Generator View'&app='Diablo'",
    "$view='Content View'&app='Diablo'",
    "$controller='View Controller'&app='Diablo'",
    "$model='Register Model'&app='Supermarket Website'",
    "$model='Vitkors Model'&app='SPA'",
    "$model='Responsive-design Model'&app='League of Assholes'",
    "$controller='View Controller'&app='Supermarket Website'",
    "$model='App Model'&app='IssueTracker'",
    "$view='Pagination View'&app='Marketing Detective'",
    "$model='Vitkors Model'&app='Diablo'",
    "$app='IssueTracker'",
    "$model='Responsive-design Model'&app='Panda Tea Party'",
    "$model='Vitkors Model'&app='Marketing Detective'",
    "$model='Content Model'&app='Marketing Detective'",
    "$model='App Model'&app='Panda Tea Party'",
    "$app='Github'",
    "$controller='View Controller'&app='Office Notes'",
    "$model='Pagination Model'&app='League of Assholes'",
    "$model='Login Model'&app='SPA'",
    "$model='Your dads tvs Model'&app='Office Notes'",
    "$controller='Content Controller'&app='League of Assholes'",
    "$view='Register View'&app='Diablo'",
    "$view='Your dads tvs View'&app='League of Assholes'",
    "$model='Login Model'&app='Panda Tea Party'",
    "$model='Content Model'&app='Diablo'",
    "$model='Your dads tvs Model'&app='Diablo'",
    "$view='Content View'&app='League of Assholes'",
    "$model='Register Model'&app='SPA'",
    "$view='Content View'&app='Marketing Detective'",
    "$view='App View'&app='Trello'",
    "$view='Pagination View'&app='League of Assholes'];"];
calculateAngular(arr);