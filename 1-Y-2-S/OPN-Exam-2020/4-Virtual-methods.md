## Virtual methods

```cs
using System;

namespace Test
{
    class Produkt
    {
        public string Nazev { get; set; }

        public Produkt(string nazev)
        {
            Nazev = nazev;
        }

        virtual public string VratTyp()
        {
            return "Produkt";
        }
    }

    class Monitor : Produkt
    {
        public int Rozliseni { get; set; }

        public Monitor(string nazev, int rozliseni) : base(nazev)
        {
            Rozliseni = rozliseni;
        }

        override public string VratTyp()
        {
            return "Monitor";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Produkt p1 = new Monitor("Lg 55", 1080);
            Console.WriteLine(p1.VratTyp()); // vypise "Monitor"
        }
    }
}
```
