<h1>Photora</h1>
<div id="hey">
<form enctype="multipart/form-data" action="index.php" method="post">
<input type="email" name="email" placeholder="Enter your email">
<input type="number" name="age" placeholder="Enter your age">
<input type="file" name="file" value="+" >
<input type="submit" name="button">
</form>
</div>


<h2>Photos</h2>

<?php
//error_reporting(0);
$email = $_REQUEST["email"];
//$age = $_REQUEST["age"];
$pages = 2;
$color = "#3498db";
$friend = "";


if (isset($_REQUEST["page"])){
	 $page = $_REQUEST["page"];
} else {
    $page = 1;
}

if (isset($_FILES["file"])){
$blob = addslashes(file_get_contents($_FILES["file"]["tmp_name"]));
$conno = mysqli_connect("localhost", "filipa", "password", "Shots");
$id = rand(1000, 10000);
mysqli_query($conno, "CREATE DATABASE Shots");
mysqli_query($conno, "CREATE TABLE Users (id int primary key NOT NULL, email varchar(255), photo BLOB)");
    $q = "INSERT INTO Users VALUES ('$id', '$email', '$blob')";
    mysqli_query($conno, $q);
}

if ($page == 1){   
print("<br>===========");
$conno = mysqli_connect("localhost", "filipa", "password", "Shots");
$data = mysqli_query($conno, "SELECT * FROM Users");
    while($row = mysqli_fetch_assoc($data)){
        print("<a class=\"hey\" style=\"color:$color\"  
        href=\"index.php?page=2&email=".$row["email"]."\">".$row["email"]."</a><br>");
       print('<img src="data:image/jpeg;base64,'.base64_encode( $row['photo'] ).'"/>');
        //print("<b>".$row["id"]."</b>");
    }
} else {
    print("<h1>Welcome ".$email."</h1>"); // FROM REQUEST
    print("<div id='nice'>");
    print("<a class=\"add\" href=\"index.php?page=1&isFriend=".$email."&color=\"green\">To friend</a><br>");
    print("<a href=\"index.php?page=1\">Back</a><br>");
    print("</div>");
}
?>
