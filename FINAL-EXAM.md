## Final exam

## Theory
* ANSI = externí, koneptuální, interní a fyzická
* logická nezávislost dat = odolnost externích schémat při změnách konceptuálního schématu
* množinové operace = sjednocení, průnik, rozdíl, kartézský součin
* CASE Systémy =  nástroje pro podporu analýzy a visuálního navrhování databázových struktur

### Integrita
* databáze NENÍ konzistentní když hodnoty uložené vícenásobně (na různých místech) jsou různé
* cizích klíčů může být více
* každá hodnota cizího klíče je buď plně zadaná / plně nezadaná
* do pole cizího klíče nejde dát hodnota, která není v primárním klíči
* **slabá entita** = pro její identifikaci musí být použit atribut jiné entity.
* přidat atribut = (přidat sloupec)
* INDEX není tabulka
* referenční integrita = definuje se cizím klíčem nad dvojicí tabulek, nebo nad 1 tabulkou, která obsahuje závislá data
* konceptuální úroveň = se popisuje logická struktura dat a vztahy mezi nimi

* **RIGHT** = každý záznam z druhé tabulky se musí spojit s některým záznamem první tabulky, jinak NULL
* **LEFT** = každý záznam z 1. tabulky, se musí spojit se záznamem z 2., pokud null z pravé, není match

```sql
INSERT INTO Data SELECT * FROM Book
```

```sql
DELETE FROM P WHERE dID IN (SELECT dID FROM D WHERE WHERE Nazev = D)
DELETE FROM D WHERE Nazev = "D"
SELECT * FROM Objednavky WHERE Cena > Avg(Cena)
```

```sql
SELECT * FROM N WHERE NId IN (SELECT NId FROM nemovitostiTyp
WHERE parentID=1)
```

```sql
SELECT DATEADD(hour, 12, getDate())
SELECT LEFT("Karel Jaromír Erben", 5)
```

```sql
SELECT k.n, Avg(p.cena) FROM Kategorie AS k 
INNER JOIN Produkty AS p ON k.id = p.id GROUP BY k.nazev
SELECT * FROM Kat WHERE katID NOT IN (SELECT DISTINCT KatID FROM produkty)
```

```sql
SELECT * FROM Kniha WHERE Cena > 100
```

```sql
CREATE VIEW p AS SELECT x, y, z FROM Student s JOIN Zapis z ON s.id = z.id
JOIN Pr p ON s.id = p.id
```

```sql
SELECT COUNT (*) Počet FROM N 
JOIN Stat ON N.StatID = Stat.StatID WHERE (Stat.Nazev = CZ)
```

```sql
CROSS JOIN
UPDATE TRIGGER
ALTER TABLE Kniha ADD PRIMARY KEY (IDKnihy)
```

```sql
SELECT * FROM Uzivatel WHERE Projmeni LIKE "A%"
```
```sql
GETDATE()
SELECT CURRENT_TIMESTAMP
DATEPART(month, '2017/08/25')
DATEDIFF(year, '2017/08/25', '2011/08/25')
```
```sql
DECLARE @d DATETIME = '01/12/2019';
SELECT FORMAT (@d, 'd', 'en-US') AS 'res'
```

```sql
SELECT ROUND(9.7) AS x
SELECT CEILING(9.7) AS x --FLOOR
```

```sql
SELECT CONCAT('W3Schools', '.com')
SELECT REVERSE("Tutorial")
SELECT REPLICATE('Another', 3)
SELECT CHAR(65)
SELECT CHARINDEX("t", "Customer") AS p
SELECT REPLACE("Milip", "M", "F")
SELECT STR(180) 
```

```sql
SELECT datediff(day,getdate(),replace(´rok-12-24´,´rok´year(getdate()))
```

```sql
0, 2, 4, 6, 8
SELECT p.x, p.n, p.c FROM Objednavky AS o
INNER JOIN ……(MONTH, o.DatumVytvoreni = 11 ) ORDER BY p.Nazev
```

```sql
SELECT Druh, Count(DruhProdejeID) Počet FROM Nemovitosti 
INNER JOIN DruhProdeje ON DruhProdejeID = Nemovitosti.DruProID GROUP BY Druh
SELECT CAST("2019-08-19" AS DATE);
NOT IN !!!

SELECT Ucitel, Prijimeni FROM Ucitel
LEFT JOIN Predmet ON Ucitel.UcitelID
WHERE titul IS NOT NULL
GROUP BY Ucitel.Prijimeni, Ucitel.Jmeno
HAVING Count.Predmet, predmetID
```

```sql
SELECT * FROM Pujcka WHERE vraceni IS NULL
AND DATEDIFF(DAY, GETDATE(), vypujceni)>20
```

