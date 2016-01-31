

function regMatch(input) {
	var firstWords = input[0].split(/\W/).filter(function(el){return !!el}).map(function(el){return el.toLowerCase();});
	
	var counts = {};
	firstWords.forEach(function(x) { counts[x] = (counts[x] || 0)+1; });
	firstWords = [];
	for(var word in counts){
		if(counts[word] >= 3){
			firstWords.push(word);
		}
	}

	if(firstWords.length === 0)
	{
		console.log("No words");
		return;
	}
	
	var secondSentances = [];
	

	
	var regex = /[A-Z][^\.!\?]+(!|\?|\.)/g;
	var match;
	while(match = regex.exec(input[1]))
	{
		secondSentances.push(match[0]);
	}

	
	var result = [];
	for(var sentance in secondSentances)
	{
		var repeats = 0;
		for(var word in firstWords)
		{
			var regex = new RegExp("([^a-zA-Z]|^)" + firstWords[word] + "([^a-zA-Z]|$)", "i");
			var match;
			if(match = regex.exec(secondSentances[sentance]))
			{

				repeats++;
			}
		}

		if(repeats > 1 || repeats === firstWords.length)
		{
			result.push(secondSentances[sentance]);
		}
		
	}
	
	if(result.length == 0)
	{
		console.log("No sentences");
	}
	else{
		console.log(result.join("\n"));
	}

	
	
}

