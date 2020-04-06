using System;

namespace FinalTasks2020
{


    /*

    1) Co jsou to virutální metody a kdy se používají?

	2) Co jsou to abstraktní metody a třídy a kdy se používají?

	3) Co nemůžeme dělat s abstraktní třídou?

	4) Co je to rozhraní a jaký je rozdíl mezi rozhraním a abstraktní třídou?

    OTÁZKY JSOU VYSVĚTLENY V MAINU.
	 */


    // 1 - VIRTUÁLNÍ METODY  (VYSVĚTLENO V MAIN)
    class Person
    {
        public String name
        {
            get; set;
        }

        public Person(String name)
        {
            this.name = name;
        }

        // odkomentovat aby nezáleželo na typu refrence
        public /*virtual*/ string getType()
        {
            return "Person";
        }
    }

    class Student : Person
    {
        public int age { get; set; }

        public Student(string name, int age) : base(name)
        {
            this.age = age;
        }

        // odkomentovat aby nezáleželo na typu refrence
        public /*overide*/ string getType()
        {
            return "Student";
        }
    }


    // ABSTRAKTNÍ TŘÍDY
    abstract class Animal
    {
        public abstract string Roar();
    }

    class Cat : Animal
    {
        public override string Roar()
        {
            return "Mňau!!!";
        }
    }



    // INTERFACE vs ABSTRACT CLASSS
    abstract class JustFirst {
        public abstract string m1();
    }


    interface First {
         string m1();
    }

    interface Second
    {
         string m2();
    }

    class OnlyOneAbstract : JustFirst /*, Second už zde být nemůže */ {
        public override string m1()
        {
            return "Třída může mít jen jednu abstraktní třídu";
        }
    }



    class MultipleInterfaces : First, Second /* interfaces může být více */
    {
        public string m1()
        {
            return "Třída může mít více interfaces";
        }

        public string m2()
        {
            return "Třída může mít více interfaces";
        }

    }


    class MainClass
    {


        public static void Main(string[] args)
        {
            // UPCASTING
            Student st = new Student("Filip", 20);
            Person p = st;


            // 1 - Co jsou to virutální metody a kdy se používají?
            print(p.getType());
            // "Person" (rozhoduje type REFERENCE (TYP) proměnné)
            // po použití (odkomentování) VIRTUAL a OVERRIDE nahoře, se vypíše "Student" (nezáleží na typu reference)
            // používají se pro možnost "přepisu" pomocí override v odvozené třídě.


            // 2 - Co jsou to abstraktní metody a třídy a kdy se používají?
            Cat c = new Cat();
            print(c.Roar()); // "Mňau!"
            // Abstraktní třída slouží jen jako předpis (základ) pro podtřídy (nelze vytvořit její instanci)
            // Abstraktní metody = Metody bez těla (používají se v abstraktní třídě (Animal))
            // Odvozené třída "Cat" musí metodu obsahovat a použít slovo override aby metodu mohla použít.


            // 3 - Co nemůžeme dělat s abstraktní třídou?
            // Nemůžeme vytvořit její instanci 
            // Animal d = new Animal(); -> ERROR 


            // 4 - Co je to rozhraní a jaký je rozdíl mezi rozhraním a abstraktní třídou?
              // Interface (rozhraní) není třída (obsahuje jen definici metody)
            // Třída může mít více rozhraní, ale jen jednu abstraktní třídu
          

            OnlyOneAbstract only = new OnlyOneAbstract();
            print(only.m1()); // "Třída může mít jen jednu abstraktní třídu";

            MultipleInterfaces multi = new MultipleInterfaces();
            print(multi.m1()); // "Třída může mít více interfaces";
            print(multi.m2()); // "Třída může mít více interfaces";

       
        }


        static void print(String t)
        {
            Console.WriteLine(t);
        }
    }
}
