function calculateSnowball(input) {
    var kills = 0;
    var damage = 0;
    var explosives = input.slice(input.length-1)[0];
    explosives = explosives.split(" ").map(function (el){
        var coords = el.split(",");
        return {
            row:Number(coords[0]),
            col:Number(coords[1])
        };
    });

    var arrInput = input.splice(0,input.length-1);
    var matrix = [];
    for(var i = 0; i< arrInput.length;i++){
        matrix.push(arrInput[i].split(" ").map(function (el){
            return Number(el);
        }));
    }

    for(var j = 0;j<explosives.length;j++){
        if(matrix[explosives[j].row][explosives[j].col] > 0){
            kills++;
            var row = explosives[j].row;
            var col = explosives[j].col;
            damage += matrix[row][col];

            //explode
            var dmg = matrix[row][col];
            matrix[row][col] = 0;
            if(row-1 >= 0){
                matrix[row-1][col] -= dmg;
            }
            if(row+1 < matrix.length){
                matrix[row+1][col] -= dmg;
            }
            if(col-1 >= 0){
                matrix[row][col - 1] -= dmg;
            }
            if(col+1 < matrix[0].length){
                matrix[row][col+1] -= dmg;
            }
            if(row-1 >= 0 && col-1 >= 0){
                matrix[row-1][col-1] -= dmg;
            }
            if(row-1 >= 0 && col+1 < matrix[0].length){
                matrix[row-1][col+1] -= dmg;
            }
            if(row+1 < matrix.length && col-1 >= 0){
                matrix[row+1][col-1] -= dmg;
            }
            if(row+1 <matrix.length && col+1 < matrix[0].length){
                matrix[row+1][col+1] -= dmg;
            }
        }
    }

    for(var k=0;k<matrix.length;k++){
        for(var l=0;l<matrix[k].length;l++)
        {
            if(matrix[k][l] > 0){
                kills++;
                damage += matrix[k][l];
            }
        }
    }
    console.log(damage);
    console.log(kills);
}

//function explode(row,col,matrix){
//    var dmg = matrix[row][col];
//    matrix[row][col] = 0;
//    if(row-1 >= 0){
//        matrix[row-1][col] -= dmg;
//    }
//    if(row+1 < matrix.length){
//        matrix[row+1][col] -= dmg;
//    }
//    if(col-1 >= 0){
//        matrix[row][col - 1] -= dmg;
//    }
//    if(col+1 < matrix[0].length){
//        matrix[row][col+1] -= dmg;
//    }
//    if(row-1 >= 0 && col-1 >= 0){
//        matrix[row-1][col-1] -= dmg;
//    }
//    if(row-1 >= 0 && col+1 < matrix[0].length){
//        matrix[row-1][col+1] -= dmg;
//    }
//    if(row+1 < matrix.length && col-1 >= 0){
//        matrix[row+1][col-1] -= dmg;
//    }
//    if(row+1 <matrix.length && col+1 < matrix[0].length){
//        matrix[row+1][col+1] -= dmg;
//    }
//}

//var arr2 = ["10 10 10",
//            "10 10 10",
//            "10 10 10",
//            "0,0"];
//
//var arr = ["5 10 15 20",
//    "10 10 10 10",
//    "10 15 10 10",
//    "10 10 10 10",
//    "2,2 0,1"];
//
//calculateSnowball(arr);
