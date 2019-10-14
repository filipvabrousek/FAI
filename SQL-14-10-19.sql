/*SELECT Jmeno, Prijimeni FROM Student
WHERE Prijimeni LIKE '_D';
WHERE Prijimeni IS NULL;
*/

/*
SELECT Prijimeni, Vek, Vek = 7;
FROM Student
WHERE Rocnik = 1;

SELECT DISTINCT Jmeno FROM Student;
*/

/*na 2. místě*/
/*
WHERE Prijimeni LIKE '_D';
WHERE Jmeno="Petr" OR Jmeno="Zdenka"
WHERE Vek BETWEEN 20 AND 25;*/
/*WHERE (Vek <= 20 OR Vek <= 25) AND rocnik = 1;*/


/*---1---
CREATE TABLE Ustav (
UstavID int not null primary key,
Nazev varchar(50) not null
);
*/
GO
/*---2---
ALTER TABLE Ucitel
ADD UstavID int FOREIGN KEY REFERENCES Ustav(UstavID);
*/
/*---3---
ALTER TABLE Student
ADD StudijniPrumer decimal(3,2)
GO;
*/
/*---4---*/
SELECT Jmeno, Prijmeni FROM Ucitel
WHERE titul IS NULL;

/*---5---*/
UPDATE Ucitel
SET titul = 'Ing.' WHERE titul IS NULL;

/*---6---*/
SELECT Jmeno, Prijmeni FROM Student WHERE Rocnik = 1;

/*---7---*/
SELECT Prijmeni FROM Ucitel WHERE Prijmeni LIKE 'N%';

/*---8---*/
SELECT Jmeno, Prijmeni FROM Student
WHERE StudijniPrumer < 1.5 AND vek < 25;

/*---9---*/
UPDATE Predmet 
SET Mistnost = '52-205'
WHERE Nazev = 'DBS';

/*---10---*/
SELECT Jmeno, Prijmeni FROM Student WHERE StudijniPrumer > 1 AND 
StudijniPrumer < 2;


/*---11---*/
INSERT INTO Student
VALUES ('Filip', 'Vabroušek', '20', '1', '1', '2');
INSERT INTO Student
VALUES ('Filip', 'Vabroušek', '20', '1', '1', '2');

/*---12---*/
SELECT Mistnost FROM Predmet WHERE Nazev = 'DBS';

/*---13---*/
/*---14---*/

/* https://utbcz-my.sharepoint.com/personal/psilhavy_utb_cz/_layouts/15/onedrive.aspx?id=%2Fpersonal%2Fpsilhavy%5Futb%5Fcz%2FDocuments%2FV%C3%BDuka%2FPS%2FDatab%C3%A1zov%C3%A9%20syst%C3%A9my%2FCvi%C4%8Den%C3%AD%2FC05%2Epdf&parent=%2Fpersonal%2Fpsilhavy%5Futb%5Fcz%2FDocuments%2FV%C3%BDuka%2FPS%2FDatab%C3%A1zov%C3%A9%20syst%C3%A9my%2FCvi%C4%8Den%C3%AD&originalPath=aHR0cHM6Ly91dGJjei1teS5zaGFyZXBvaW50LmNvbS86YjovZy9wZXJzb25hbC9wc2lsaGF2eV91dGJfY3ovRWNKWjdSNFpWWGxIaWJ0dUMtMHc0bXNCX21TYjJiai1yR0Nsb1FrdGY2Ny1NUT9ydGltZT1fRkRub1hwUTEwZw*/

