function calculateScore(input){

    var courses = {};
    var len = input.length - 1;
    for(var i = 0; i < len; i++)
    {
        var parameters = input[i].replace(/\s+/g, ' ').split(' ').filter(function(el){return !!el;}).map(function(el){return el.trim();});
        var name = parameters[0];
        var course = parameters[1];
        var score = Number(parameters[2]);
        var bonus = Number(parameters[3]);

        if(!courses[course])
        {
            courses[course] = [];
        }

        courses[course].push(score);

        if(score < 100)
        {
            console.log(name + " failed at \"" + course + "\"");
            continue;
        }

        var examPoints = score /5;
        var totalPoints = examPoints + bonus;
        var grade = (((totalPoints/80) * 4) + 2).toFixed(2);
        if(grade > 6.00)
        {
            grade = (6.00.toFixed(2));
        }
        totalPoints = parseFloat(totalPoints.toFixed(2));

        console.log(name + ": Exam - \"" + course + "\"; Points - " + totalPoints + "; Grade - " + grade);
    }

    var courseToAverage = input[i].trim();
    var average = 0;
    courses[courseToAverage].forEach(function(el){
        average += el;
    });
    average = parseFloat((average / courses[courseToAverage].length).toFixed(2));
    console.log("\"" + courseToAverage + "\" average points -> " + average);
}
