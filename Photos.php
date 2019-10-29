<h1>Photora</h1>
<div id="hey">
<form enctype="multipart/form-data" action="index.php" method="post">
<input type="email" name="email" placeholder="Enter your email">
<input type="number" name="age" placeholder="Enter your age">
<input type="file" name="file" value="+" >
<input type="submit" name="button">
</form>
</div>

<?php
error_reporting(0);
$email = $_REQUEST["email"];
$color = "#3498db";
$friend = "";

if (isset($_FILES["file"])){
     $blob = addslashes(file_get_contents($_FILES["file"]["tmp_name"]));
     $id = rand(1000, 10000);
    
     $conno = mysqli_connect("localhost", "filipa", "password");
     mysqli_query($conno, "CREATE DATABASE Shots");  
     
     $conb = mysqli_connect("localhost", "filipa", "password", "Shots");
     mysqli_query($conb, "CREATE TABLE Users (id int primary key NOT NULL, email varchar(255), photo BLOB)");
    
     $conb = mysqli_connect("localhost", "filipa", "password", "Shots");
     $id = rand(1000, 10000);
     $blob = addslashes(file_get_contents($_FILES["file"]["tmp_name"]));
     $q = "INSERT INTO Users VALUES ('$id', '$email', '$blob')";
  
if (mysqli_query($conb, $q)){
    print("Uploaded");
} else {
    print("Error: ".mysqli_error($conb));
}  
}

if (isset($_REQUEST["page"])){
     $page = $_REQUEST["page"];
} else {
    $page = 1;
}


if ($page == 1){  

$conno = mysqli_connect("localhost", "filipa", "password", "Shots");
$data = mysqli_query($conno, "SELECT * FROM Users");
    
    print("<div class='users'>");
    
    while($row = mysqli_fetch_assoc($data)){
        print("<div class='user'>");
        print('<img src="data:image/jpeg;base64,'.base64_encode( $row['photo'] ).'"/>');
        print("<a class=\"hey\" style=\"color:$color\"  
        href=\"index.php?page=2&email=".$row["email"]."\">".$row["email"]."</a><br>");
        print("</div>");   
    }
    
    print("</div>");

    if (mysqli_num_rows($data) == 0){
        print("Table empty");
    }
    
    
} else {
    print("<h1>Welcome ".$email."</h1>"); // FROM REQUEST
    print("<div id='nice'>");
    print("<a class=\"add\" href=\"index.php?page=1&isFriend=".$email."&color=\"green\">To friend</a><br>");
    print("<a href=\"index.php?page=1\">Back</a><br>");
    print("</div>");
}
?>


<style>
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
    
    img {
        width: 6em;
        height: 6em;
        padding: 1em;
    }
    
    #photos {
        display: grid;
        grid-template-columns: 1fr 1fr 1fr;
        width: 60vw;
        margin-left: auto;
        margin-right: auto;
    }
    
    .user {
        display: flex;
        align-items: center;
        background: #ecf0f1;
        border-radius: 1em;
        margin: 1em;
    }
    
    .user img {
        border-radius: 50%;
    }
    
    .users {
        display: grid;
        grid-template-columns: 1fr;
        width: 70vw;
        margin-left: 15vw;
    }
    
    
    h2 {
        padding: 1em;
    }
</style>
