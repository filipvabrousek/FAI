CREATE DATABASE CMS;
use CMS;


CREATE TABLE Posts(
idPost int not null primary key,
published date not null,
heading varchar(50) not null,
content varchar(10000) not null
);

CREATE TABLE Comments(
idComment int not null primary key,
idPost int not null,
content varchar(50) not null,
FOREIGN KEY (idPost) REFERENCES Posts(idPost) ON DELETE CASCADE
);

/*Key has to exist in both tables*/
CREATE TABLE PostSettings(
idSettings int primary key not null,
idPost int not null,
private int not null,
FOREIGN KEY (idPost) REFERENCES Posts(idPost) ON DELETE CASCADE
);


/*Key has to exist in both tables*/
CREATE TABLE Visitors(
idCountry int primary key not null,
idPost int not null,
nameCountry varchar(50),
FOREIGN KEY (idPost) REFERENCES Posts(idPost) ON DELETE CASCADE
);




/*4 - Zdvojení klíče pozor*/

INSERT INTO Visitors(idCountry, idPost, nameCountry)
VALUES (7, 1,  "CZE"),
 (8, 2,  "LEB"),
 (9, 3,  "USA"),
 (10, 4,  "FRA")

INSERT INTO Posts(idPost, published, heading, content)
VALUES (7, '2018-08-09', "Hey there", "Lore ipsum..."),
 (8, '2019-03-09', "Hey there", "Lore ipsum..."),
 (9, '2019-06-09', "Hey there", "Lore ipsum..."),
 (10, '2019-08-03', "Hey there", "Lore ipsum...")


INSERT INTO PostSettings(idSettings, idPost, private)
VALUES
(1, 1, 0),
(2, 2, 0),
(3, 3, 1),
(4, 4, 1)


INSERT INTO Comments(idComment, idPost, content)
VALUES(1, 1, "Comment 1"),
(2,2, "Comment 2"),
(3, 3, "Comment 3"),
(4, 4, "Comment 4");

/*5 Queries*/

/*SELECT POST WITH ID 1*/
SELECT content FROM Posts WHERE idPost = 1;


/*SELECT ALL PRIVATE POSTS*/
SELECT Posts.idPost FROM Posts LEFT JOIN PostSettings ON Posts.idPost = PostSettings.idSettings WHERE private = 1;

/*SELECT ALL POSTS WITH CZECH VISITORS */
SELECT Posts.idPost FROM Posts LEFT JOIN Visitors ON Posts.idPost = Visitors.idPost WHERE nameCountry = "CZE";

/*SELECT LONGEST STRING */
SELECT content FROM Posts ORDER BY LENGTH(content) DESC LIMIT 1;

/*UPDATE*/
UPDATE Posts SET heading = 1 WHERE idPost = 1;
