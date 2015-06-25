<?php
$input =json_decode($_GET['jsonTable']);
//$input = [["god","save","the","queen"],[7,2]];

$maxCols = 0;
//var_dump($input); //Uncomment this to see the input
foreach ($input[0] as $key=>$line) {
    $input[0][$key] =  AffineEncrypt($line, $input[1][0], $input[1][1]);
    $maxCols = max(strlen($line), $maxCols);
}

printTable($input, $maxCols);

function AffineEncrypt($plainText, $k, $s)
{
    $cipherText = "";

    // Put Plain Text (all capitals) into Character Array
    $chars = str_split(strtoupper($plainText));

    // Compute e(x) = (kx + s)(mod m) for every character in the Plain Text
    foreach ($chars as $c) {
        $x = ord($c)-65;
        if($x < 0) {
            $cipherText .= $c;
        }
        else {
            $cipherText .= chr((($k * $x + $s) % 26) + 65);
        }
    }

    return $cipherText;
}

function printTable($input, $maxCol) {
    echo "<table border='1' cellpadding='5'>";
    foreach($input[0] as $key=>$value) {
        echo "<tr>";
		if($maxCol > 0){
			for ($col = 0; $col < $maxCol; $col++) {
				if ($col >= strlen($value)) {
					echo "<td>";
					echo "";
				}else {
					echo "<td style='background:#CCC'>";
					echo htmlspecialchars($value[$col]);
				}
				echo "</td>";
			}
		}
		else{
			echo "<td></td>";
		}
        echo "</tr>";
    }
    echo "</table>";
}
?>
