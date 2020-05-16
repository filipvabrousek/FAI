A2OPN Příprava k testu 6 - Rozhraní
---
Pro zvládnutí testu potřebujete vědět co je to rozhraní a jak se používá.

* Rozhraní je podobné jako abstraktní třída pouze s abstraktními metodami. Říkáme, že třída implementuje rozhraní. Každá třída může v jazyku c# dědit od jedné třídy ale může implementovat libovolný počet rozhraní. Rozhraní na rozdíl od abstraktních tříd neobsahují fieldy.
* Z hlediska použití popisuje abstraktní třída vztah **"is a"** tedy pejsek **je** zvířátko nebo monitor **je** produkt. Zatímco rozhraní popisuje spíše vztah **"can do"** nebo možná lépe **must do**, tedy například že třída faktura **umí** serializaci do textového souboru nebo třída soubor **umí** metodu Dispose, tedy uvolnit všechny své alokované zdroje a zavřít otevřený soubor. Většinou preferujeme více jednoduchých rozhraní s méně metodami, než jedno velké rozhraní s mnoha metodami.
* Rozhraní se používají ve frameworcích kde pomocí nich určujeme co daná třída umí, například pomocí implementace rozhraní `IComparable` můžeme třídu naučit aby fungovala v metodě `Sort`. Rozhraní se také často používají v technice Dependency Injection, kterou probereme příště, kdy místo třídy používáme rozhraní a vlastní implementaci pak můžeme dle potřeb měnit, například místo reálné implementace použijeme testovací implementaci.

* Nejprve si zopakujeme definici abstraktní třídy `Zviratko`:
```cs 
abstract class Zviratko
{
    public abstract string VratZvuk();
}

class Pejsek : Zviratko
{
    public override string VratZvuk()
    {
        return "haf haf";
    }
}
```
* Podobný příklad bychom potom mohli zapsat pomocí rozhraní, které zápis výrazně zjednodušuje:

```cs 
interface IZviratko
{
    string VratZvuk();
}

class Pejsek : IZviratko
{
    public string VratZvuk()
    {
        return "haf haf";
    }
}
```
* Vzhledem k tomu, že toto rozhraní by mohli implementovat i jiné třídy než zvířátka, tak bychom mohli toto rozhraní mohli také nazvat například `IZvuk` (anglicky `ISoundable`) a implementovat by ji mohla třeba i třída `Auto`:

```cs 
interface IZvuk
{
    string VratZvuk();
}

class Pejsek : IZvuk
{
    public string VratZvuk()
    {
        return "haf haf";
    }
}

class Auto : IZvuk
{
    public string VratZvuk()
    {
        return "brmmm brmmm";
    }
}
```

* Použitijí v kódu potom může být následující:

```cs 
static void VypisZvuk(IZvuk objektSeZvukem)
{
    Console.WriteLine(objektSeZvukem.VratZvuk());
}

static void Main(string[] args)
{
    Pejsek pejsek = new Pejsek();
    Auto auto = new Auto();

    VypisZvuk(pejsek);
    VypisZvuk(auto);
}
```

---
Následuje kompletní příklad.
