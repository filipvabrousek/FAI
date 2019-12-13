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
--- Works


-- ORDER
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
 
 
/* COUNTRIES */

INSERT INTO PostCountries(idCountry, nameCountry)
VALUES (1, "CZE"),
 (2, "LEB"),
 (3, "USA"),
 (4, "MAR")


INSERT INTO Visitors(idVisitors, idCountry, idPost, visitDate)
VALUES (7, 1, 1, '2018-08-09'),
 (8, 2,  2, '2018-08-09'),
 (9, 3,  3, '2019-08-09'),
 (10, 4, 4, '2019-08-09')

INSERT INTO Comments(idComment, idPost, idPublisher, content)
VALUES(1, 1, 1, "Comment 1"),
(2,2, 2, "Comment 2"),
(3, 3, 3, "Comment 3"),
(4, 4, 4, "Comment 4")





/* 15 Queries*/

/*1*/
SELECT content FROM Posts WHERE idPost = 1;

SELECT COUNT(*) FROM Posts;

/*KOMENT85E Kpostu s ID*/






/*2
SELECT Posts.idPost FROM Posts LEFT JOIN PostSettings ON Posts.idPost = PostSettings.idSettings WHERE private = 1;*/
/* 3 SELECT ALL POSTS WITH CZECH VISITORS */
SELECT Posts.idPost FROM Posts 
LEFT JOIN Visitors ON Posts.idPost = Visitors.idPost 
LEFT JOIN Posts.idPost = Visitors.idPost WHERE nameCountry = "CZE";

/* 4 COMMENTS SORTED BY LENGTH */
SELECT Posts.content FROM Posts LEFT JOIN Comments ON Posts.idPost = Comments.idComment ORDER BY LENGTH(Comments.content) ASC;
/*SELECT 3 LONGEST PUBLIC POSTS*/
SELECT Posts.content FROM Posts LEFT JOIN PostSettings ON Posts.idPost = PostSettings.idSettings WHERE private = 0 GROUP BY LENGTH(content) LIMIT 3;


/*AVG POST LENGTH FRO LEBANON*/
SELECT AVG(LENGTH(Posts.content)) FROM Posts LEFT JOIN Visitors ON Posts.idPost = Visitors.idPost WHERE Visitors.idCountry = 8;

/* 4 SELECT LONGEST STRING */
SELECT content FROM Posts ORDER BY LENGTH(content) DESC LIMIT 1;
/* 5 */
UPDATE Posts SET heading = "Je to tady!" WHERE idPost = 1;
/* 6 */
DELETE FROM Posts WHERE idPost = 1;
/* 7 */
SELECT AVG(LENGTH(content)) FROM Posts; 
/* 8 */
SELECT content FROM Posts WHERE LEN(content) > 10;
/* 9 */

/* 13 */
UPDATE Visitors SET idPost = 21 WHERE nameCountry = "CZE";

/* 14 */
INSERT INTO Posts(idPost, published, heading, content)
VALUES (120, '2018-08-09', "Hey there", "Lore ipsum...");

/* 15 */
DELETE FROM Comments WHERE content LIKE "%1%";


/*SELECT POST WITH COMMENT 1 TEXT
SELECT Comments.content FROM Comments LEFT JOIN Posts ON Comments.idComment = Posts.idPost WHERE Commments.content = "Comment 1";
*/



/*
Vytvořte minimálně 15 zcela odlišných dotazů (minimálně 5 dotazů musí vybírat data z více jak jedné tabulky): 
výběrové s kritériem/podmínkou, 
výběrové s použitím agregací, 
výběrové s použitím funkce, 
akční dotaz – přidávací, 
akční dotaz – odstraňovací, 
akční dotaz – aktualizační. 
*/










/*
SELECT CR 
FROM table1 
WHERE len(CR) = (SELECT max(len(CR)) FROM table1)
*/


/*POST LONGER THAN 100 CHARACTERS*/
SELECT content FROM Posts WHERE LEN(content) > 100;

/* FIX BELOW*/
/*SELECT ALL POSTS FROM 2018*/
SELECT content FROM Posts WHERE published = 2018;
SELECT content FROM Posts WHERE DATEPART("year", published) = 2018;
 /*SELECT DATEDIFF("yyyy", published, getDate()) FROM Posts WHERE id = 1;*/
 SELECT DATEDIFF(published, getDate()) FROM Posts WHERE idPost= 1;
