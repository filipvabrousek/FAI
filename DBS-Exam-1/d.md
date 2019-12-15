```sql
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


```
