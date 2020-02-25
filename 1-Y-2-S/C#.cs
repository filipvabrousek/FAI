using System;

namespace CS1Y2S
{


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




    // ABSTRAKTNÍ TŘÍDY
    abstract class Animal {
        public abstract string Roar();
    }

    class Cat : Animal {
        public override string Roar() {
            return "Mňau!!!";
        }
    }



    // DEPENDENCY INJECTION
    class Engine {
        public void start() {
            Console.WriteLine("Started");
        }
    }


    class Car {
        private Engine engine;

        public Car() {
            engine = new Engine();
        }

        public void go() {
            Console.WriteLine("Go");
            engine.start(); // Started
        }
    }

    // STATICKÉ PRVKY
    static class Counter {
        public static int count(int x, int y) {
            return x + y;
        }
    }


    // LOGGER
    class Singleton
    {
        private static Singleton s = null; //new Singleton();

        public static Singleton getInstance() {
            return s ?? (s = new Singleton());
        }

        private Singleton(){
         
        }

        public void log(string text) {
            Console.WriteLine($"{DateTime.Now}: ${text}");
        }
    }




    delegate void D(int x);



    class MainClass
    {

       

        static void WriteA(int x) {
            Console.WriteLine($"A {x}");
        }

        static void WriteB(int x)
        {
            Console.WriteLine($"B {x}");
        }



        static void checkDowncasting(Student someone) {
            if (someone is Person person)
                
            {
                print($"Student: ${someone.name}");
            } else {
                print("Someone else. Downcasting has failed.");
            }
        }


        public static void Main(string[] args)
        {
            // UPCASTING
            Student st = new Student("Filip", 20);
            Person p = st;



            print(p.getType()); // "Person" (rozhoduje type REFERENCE (TYP) proměnné)
            // po odkomentování nahoře -> "Student" nezáleží na typu reference


            // DOWNCASTING
            Person m = new Person("Petr");
            Student o = m as Student; // as vrátí NULL, pokud se downcasting nepovedl
  
            checkDowncasting(o);

           

            // ABSTRAKTNÍ TŘÍDY
            Cat c = new Cat();
            print(c.Roar()); // "Mňau!"


            // DEPENDENCY INJECTION
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

            // A: 3, B: 3 -= odstraní
        }


        static void print(String t) {
            Console.WriteLine(t);
        }
    }
}
