```sql
UPDATE Clanky SET DatumVlozeni = GETDATE() WHERE AuthorID = 3

SELECT YEAR(datum) count(*) FROM Clanky GROUP BY YEAR(Datum) ORDER BY YEAR(desc)

SELECT * FROM Pujcka WHERE vraceni IS NULL
AND DATEDIFF(DAY, GETDATE(), vypujceni)>20
```
