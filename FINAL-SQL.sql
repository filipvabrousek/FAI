CREATE DATABASE CMS;
use CMS;


CREATE TABLE Posts(
idPost int not null primary key not null,
published date not null,
heading varchar(50) not null,
content varchar(10000) not null,
);

CREATE TABLE Comments(
idComment int not null primary key not null,
content varchar(50) not null,
FOREIGN KEY idPost REFERENCES Post(idPost) ON DELETE CASCADE
);


CREATE TABLE PostSettings(
idSettings int primary key not nullm
private int not null,
FOREIGN KEY idPost REFERENCES Post(idPost) ON DELETE CASCADE
);



/*4 - */

INSERT INTO Posts(idPost, published, heading, content)
VALUES (1, "2018-08-09", "Hey there", "Lore ipsum...");
VALUES (2, "2019-03-09", "Hey there", "Lore ipsum...");
VALUES (3, "2019-06-09", "Hey there", "Lore ipsum...");
VALUES (4, "2019-08-03", "Hey there", "Lore ipsum...");


INSERT INTO PostSettings(idSettings, private);
VALUES(1, 0);
VALUES(2, 0);
VALUES(3, 1);
VALUES(4, 1);


INSERT INTO Comments(idComment, content);
VALUES(1, "Hello");
VALUES(2, "Mello");
VALUES(3, "Mello");
VALUES(4, "Mello");


/*5 Queries*/

/*POST LONGER THAN 100 CHARACTERS*/
SELECT content FROM Posts WHERE LEN(content) > 100;

/*SELECT ALL PRIVATE POSTS*/
SELECT idPost FROM Posts LEFT JOIN PostSettings ON Posts.idPosts = PostSettings.idSettings WHERE private = 1;

/*SELECT ALL POSTS FROM 2018*/
SELECT content FROM Posts WHERE DATEPART(YEAR(date)) = 2018;

/*SELECT POST WITH ID 1*/
SELECT content FROM Posts WHERE id = 1;

/*GROUP POSTS BY YEAR */

SELECT content FROM Posts WHERE id = 1;
