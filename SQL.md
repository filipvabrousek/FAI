
´´´sql
--CREATE DATABASE FILIP
--GO 
--USE FILIP
--GO

--CREATE TABLE Ctenar (
--CtenarID int primary key,
--Jmeno varchar(50) not null
--)
--GO

--ALTER TABLE Ctenar
--ADD Prijimeni varchar(50),
--	RodneCislo varchar(11)

--GO
--ALTER TABLE Ctenar
--DROP COLUMN RodneCislo

--GO
--sp_RENAME "dbo.Ctenar.Jmeno", "Krestni", "column"

GO
CREATE TABLE Kniha (
IDKniha int primary key,
Nazev varchar(50) not null
)

GO

CREATE TABLE Autor (
IDAutor int primary key,
Jmeno varchar(50) not null,
Prijimeni varchar(50) not null
)

ALTER TABLE Ctenar 
ADD Ulice varchar(50),
 Mesto varchar (50),
 PSC varchar (10),
 RodnePrijimeni varchar (50)

ALTER TABLE Ctenar
DROP COLUMN RodnePrijimeni

--RENAME TABLE Ctenar TO Reader
	

´´´
