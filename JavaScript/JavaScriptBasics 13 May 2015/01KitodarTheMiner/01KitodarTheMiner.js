function mining(input) {
	var silver = 0;
	var gold = 0;
	var diamonds = 0;
	var regex = /mine\s+[^\s]*\s*\-\s+(gold|silver|diamonds)\s*:\s*(\d+)/;
	var match;
	for(var line in input)
	{
		if(match = regex.exec(input[line]))
		{
			if(match[1] === 'gold')
			{
				gold += Number(match[2]);
			}
			else if(match[1] === 'silver')
			{
				silver += Number(match[2]);
			}
			else if(match[1] === 'diamonds')
			{
				diamonds += Number(match[2]);
			}
		}
	}
    console.log("*Silver: " + silver);
	console.log("*Gold: " + gold);
	console.log("*Diamonds: " + diamonds);
}
