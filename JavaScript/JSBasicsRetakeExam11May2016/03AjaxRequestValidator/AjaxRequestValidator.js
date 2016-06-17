function calculateAjax(input) {
    var methodRegex = /^Method: (GET|POST|PUT|DELETE)$/;
    var credentialsRegex = /^Credentials: (Bearer|Basic) ([a-zA-Z0-9]+)$/;
    var contentRegex = /^Content: [a-zA-Z0-9\.]*$/;

    var hash = input.slice(input.length -1)[0];
    var requests = input.splice(0,input.length-1);

    for(var i=0;i<requests.length;i=i+3)
    {
        var methodMatch = methodRegex.exec(requests[i]);
        var credentialsMatch = credentialsRegex.exec(requests[i+1]);
        var contentMatch = contentRegex.exec(requests[i+2]);

        if(methodMatch && credentialsMatch && contentMatch){
            if(methodMatch[1] !== "GET" && credentialsMatch[1] === "Basic"){
                console.log("Response-Method:" + methodMatch[1] + "&Code:401");
            }
            else{
                var lettersByCount = {};
                var header = credentialsMatch[2];
                for(var j=0;j<header.length;j++){
                    if(!lettersByCount[header[j]]){
                        lettersByCount[header[j]] = 0;
                    }
                    lettersByCount[header[j]]++;
                }

                var hashPairs = [];
                for(var k=0;k<hash.length;k=k+2){
                    var pair = {};
                    pair.number = Number(hash[k]);
                    pair.letter = hash[k+1];
                    hashPairs.push(pair);
                }

                var hashDecoded = false;
                for(var l=0;l<hashPairs.length;l++){
                    var curLetter = hashPairs[l].letter;
                    if(lettersByCount[curLetter] === hashPairs[l].number || (!lettersByCount[curLetter] && hashPairs[l].number === 0)){
                        hashDecoded = true;
                        break;
                    }
                }

                if(hashDecoded === true){
                    console.log("Response-Method:" + methodMatch[1] + "&Code:200&Header:" + header);
                }
                else{
                    console.log("Response-Method:" + methodMatch[1] + "&Code:403");
                }
            }
        }
        else{
            console.log("Response-Code:400");
        }
    }
}
//
//var arr = ["Method: GET",
//"Credentials: Bearer asd918721jsdbhjslkfqwkqiuwjoxXJIdahefJAB",
//"Content: users.asd.1782452.278asd",
//"Method: POST",
//"Credentials: Basic 028591u3jtndkgwndsdkfjwelfqkjwporjqebhas",
//"Content: Johnathan",
//"0p"];
//
//var arr2 = ["Method: PUT",
//"Credentials: Bearer as9133jsdbhjslkfqwkqiuwjoxXJIdahefJAB",
//"Content: users.asd/1782452$278///**asd123",
//"Method: POST",
//"Credentials: Bearer 028591u3jtndkgwndskfjwelfqkjwporjqebhas",
//"Content: Johnathan",
//"Method: DELETE",
//"Credentials: Bearer 05366u3jtndkgwndssfsfgeryerrrrrryjihvx",
//"Content: This.is.a.sample.content",
//"2d5g"];
//
//
//calculateAjax(arr);
//
//fs = require('fs');
//// Asynchronous read
//fs.readFile('../Tests/test.010.in.txt', function (err, data) {
//    if (err) {
//        return console.error(err);
//    }
//    calculateAjax(data.toString().trim().split('\r\n'));
//});