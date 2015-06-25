<?php

$text = $_GET['text'];
$minPrice = $_GET['min-price'];
$maxPrice = $_GET['max-price'];
$sort = $_GET['sort'];
$order = $_GET['order'];

$input = preg_split('/[\r\n\t]+/', $text);

$books = array();

if($minPrice > $maxPrice || $minPrice < 0) {
	$result = '<div>Error</div>';
	echo $result;
	die();
}

foreach($input as $v) {
	$book = preg_split('/\//', $v);
	if($book[3] >= $minPrice && $book[3] <= $maxPrice) {
		$books[] = $book;
	}
}

if(count($books) == 0) {
	$result = '<div>No books</div>';
	echo $result;
	die();
}

function sortGenreAsc($fb, $sb) {
	$compare = strcmp($fb[2], $sb[2]);
	if($compare == 0) {
        if (date_create_from_format("Y-m-d", $fb[4], timezone_open("Europe/Sofia"))
            > date_create_from_format("Y-m-d", $sb[4], timezone_open("Europe/Sofia"))) {
            return 1;
        } else {
            return -1;
        }
	}
	return $compare;
}

function sortGenreDesc($fb, $sb) {
	$compare = strcmp($fb[2], $sb[2]);
	$compare *= -1;
	if($compare == 0) {
        if (date_create_from_format("Y-m-d", $fb[4], timezone_open("Europe/Sofia"))
            > date_create_from_format("Y-m-d", $sb[4], timezone_open("Europe/Sofia"))) {
            return 1;
        } else {
            return -1;
        }
	}
	return $compare;
}

function sortAuthorAsc($fb, $sb) {
	$compare = strcmp($fb[0], $sb[0]);
	if($compare === 0) {
        if (date_create_from_format("Y-m-d", $fb[4], timezone_open("Europe/Sofia"))
            > date_create_from_format("Y-m-d", $sb[4], timezone_open("Europe/Sofia"))) {
            return 1;
        } else {
            return -1;
        }
	}
	return $compare;
}

function sortAuthorDesc($fb, $sb) {
	$compare = strcmp($fb[0], $sb[0]);
	$compare *= -1;
	if($compare == 0) {
        if (date_create_from_format("Y-m-d", $fb[4], timezone_open("Europe/Sofia"))
            > date_create_from_format("Y-m-d", $sb[4], timezone_open("Europe/Sofia"))) {
            return 1;
        } else {
            return -1;
        }
	}
	return $compare;
}

function sortPublishDateAsc($fb, $sb) {
    if (date_create_from_format("Y-m-d", $fb[4], timezone_open("Europe/Sofia"))
        > date_create_from_format("Y-m-d", $sb[4], timezone_open("Europe/Sofia"))) {
        return 1;
    } else {
        return -1;
    }
}

function sortPublishDateDesc($fb, $sb) {
    if (date_create_from_format("Y-m-d", $fb[4], timezone_open("Europe/Sofia"))
        > date_create_from_format("Y-m-d", $sb[4], timezone_open("Europe/Sofia"))) {
        return -1;
    } else {
        return 1;
    }
}

$dispatchSort = function ($sort, $order) use ($books) {
	$sorted = $books;
	switch($sort) {
		case 'genre': {
			if($order === 'ascending') {
				usort($sorted, 'sortGenreAsc');
			} else if($order === 'descending') {
				usort($sorted, 'sortGenreDesc');
			}
			break;
		}
		case 'author': {
			if($order === 'ascending') {
				usort($sorted, 'sortAuthorAsc');
			} else if($order === 'descending') {
				usort($sorted, 'sortAuthorDesc');
			}
			break;
		}
		case 'publish-date': {
			if($order === 'ascending') {
				usort($sorted, 'sortPublishDateAsc');
			} else if($order === 'descending') {
				usort($sorted, 'sortPublishDateDesc');
			}
			break;
		}
	}
	return $sorted;
};

$books = $dispatchSort($sort, $order);
//var_dump($books);
foreach($books as $book) {
    $result = "<div>";
    $result .= "<p>" . htmlspecialchars($book[1]) . "</p>";
    $result .= '<ul>';
	foreach($book as $v) {
        if ($v != $book[1]) {
		    $result .= "<li>" . htmlspecialchars($v) . "</li>";
        }
	}
	$result .= '</ul>';
	$result .= '</div>';
	echo $result;
}
