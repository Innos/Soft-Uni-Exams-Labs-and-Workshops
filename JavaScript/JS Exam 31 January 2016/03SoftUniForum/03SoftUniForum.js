function format(input) {
    var len = input.length - 1;
    var banned = input[len].split(" ");
    input.splice(len, 1);
    var text = input.join('\n');

    var key = 0;
    var mask = '-~-';

    var codeRegex = /<code>[^<]*<\/code>/g;
    var match;
    var codes = [];
    while(match = codeRegex.exec(text)){
        codes.push(match)
    }
    codes.forEach(function(el){
        text = text.replace(el,mask + key + mask);
        key++;
    });
    var regex = /#([a-zA-Z][a-zA-Z0-9_\-]+[a-zA-Z0-9])\b/g;
    while (match = regex.exec(text)) {
        if (banned.indexOf(match[1]) !== -1) {
            var ban = match[1].replace(/./g, '*');
            text = text.replace(match[0], ban);
        }
        else {
            text = text.replace(match[0], "<a href=\"/users/profile/show/" + match[1] + "\">" + match[1] + "<\/a>")
        }

    }
    for (var i = 0; i < key; i++) {
        text = text.replace(mask + i + mask,codes[i])
    }
    console.log(text);
}
//
//var input = ["#RoYaL: I'm not sure what you mean,", "but I am confident that I've written", "everything correctly. Ask #iordan_93", "and #pesho if you don't believe me", "<code>", "#trying to print stuff", "print(\"yoo\")", "</code>", "pesho gosho"]
//var input2 = [
//"#trifon",
//    "#Mega_trifon",
//    "#mega_trifon-ApoV",
//    "#are_trifone",
//    "#machkai_trifkaa",
//    "#balgaria_nad-sichk0",
//    "#Von_ApovBerger",
//    "Pitah go kolegata kakyw e problema, ama na nito edin ot teq",
//    "iusarneimi ne mi otgowarq kakwo da parwq??!",
//    "za kontakti: #stamat",
//    "stamat",
//];
//
//format(input2);


