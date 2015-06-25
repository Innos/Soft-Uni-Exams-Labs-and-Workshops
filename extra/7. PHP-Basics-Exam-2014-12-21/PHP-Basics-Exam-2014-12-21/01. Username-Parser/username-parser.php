<?php
$items = parseInputList();
$length = $_GET['length'];
$showUsername = isset($_GET['show']);

echo "<ul>";
foreach ($items as $item) {
    if (strlen($item) >= $length) {
        // Small usernames stay unchanged
        $text = "<li>" . htmlspecialchars($item) . "</li>";
    } else {
        // Long usernames get colored or removed
        if ($showUsername) {
            $text = '<li style="color: red;">' . htmlspecialchars($item) . "</li>";
        }
        else {
            $text = "";
        }
    }
    echo $text;
}
echo "</ul>";

function parseInputList() {
    $list = $_GET['list'];
    $lines = preg_split('/\n/', $list);
    $result = [];
    foreach ($lines as $line) {
        $line = trim($line);
        if ($line != "") {
            $result[] = $line;
        }
    }
    return $result;
}
