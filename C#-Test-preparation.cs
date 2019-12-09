using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1111ZAP
{
	class Program
	{


        class S {
            public string name;
            public int points;
            public int hours;

            public S(string name, int points, int hours) {
                this.name = name;
                this.points = points;
                this.hours = hours;
            }

            public bool gotIt() {
                bool done = hours > 20 && points > 30;
                return done;
            }
        }


        struct N
        {
            public string name;

            public N(string name)
            {
                this.name = name;
            }
        }

        class T
        {
            public string name;

            public T(string name)
            {
                this.name = name;
            }
        }

        /* REF: String, Object, Class, Array
        HODN: Long, Bite, Float, Double, Decimal */

        static void typea() {

            /*-----------STRUCT--------------*/
            N p = new N("Filip");
            N e = p;
            e.name = "Jana";

            var f = e;
            f.name = "J";

            Console.WriteLine("ENAME " + e.name); // Jana
            Console.WriteLine("FNAME " + f.name); // J


            /*------------CLASS-------------*/
            T tname = new T("Filip");
            var et = tname;
            et.name = "Jana";

            var ft = et;
            ft.name = "J";

            Console.WriteLine("ENAME " + et.name); // J !!!!! (reference to class itself !!!)
            Console.WriteLine("FNAME " + ft.name); // J
        }

        // CLASS Can be nulled, T cannot
        static void makeNull(T value) {
            value = null;
        }

		
		static void Main(string[] args)
		{
            S[] students = {
                new S("Filip", 90, 31),
                new S("Jana", 100, 2)
            };


            // name of the student with the highest points in array
            int max = 0;
            string name = "";

            for (int i = 0; i < students.Length; i++) {
                S student = students[i];

                if (student.points > max) {
                    max = student.points;
                    name = student.name;
                } 


               /* if (student.gotIt()) {
                    Console.WriteLine(student.name);
                }*/
            }


            typea();

            Console.WriteLine("Nejvíce bodů získal student: " + name + " (" + max + ")");
            // Nejvíce bodů získal student: Jana (100)

        }


     

       



    }
}


// data types



/*class Student
      {
          public string jmeno;
          public int rocnik;
          public double body;
          public int pocetSplnenychPrubeznych;
          public double dochazka;


          public Student(string jmeno, int rocnik, double body, int pocetSplnenychPrubeznych, double dochazka)
          {
              this.jmeno = jmeno;
              this.rocnik = rocnik;
              this.body = body;
              this.pocetSplnenychPrubeznych = pocetSplnenychPrubeznych;
              this.dochazka = dochazka;
          }

          public bool Zapocet()
          {
              bool splnil = (body >= 45 && dochazka >= 80 && pocetSplnenychPrubeznych >= 8);
              return splnil;

          }
      }*/




/*string jmeno = "Martin";
int rocnik = 1;
double body = 100;
int pocetSplnenychPrubeznych = 8;
double dochazka = 80;

Student s1 = new Student(jmeno, rocnik, body, pocetSplnenychPrubeznych, dochazka);
// int[] pole = new int[] { 1, 2, 3, 4 };
Student[] studenti = new Student[] {
    s1,
    new Student("Maros", 1, 60,7,100),
    new Student("Alois", 3, 15,6,70),
    new Student("Alex", 1, 100,10,100)
};

for (int i = 0; i < studenti.Length; i++)
{
    Student student = studenti[i];
    if (student.Zapocet())
    {
        Console.WriteLine("Presiel: " + student.jmeno);
    }
}

// jmeno studenta s naj poctom bodov v poli
Student topka = studenti[0];
for (int x = 1; x < studenti.Length; x++)
{
    Student anotherone = studenti[x];
    if (anotherone.body > topka.body)
    {
        topka = anotherone;
    }
    //porovnat ci je lepsi ako zatial naj student
}
Console.WriteLine(topka.jmeno + " " + topka.body);
*/
