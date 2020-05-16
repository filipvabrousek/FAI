## Downcasting

```cs
using System;

namespace Downcasting
{
    class Osoba
    {
        public string Jmeno { get; set; }

        public Osoba(string jmeno)
        {
            Jmeno = jmeno;
        }
    }

    class Student : Osoba
    {
        public int Rocnik { get; set; }

        public Student(string jmeno, int rocnik) : base(jmeno)
        {
            Rocnik = rocnik;
        }
    }

    class Zamestnanec : Osoba
    {
        public string Kancelar { get; set; }

        public Zamestnanec(string jmeno, string kancelar) : base(jmeno)
        {
            Kancelar = kancelar;
        }
    }

    class Program
    {
        static void Vypis(Osoba osoba)
        {
            Console.WriteLine($"Jmeno osoby: {osoba.Jmeno}");

            if (osoba is Student student)
            {
                Console.WriteLine($"Rocnik studenta: {student.Rocnik}");
            }

            if (osoba is Zamestnanec zamestnanec)
            {
                Console.WriteLine($"Kancelar zamestnance: {zamestnanec.Kancelar}");
            }
        }

        static void Main(string[] args)
        {
            Zamestnanec z1 = new Zamestnanec("Tomas", "805");
            Osoba o1 = new Student("Kamil", 1);

            Vypis(z1);
            Vypis(o1);
        }
    }
}

//List<Osoba> osoby = new List<Osoba>()
//        {
//            new Zamestnanec("Kral", "822"),
//            new Student("Kamil", 1),
//            new Zamestnanec("Vogeltanz", "805")
//        };
```
