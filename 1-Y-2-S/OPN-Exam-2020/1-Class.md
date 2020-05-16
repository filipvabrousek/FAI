# Inheritenance
```cs
class Produkt
{
    public double Cena { get; set; }
    public int Hodnoceni { get; set; }

    public Produkt(double cena, int hodnoceni)
    {
        Cena = cena;
        Hodnoceni = hodnoceni;
    }
}

class Mys : Produkt
{
    public int Dpi { get; set; }

    public Mys(double cena, int hodnoceni, int dpi) : base(cena, hodnoceni)
    {
        Dpi = dpi;
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            double cena = 600;
            int hodnoceni = 8;
            int dpi = 2000;

            Mys mys = new Mys(cena, hodnoceni, dpi);

            Console.WriteLine($"Pocitacova mys cena: {mys.Cena} hodnoceni: {mys.Hodnoceni} dpi: {mys.Dpi}");
        }
    }
}
```
