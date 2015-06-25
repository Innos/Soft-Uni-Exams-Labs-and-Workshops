<?php
$keysString = $_GET['keys'];
$textString = $_GET['text'];

$startKeyRegex = "/^([a-zA-Z_]+)\d+/";
$endKeyRegex = "/\d+([a-zA-Z_]+)$/";
preg_match($startKeyRegex, $keysString, $startKey);
preg_match($endKeyRegex, $keysString, $endKey);

if (!$startKey || !$endKey) {
    echo "<p>A key is missing</p>";
} else {
    $startKey = $startKey[1];
    $endKey = $endKey[1];

    $numbersRegex = "/" . $startKey . "(.*?)" . $endKey . "/";
    preg_match_all($numbersRegex, $textString, $matches);

    $total = 0;
    foreach($matches[1] as $match) {
        if (is_numeric($match) && $matches != "") {
            $total += $match;
        }
    }
    echo "<p>The total value is: <em>";
    echo $total != 0 ? $total : 'nothing';
    echo "</em></p>";
}