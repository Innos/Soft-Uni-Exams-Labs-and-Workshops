
function tasksCalc(input){

    var tasksNums = {};
    for(var i = 0; i< input.length;i++)
    {
        var params = input[i].split("&").map(function(el){return el.trim()});
        var name = params[0];
        var type = params[1];
        var taskNumber = Number(params[2]);
        var score = Number(params[3]);
        var lines = Number(params[4]);

        var task = "Task " + taskNumber;

        if(!tasksNums[task])
        {
            tasksNums[task] = {tasks: [], average: 0, lines: 0};
        }

        tasksNums[task].tasks.push({name: name, type: type});

        tasksNums[task].average += score;
        tasksNums[task].lines += lines;

    }

    for(var task2 in tasksNums){
            tasksNums[task2].average = parseFloat((tasksNums[task2].average / tasksNums[task2].tasks.length).toFixed(2));
            tasksNums[task2].tasks.sort(function(a,b){
                return a.name.localeCompare(b.name);
            });
        }
    function sort(object){
        var keys = Object.keys(object);
        keys.sort(function(a,b){
            var result = object[b].average - object[a].average;
            if(result === 0)
            {
                result = object[a].lines - object[b].lines;
            }
            return result;
        });
        var obj = {};
        for(var j = 0;j <keys.length;j++){
            obj[keys[j]] = object[keys[j]];
        }
        return obj;
    }

    var result = sort(tasksNums);
    console.log(JSON.stringify(result));

    }




