## Basics

Interpetované jazayky
nelinkují ani nekompilují zdrojový kód aplikace -> funkce nezávislá na hw ani sw prostředí.

RunTime knihovny interpretru 
analyzují zdrojový kód programu přímo za běhu


Intepreter napsána zvlášť pro každou platformu
Společné API provádí překlad za běhu programi
stojí procesorový čas a operační paměť



APP code
Lib for Windows (optimalizované prostředky)
OS Linux


APP code (same)
Lib for Mac
OS Linux


vezmeme kód + knihovny Qt pro linux + build = App


Nevýhoda: složitější distribuce na ostatní platformy



Qt překládané
Intepetované - Společné API provádí překlad za běhu programi
Překládaný - rychlejší (překládaný za běhu)



Kompilace
Preprocesor (pozmění zdroják) .c => .txt
Kompilátor => stream kódu pro 1 konkrétní procesor (tolik překladačů) kolik architektur)
Linker
Executable


Výběr vhodného jazyka 
Využití pouze standardizovaných verzí (ANSI C...)
Je vhodné použít 1 typ překladače pro všechny platf.


Využívejte pouze knihovní soubory
Využívejte pouze standardní datové typy

základní adresovatelné jednotka většinu byte (8 bitů) - 0-255 -> 256 komb.
257 musím mít 2 byte


255 (000111) v jednom + 3 (0000111) ve druhém bytu
16-bit

nebezpečné vyměňovat data mezi platformy v binární reprezentaci
1 byte (8 bitový)
1 bite (16 bitový) jiná výměna dat

Využívejte přenositelné stránky
Znak => číslo
Někdy je potřeba pro znak více bajtů 
Využívat UTF-8 pro ukládání souborů
některé knihovny pomocí maker XText("SomeText")


Pomocí CMAKE překlad
cmakelist.txt přeložíme ho






Podmínky v kódu + překlad


Only final test 50b
Final task 50b


132457 begin
