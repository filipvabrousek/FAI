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

if (isset($_REQUEST["isFriend"])){
	 $friend = $_REQUEST["isFriend"];
} else {
    $friend = "";
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
}else {
    print("<h1>Welcome ".$email."</h1>"); // FROM REQUEST
    print("<div id='nice'>");
    print("<a class=\"add\" href=\"index.php?page=1&isFriend=".$email."&color=\"green\">To friend</a><br>");
    print("<a href=\"index.php?page=1\">Back</a><br>");
    print("</div>");
}











/*
if ($page == 1){
    
$res = "SELECT * FROM Users";
print("<h2>Users</h2>");
if (mysqli_num_rows($res) > 0){
    while($row = mysqli_fetch_assoc($res)){
        print("<section>");
        
        if ($friend == $row["email"]){
             print("<a class=\"high\" style=\"color:$color\"  
        
        href=\"index.php?page=2&email=".$row["email"]."\">".$row["email"]."</a><br>");
        } else {
                     
         $data = $row["photo"];
      print('<img src="data:image/jpeg;base64,'.base64_encode($data).'"/>');
            
            
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


//  mysqli_query($conno, "DELETE Students");

 // http://talkerscode.com/webtricks/upload%20image%20to%20database%20and%20server%20using%20HTML,PHP%20and%20MySQL.php
*/
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
    



</style>
