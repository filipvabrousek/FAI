## Final exam

## Theory
* externí, koneptuální, fyzická a logická úroveň
* Schémata: externí, logická, interní

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


### Other SQL
```sql
GETDATE() - aktuální datum a čas ze serveru
CURRENT_TIMESTAMP

DATEPART(interval, datum)
DATEADD(interval, datum)
DATEDIFF(interval, datum1? datum2)

FORMAT(datum, maska, [jazyk])
ROUND - zaokrouhlí, stejný počet míst (3.14000000000)
CEILING
FLOOR

CONCAT (totéž co v JS :D)
REPLACE(1, 2, 3) - vyhledá ř. 1 v řeť 2 anhr řeť 3
REVERSE(str)
REPLICATE(str, n)
CHAR(n) číslo na řetezec
STR(n) reálné číslo na celočíselný řetězec
CHARINDEX(term1, term2) - vypíše poč. pozici výrazu 1 a 2
```
