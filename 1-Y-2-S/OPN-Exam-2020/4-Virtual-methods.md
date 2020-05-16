## Virtual methods



### Mine


```cs

// DEDIČNOST, UPCASTING, DOWNCASTING
  class Person {
        public String name {
            get; set;
        }

        public Person(String name) {
            this.name = name;
        }

        // odkomentovat aby nezáleželo na typu refrence
         public /*virtual*/ string getType() {
            return "Person";
        }
    }

    class Student : Person {
        public int age { get; set; }

        public Student(string name, int age) : base(name) {
            this.age = age;
        }

        // odkomentovat aby nezáleželo na typu refrence
        public /*overide*/ string getType() {
            return "Student";
        }
    }

// UPCASTING
            Student st = new Student("Filip", 20);
            Person p = st;
            print(p.getType()); // "Person" (rozhoduje type REFERENCE (TYP) proměnné)
            // po odkomentování nahoře -> "Student" nezáleží na typu reference

    // DOWNCASTING
            Person m = new Person("Petr");
            Student o = m as Student; // as vrátí NULL, pokud se downcasting nepovedl
  
            checkDowncasting(o);
            
            static void checkDowncasting(Student someone) {
            if (someone is Person person)
                
            {
                print($"Student: ${someone.name}");
            } else {
                print("Someone else. Downcasting has failed.");
            }
        }

```

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
