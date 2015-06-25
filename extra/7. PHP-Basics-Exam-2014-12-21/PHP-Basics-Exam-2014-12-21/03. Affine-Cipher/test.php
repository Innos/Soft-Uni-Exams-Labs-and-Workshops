<?php
function getNumber($elem){
    if(ord($elem)>=ord("a") && ord($elem)<=ord('z'))
        return abs(ord($elem)-ord("a"));
    if(ord($elem)>=ord("A") && ord($elem)<=ord('Z'))
        return abs(ord($elem)-ord("A"));
}

function findTableWidth($arr){
    $res=0;
    foreach($arr as $str){
        if(strlen($str)>$res){
            $res=strlen($str);
        }
    }
    return $res;
}

$input = $_GET['jsonTable'];
$pattern = "/\[*(.+)\]\s*\,\[([\d\,\s*]+)/m";
preg_match_all($pattern,$input,$matches);
$strings = trim($matches[1][0]);
$values = trim($matches[2][0]);
$values = explode(",",$values);
$pattern2 = "/\"\,*\"*/m";
$strings = preg_split($pattern2,$strings,-1,PREG_SPLIT_NO_EMPTY);
for($i=0;$i<count($values);$i++)
    $values[$i] = (int)$values[$i];
//var_dump($values);
$k = $values[0];
$s = $values[1];
$result = [];
foreach($strings as $word){
    $tmp = str_split($word);
    $tableLine = [];
    //var_dump($tmp);
    foreach($tmp as $element){
        if((ord($element)>=ord("a") && ord($element)<=ord('z')) || ((ord($element)>=ord("A") && ord($element)<=ord('Z'))))
            $tableLine[] = chr(ord("A")+((($k*getNumber($element))+$s)%26));
        else
            $tableLine[] = $element;
    }
    $result[] = $tableLine;
}
echo '<table border=' . '\'1\' cellpadding=\'5\'>';
foreach($result as $element){
    echo '<tr>';
    for($i=0;$i<findTableWidth($strings);$i++){
        if(isset($element[$i])){
            echo '<td style=\'background:#CCC\'>' . htmlspecialchars($element[$i]) . '</td>';
        }
        else{
            echo '<td></td>';
        }
    }
    echo '</tr>';
}
echo '</table>';
//var_dump($result);
?>