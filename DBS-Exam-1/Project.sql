CREATE DATABASE CMS;
use CMS;


CREATE TABLE Publishers(
idPublisher int not null primary key,
namePublisher varchar(50) not null
);

CREATE TABLE Posts(
idPost int not null primary key,
idPublisher int not null,
published date not null,
heading varchar(50) not null,
content varchar(10000) not null,
private int not null,
FOREIGN KEY (idPublisher) REFERENCES Publishers(idPublisher) ON DELETE CASCADE
);
/*idPublisher has to exists*/

CREATE TABLE Comments(
idComment int not null primary key,
idPost int not null,
idPublisher int not null,
content varchar(50) not null,
FOREIGN KEY (idPost) REFERENCES Posts(idPost) ON DELETE CASCADE,
FOREIGN KEY (idPublisher) REFERENCES Publishers(idPublisher) ON DELETE CASCADE
); 



CREATE TABLE PostCountries(
idCountry int primary key not null,
nameCountry varchar(50)
);



/*Key has to exist in both tables*/
CREATE TABLE Visitors(
idVisitors int primary key not null,
idCountry int not null,
idPost int not null,
visitDate date not null,
FOREIGN KEY (idPost) REFERENCES Posts(idPost) ON DELETE CASCADE,
FOREIGN KEY (idCountry) REFERENCES PostCountries(idCountry) ON DELETE CASCADE
);




/*4 - Zdvojení klíče pozor*/

/*ORDER MATTERS*/
INSERT INTO Publishers(idPublisher, namePublisher)
VALUES (1, "Filip Vabroušek"),
(2, "Petr Vabroušek"),
(3, "Věra Vabroušková"),
(4, "Vlastislav Trnka")


INSERT INTO Posts(idPost, idPublisher, published, heading, content, private)
VALUES (1, 1, '2018-08-09', "Hey there", "Lore ipsum...", 0),
 (2, 2, '2019-03-09', "Hey there", "Lore ipsum...", 0),
 (3, 3, '2019-06-09', "Hey there", "Lore ipsum...", 1),
 (4, 4, '2019-08-03', "Hey there", "Lore ipsum...", 1)
 
INSERT INTO Posts(idPost, idPublisher, published, heading, content, private)
VALUES (8, 1, '2018-08-07', "Hey there", "Another comment", 0)
/* COUNTRIES */


INSERT INTO Visitors(idVisitors, idCountry, idPost, visitDate)
-- VALUES (7, 10, 1, '2018-08-09'),
VALUES (17, 10, 1, '2018-08-09'),
 (8, 2,  2, '2018-08-09'),
 (9, 3,  3, '2019-08-09'),
 (10, 4, 4, '2019-08-09')
 
 INSERT INTO Visitors(idVisitors, idCountry, idPost, visitDate)
VALUES (17, 10, 1, '2018-08-09')



INSERT INTO Comments(idComment, idPost, idPublisher, content)
VALUES(1, 1, 1, "Comment 1"),
(2,2, 2, "Comment 2"),
(3, 3, 3, "Comment 3"),
(4, 4, 4, "Comment 4")


INSERT INTO PostCountries(idCountry, nameCountry)
VALUES (9, "CZE"), (10, "USA"), (11, "GBR")


/*
INSERT INTO PostCountries(idCountry, idPost, nameCountry)
VALUES (1, 1, "CZE"),
 (2, 2, "LEB"),
 (3, 3, "USA"),
 (4, 4, "MAR")*/

/* 15 Queries*/


/*1 M*/
SELECT Posts.idPost FROM Posts 
LEFT JOIN Visitors ON Posts.idPost = Visitors.idPost
LEFT JOIN PostCountries ON PostCountries.idCountry = Visitors.idCountry
WHERE nameCountry = "CZE"; -- 1


/* GET VISIT DATE OF USA VISTOR
2019-08-09 */
SELECT visitDate FROM Visitors 
LEFT JOIN PostCountries ON Visitors.idCountry = PostCountries.idCountry 
WHERE PostCountries.idCountry = 10;


/* 2 M */
SELECT Posts.content FROM Posts 
LEFT JOIN Comments ON Posts.idPost = Comments.idPost 
WHERE Comments.idPost = 1;
-- ORDER BY LENGTH(Comments.content) ASC;





/* 3 M Show Posts Published by "Filip" */
SELECT Posts.content FROM Posts LEFT JOIN Publishers ON Posts.idPublisher = Publishers.idPublisher WHERE Publishers.namePublisher = "Filip Vabroušek";

/* 5 - Get count of posts for each Publisher */
SELECT Count(*), Publishers.namePublisher FROM Posts LEFT JOIN Publishers ON Posts.idPublisher = Publishers.idPublisher GROUP BY Publishers.namePublisher; 

/*6*/
SELECT content FROM Posts WHERE idPost = 1;

/*7*/
SELECT COUNT(*) FROM Posts;

/*8 agregace*/
SELECT MAX(LENGTH(content)) FROM Posts;

/*9*/
SELECT AVG(LENGTH(content)) FROM Posts;

/*10*/
UPDATE Posts SET content = "Hey" WHERE idPost = 3;

/*11*/
DELETE FROM Comments WHERE content LIKE "%1%";

/*12 - vložení nového postu*/
INSERT INTO Posts(idPost, idPublisher, published, heading, content, private)
VALUES (9, 1, '2018-08-07', "Hey there", "Another comment", 0)

/*13 - funkce - -extrakce prvních 3. písmen */
SELECT SUBSTRING(heading, 1, 3) FROM Posts WHERE Posts.idPost = 2; -- hey

/*14*/
SELECT UPPER(content) FROM Comments GROUP BY idPublisher;

/*15*/
SELECT COUNT(*) FROM Comments WHERE idPublisher = 2; 
