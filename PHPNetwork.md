# Unsocial network
```php
<?php
error_reporting(0);
$email = $_REQUEST["email"];
$age = $_REQUEST["age"];
$pages = 2;
$color = "#3498db";
$friend = "";


if (isset($_REQUEST["page"])){
	 $page = $_REQUEST["page"];
} else {
    $page = 1;
}

if (isset($_REQUEST["color"])){
	 $color = $_REQUEST["color"];
} else {
    $color = "#3498db";
}

if (isset($_REQUEST["isFriend"])){
	 $friend = $_REQUEST["isFriend"];
} else {
    $friend = "";
}


$conno = mysqli_connect("localhost", "Filip", "WzV5kNGJjDEOjCoL", "Filip");
mysqli_query($conno, "CREATE DATABASE Learning");
mysqli_query($conno, "CREATE TABLE Students (email varchar(255) primary key, age int)");
mysqli_query($conno, "INSERT INTO Students (email, age) VALUES ('$email', '$age')");


$res = mysqli_query($conno, "SELECT email, age FROM Students");


if ($page == 1){

if (mysqli_num_rows($res) > 0){
    while($row = mysqli_fetch_assoc($res)){
        print("<section>");
        
        if ($friend == $row["email"]){
             print("<a class=\"high\" style=\"color:$color\"  
        
        href=\"index.php?page=2&email=".$row["email"]."\">".$row["email"]."</a><br>");
        } else {
             print("<a class=\"hey\" style=\"color:$color\"  
        
        href=\"index.php?page=2&email=".$row["email"]."\">".$row["email"]."</a><br>");
        }
        
        print("</section>");
    }
}
} else {
    print("<h1>Welcome ".$email."</h1>"); // FROM REQUEST
    print("<div id='nice'>");
    print("<a class=\"add\" href=\"index.php?page=1&isFriend=".$email."&color=\"green\">To friend</a><br>");
    print("<a href=\"index.php?page=1\">Back</a><br>");
    print("</div>");
}

//mysqli_query($conno, "DELETE Students");

?>

```

```html
<h1>Unsocial network</h1>

<div id="hey">
<form action="index.php" method="GET">
<input type="email" name="email" placeholder="Enter your email">
<input type="number" name="age" placeholder="Enter your age">
<input type="submit" name="button">
</form>
</div>
```

```css
* {
	margin: 0;
	padding: 0;
	font-family: Arial;
}

section {
	display: flex;
	justify-content: center;
	align-items: center;
	text-align: center;
}

a {
	text-decoration: none;
	color: #3498db;
	font-weight: bold;
	margin: 1em;
}

input {
	padding: 1em;
	border: none;
	border: 2px solid gray;
	border-radius: 6px;
}

.high {
	color: orange;
}

#hey {
	padding-top: 1em;
	display: flex;
	justify-content: center;
	align-items: center;
}

.add {
	display: block;
	background: gray;
	color: white;
	text-align: center;
	padding: 2em;
	width: 6em;
	margin-left: auto;
	margin-right: auto
}

h1 {
	text-align: center;
	padding-top: 1em;
}
```




<!--$sql = "CREATE TABLE Students (email varchar(255), age int) ";
$sql = $sql."INSERT INTO Students (email, age) VALUES ('.$email.', '.$age.')";
-->
