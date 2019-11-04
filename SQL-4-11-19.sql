SELECT Rocnik, AVG(Vek) FROM Student
GROUP BY Rocnik;

--- 2
SELECT Rocnik, AVG(Vek) FROM Student
WHERE Rocnik = 1;

--- 3
SELECT Nazev, AVG(Vek) FROM Obor
LEFT JOIN Student;

--- 4
SELECT Prijmeni FROM Student LEFT JOIN Zapis ON Student.StudentID = Zapis.StudentID
GROUP BY Prijmeni HAVING COUNT(Zapis.StudentID) <= 2;

--- 5
ALTER TABLE "Student" CHANGE "Vek" TO "RodneCislo";

--- 6
ALTER TABLE "Student" 
ADD DatumNastupu;



SELECT Ucitel, Prijimeni FROM Ucitel
LEFT JOIN Predmet ON Ucitel.UcitelID
WHERE titul IS NOT NULL
GROUP BY Ucitel.Prijimeni, Ucitel.Jmeno
HAVING Count.Predmet, predmetID

SELECT Year(GETDATE());


SELECT * FROM Student
WHERE Year(DatumNastupu) = Year(GETDATE());


SELECT DATEPART(DAYOFYEAR)


SELECT SUBSTRING(Prijimeni,1,1) FROM Student;


----- Task
SELECT Rocnik, AVG(Vek) FROM Student;
% SELECT AVG(DATEDIFF("yyyy", Rocnik, getDate())) FROM Student;





-----SELECT Ucitel, Prijimeni FROM Ucitel
-----LEFT JOIN Predmet ON Ucitel.UcitelID
-----WHERE titul IS NOT NULL
--GROUP BY Ucitel.Prijimeni, Ucitel.Jmeno
--HAVING Count.Predmet, predmetID

--SELECT Year(GETDATE());


--SELECT * FROM Student
--WHERE Year(DatumNastupu) = Year(GETDATE());


--SELECT DATEPART(DAYOFYEAR)


--SELECT SUBSTRING(Prijimeni,1,1) FROM Student;



----- Task
--- 1
SELECT Rocnik, AVG(Vek) FROM Student
GROUP BY Rocnik;

--- 2
SELECT Rocnik, AVG(Vek) FROM Student
WHERE Rocnik = 1;

--- 3
SELECT Nazev, AVG(Vek) FROM Obor
LEFT JOIN Student;

--- 4
SELECT Prijmeni FROM Student LEFT JOIN Zapis ON Student.StudentID = Zapis.StudentID
GROUP BY Prijmeni HAVING COUNT(Zapis.StudentID) <= 2;

--- 5
SELECT 
          
---- SELECT AVG(DATEDIFF("yyyy", Rocnik, getDate())) FROM Student;
