## Final exam

## Theory
* ANSI = externí, koneptuální, interní a fyzická
* logická nezávislost dat = odolnost externích schémat při změnách konceptuálního schématu
* množinové operace = sjednocení, průnik, rozdíl, kartézský součin
* CASE Systémy =  nástroje pro podporu analýzy a visuálního navrhování databázových struktur.


### Integrita
* databáze NENÍ konzistentní když hodnoty uložené vícenásobně (na různých místech) jsou různé
* cizích klíčů může být více
* každá hodnota cizího klíče je buď plně zadaná / plně nezadaná
* do pole cizího klíče nejde dát hodnota, která není v primárním klíči
* **slabá entita** = pro její identifikaci musí být použit atribut jiné entity.
* přidat atribut = (přidat sloupec)
* referenční integrita = definuje se cizím klíčem nad dvojicí tabulek, nebo nad 1 tabulkou, která obsahuje závislá data
* INDEX není tabulka
* Logická nezávislost dat = Odolnost externích schémat při změnách konceptuálního schématu


### Kardinalita
* 1:1, 1:n, m:n

### SQL
* ``` RIGHT JOIN``` = každý záznam z druhé tabulky se musí spojit s některým záznamem první tabulky, jinak NULL
* ```LEFT JOIN``` = každý záznam z " tabulky, se musí spojit se záznamem z R, pokud nenajde z pravé, není match



## Queries


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



# Moodle
```sql
SELECT k.n, Avg(p.cena) FROM Kategorie AS k INNER JOIN Produkty AS p ON k.id = p.id GROUP BY k.nazev
SELECT * FROM Kat WHERE katID NOT IN (SELECT DISTINCT KatID FROM produkty)

```sql
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

```sql
0, 2, 4, 6, 8
SELECT p.x, p.n, p.c FROM Objednavky AS o INNER JOIN ……(MONTH, o.DatumVytvoreni = 11 ) ORDER BY p.Nazev
```

### Another

#### 9
```
SELECT Druh, Count(DruhProdejeID) Počet FROM Nemovitosti INNER JOIN DruhProdeje ON DruhProdejeID = Nemovitosti.DruhProdejeID GROUP BY Druh
```

```sql
NOT IN !!!
```
### Cast
```sql
SELECT CAST("2019-08-19" AS DATE);
```
