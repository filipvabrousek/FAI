## Upcasting


```cs
using System;

namespace Upcasting
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

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Oldřich", 1);
            Osoba osoba = student; // upcasting

            Console.WriteLine($"Jmeno studenta: {student.Jmeno}, rocnik: {student.Rocnik}");
            Console.WriteLine($"Jmeno osoby: {osoba.Jmeno}");
        }
    }
}
```
