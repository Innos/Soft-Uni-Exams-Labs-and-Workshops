
function removeRepeats(input){
    var len = input.length - 1;
    var n = Number(input[len]);
    input.splice(len,1);
    var nums = [];
    for(var i = 0; i < input.length; i++)
    {
        nums[i] = input[i].split(' ');
    }

    //var numbers = input.join(' ').split(' ');



    function removeNRepeats(arr, n){
        var nums2 = arr.slice();
        var num = arr[0][0];
        var equal = true;
        for(var i = 0; i < arr.length; i++) {
            for(var l = 0; l < arr[i].length; l++)
            {
                num = arr[i][l];
                equal = true;
                var row = i;
                var col = l;
                for (var j = 0; j < n; j++) {
                    if (row >= arr.length) {
                        return nums2;
                    }
                    if (arr[row][col] !== num) {
                        equal = false;
                        break;
                    }

                    if(col + 1 >= arr[row].length)
                    {
                        row += 1;
                        col = 0;
                    }
                    else{
                        col += 1;
                    }
                }

                if (equal) {
                    var row2 = i;
                    var col2 = l;
                    for (var j = 0; j < n; j++) {
                        nums2[row2][col2] = '';
                        if(col2 + 1 >= arr[row2].length)
                        {
                            row2 += 1;
                            col2 = 0;
                        }
                        else{
                            col2 += 1;
                        }
                    }
                }
            }
        }
    }

    var numbers = removeNRepeats(nums,n);
    for(i =0; i< input.length; i++)
    {
        numbers[i] = numbers[i].filter(function(el){return !!el;})
        if(numbers[i].length === 0)
        {
            console.log("(empty)");
        }
        else{
            console.log(numbers[i].join(" "));
        }

    }
}




