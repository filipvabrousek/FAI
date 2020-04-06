using System;

namespace FinalTasks2020
{


    /*

    1) Co jsou to virutální metody a kdy se používají?

	2) Co jsou to abstraktní metody a třídy a kdy se používají?

	3) Co nemůžeme dělat s abstraktní třídou?

	4) Co je to rozhraní a jaký je rozdíl mezi rozhraním a abstraktní třídou?



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



   /* // DEPENDENCY INJECTION
    class Engine
    {
        public void start()
        {
            Console.WriteLine("Started");
        }
    }


    class Car
    {
        private Engine engine;

        public Car()
        {
            engine = new Engine();
        }

        public void go()
        {
            Console.WriteLine("Go");
            engine.start(); // Started
        }
    }

    // STATICKÉ PRVKY
    static class Counter
    {
        public static int count(int x, int y)
        {
            return x + y;
        }
    }


    // LOGGER
    class Singleton
    {
        private static Singleton s = null; //new Singleton();

        public static Singleton getInstance()
        {
            return s ?? (s = new Singleton());
        }

        private Singleton()
        {

        }

        public void log(string text)
        {
            Console.WriteLine($"{DateTime.Now}: ${text}");
        }
    }




    delegate void D(int x);
    */


    class MainClass
    {



        static void WriteA(int x)
        {
            Console.WriteLine($"A {x}");
        }

        static void WriteB(int x)
        {
            Console.WriteLine($"B {x}");
        }



        static void checkDowncasting(Student someone)
        {
            if (someone is Person person)

            {
                print($"Student: ${someone.name}");
            }
            else
            {
                print("Someone else. Downcasting has failed.");
            }
        }


        public static void Main(string[] args)
        {
            // UPCASTING
            Student st = new Student("Filip", 20);
            Person p = st;


            // 1 - Co jsou to virutální metody a kdy se používají?
            print(p.getType());
            // "Person" (rozhoduje type REFERENCE (TYP) proměnné)
            // po použití (odkomentování) VIRTUAL nahoře, se vypíše "Student" (nezáleží na typu reference)
            // používají se pro možnost "přepisu" pomocí override v odvozené třídě.


            // 2 - Co jsou to abstraktní metody a třídy a kdy se používají?
            Cat c = new Cat();
            print(c.Roar()); // "Mňau!"
            // Abstraktní metody = Metody bez těla (používají se v abstraktní třídě (Animal))
            // Odvozené třída "Cat" musí metodu obsahovat a použít slovo override aby metodu mohla použít.



            // 3 - Co nemůžeme dělat s abstraktní třídou?
            // Nemůžeme vytvořit její instanci 
            // Animal d = new Animal(); -> ERROR 



            // Co je to rozhraní a jaký je rozdíl mezi rozhraním a abstraktní třídou?
            // class can implement more than one interface but can only inherit from one abstract class
            // 4 - 





            /* // DOWNCASTING
             Person m = new Person("Petr");
             Student o = m as Student; // as vrátí NULL, pokud se downcasting nepovede
             checkDowncasting(o);
             */





         /*   // DEPENDENCY INJECTION
            Car car = new Car();
            car.go();
            // "Go"
            // "Started"


            // STATICKÉ PRVKY
            int sum = Counter.count(6, 3); // bez nutnosti vytváření instance
            print(sum + "");


            Singleton sin1 = Singleton.getInstance();
            sin1.log("Program has started.");

            Singleton sin2 = Singleton.getInstance();
            sin2.log("Program continues...");





            // DELEGÁT
            D d = null;

            d += WriteA;
            d += WriteB;

            d?.Invoke(3); // zavolá pouze pokud nemá null

            // A: 3, B: 3 -= odstraní*/
        }


        static void print(String t)
        {
            Console.WriteLine(t);
        }
    }
}
