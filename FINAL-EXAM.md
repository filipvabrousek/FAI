## Final exam

## Theory
* ANSI = externí, koneptuální, fyzická a logická úroveň
* Schémata: externí, logická, interní
* logická nezávislost dat = odolnost externích schémat při změnách konceptuálního schématu

### Integrita
* databáze konzistentní když hodnoty uložené vícenásobně (na různých místech) jsou různé
* cizích klíčů může být více
* každá hodnota cizího klíče je buď plně zadaná / plně nezadaná
* do pole cizího klíče nejde dát hodnota, která není v primárním klíči


### Kardinalita
* 1:1, 1:n, m:n

### SQL
* ``` RIGHT JOIN``` = každý záznam z 1. tabulky, se musí spojit se záznamem z 2., pokud nenejde, spojí se s null
* ```LEFT JOIN``` = každý záznam z 1. tabulky, se musí spojit se záznamem z 2., pokud nenajde z pravé, není match



## Queries
```sql
DELETE FROM P WHERE dID IN (SELECT dID FROM D WHERE WHERE Nazev = D)
DELETE FROM D WHERE Nazev = "D"
SELECT * FROM Objednavky WHERE Cena > Avg(Cena)
```

```sql
SELECT * FROM N WHERE NId IN (SELECT NId FROM nemovitostiTyp
WHERE nemovitostiTypParentID=1)
```

```sql
SELECT DATEADD(hour, 12, getDate())
SELECT LEFT("Karel Jaromír Erben", 5)
```



# Moodle
```sql
SELECT k.n, Avg(p.cena) FROM Kategorie AS k INNER JOIN Produkty AS p ON k.id = p.id GROUP BY k.nazev
SELECT * FROM Kat WHERE katID NOT IN (SELECT DISTINCT KatID FROM produkty)
SELECT LEFT("Karel Jaromír Erben", 5)
SELECT * FROM Kniha WHERE Cena > 100
```

```sql
CREATE VIEW p AS SELECT x, y, z FROM Student s JOIN Zapis z ON s.id = z.id
JOIN Pr p ON s.id = p.id
```

```sql
CROSS JOIN
```

```sql
SELECT * FROM Uzivatel WHERE Projmeni LIKE "A%"
```

```sql
UPDATE TRIGGER
```

```sql
ALTER TABLE Kniha ADD PRIMARY KEY (IDKnihy)
```

### Lecture
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


## Math
* stejný počet míst (3.14000000000)
```sql
SELECT ROUND(9.7) AS x
SELECT CEILING(9.7) AS x --FLOOR
```

## String
```sql
SELECT CONCAT('W3Schools', '.com')
SELECT REVERSE("Tutorial")
SELECT REPLICATE('Another', 3)
SELECT CHAR(65)
SELECT CHARINDEX("t", "Customer") AS p
SELECT REPLACE("Milip", "M", "F")
SELECT STR(180) 
```


### Vánoce
```sql
SELECT datediff(day,getdate(),replace(´rok-12-24´,´rok´year(getdate()))
```
### Cast
```sql
SELECT CAST("2019-08-19" AS DATE);
```
