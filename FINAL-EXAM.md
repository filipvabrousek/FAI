## Final exam

## Theory
* vztah = vazba mezi entitami
* externí, koneptuální, fyzická a logická úroveň

### Integrita
* databáze konzistentní když hodnoty uložené vícenásobně (na různých místech) jsou různé
* cizích klíčů může být více
* stejná data uložená vícenásobně




## Queries
```sql
-- 1d ??

-- 2b
datetime

-- 3a
DELETE FROM P WHERE dID IN (SELECT dID FROM D WHERE WHERE Nazev = D)
DELETE FROM D WHERE Nazev = "D"

-- 4 není

-- 5
SELECT * FROM Objednavky WHERE Cena > Avg(Cena)
```

### 6
* množ operace = sjednocení, průnik, rozdíl, kartézský součin

```sql
-- 8, 9, 10, 11 Není




// 14
SELECT DATEADD(hour, 12, getDate())

// 15 není

// 16
SELECT LEFT("Karel Jaromír Erben", 5)

// 17

// 18 není

// 19b nothing correct

// 20d
```

# Moodle
```sql
// 1d
SELECT k.n, Avg(p.cena) FROM Kategorie AS k INNER JOIN Produkty AS p ON k.id = p.id GROUP BY k.nazev

// 2 ???

// 3 b simple

// 4 c
SELECT * FROM Kat WHERE katID NOT IN (SELECT DISTINCT KatID FROM produkty)

// 5
SELECT LEFT("Karel Jaromír Erben", 5)

// 6
SELECT * FROM Kniha WHERE Cena > 100

// Other
SELECT Rocnik, avg(

// 11c

// 12
CREATE VIEW p AS SELECT x, y, z FROM Student s JOIN Zapis z ON s.id = z.id
JOIN Pr p ON s.id = p.id

// 13 
CROSS JOIN

// 14
ALTER TABLE Kniha ADD PRIMARY KEY (IDKnihy)

```

