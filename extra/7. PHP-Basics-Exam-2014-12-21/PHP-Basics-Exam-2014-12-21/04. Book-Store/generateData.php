<?php
$sort = ['genre', 'author', 'publish-date'];

function rnum($start, $end) {
	return mt_rand($start, $end);
}

function rfloat($start, $end) {
	$n = (float)rand()/(float)getrandmax();

	return rnum($start, $end) * $n;
}

function rstr($length) {
	$seed = str_split('abcdefghijklmnopqrstuvwxyz'
		.'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
		.'0123456789!@#$%^&*()');
	shuffle($seed);
	$rand = '';
	foreach (array_rand($seed, $length) as $k) {
		$rand .= $seed[$k];
	}

	return $rand;
}

$lines = rnum(10,50);
$output = '';
$prices = [];
for($i = 0; $i < $lines; $i += 1) {
	$line = rstr(10);
	$line .= '/';
	$line .= rstr(15);
	$line .= '/';
	$line .= rstr(7);
	$line .= '/';
	$price = number_format(rfloat(5, 100), 2);
	$line .= $price;
	$prices[] = $price;
	$line .= '/';
	$date = rnum(1262055681, 1302055681);
	$line .= date('Y-m-d', $date);
	$line .= '/';
	$line .= rstr(20);
	$line .= PHP_EOL;
	$output .= $line;
}

$min = floatval(number_format($prices[rnum(0, count($prices) - 1)] / 2, 2));
$max = floatval(number_format($min * (22/7), 2));

$r = rnum(0,5);
if($r == 0) {
	// 3 5
	$min += $max; // $min = 8
	$max = $min - $max; // $max = 3
	$min = $min - $max; // $min = 5
}
if($r == 1) {
	$min *= -1;
}
$output .= $min;
$output .= PHP_EOL;
$output .= $max;
$output .= PHP_EOL;
$output .= $sort[rnum(0,2)];
$output .= PHP_EOL;

$output .= rnum(0,1) == 0 ? 'ascending' : 'descending';

echo $output;
// view page source for better understanding