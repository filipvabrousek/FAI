using System;
namespace Test1SEMZAP
{
    class MainClass
    {

        public struct Rectangle
        {
            public int ax;
            public int bx;

            public Rectangle(int a, int b) {
                ax = a;
                bx = b;
            }

            public int Area() {
                return ax * bx;
            }
        }


        public class Student
        {
            public static int test1;
            public static int test2;
            public static int test3;
            public static string sname;

            public Student(string name, int t1, int t2, int t3)
            {
                sname = name;
                test1 = t1;
                test2 = t2;
                test3 = t3;
            }

            public string Above3()
            {
                if ((test1 + test2 > 25) || (test1 + test3) > 25 || (test2 + test3) > 25) {
                    return sname;
                }

                return "";
            }
        }

        public class Komplexni
        {
            public double a;
            public double b;

            public Komplexni() { }

            public Komplexni(double a1, double b2)
            {
                
                a = a1;
                b = b2;
               
            }
        }







        public static void Main(string[] args)
        {


            Komplexni c1 = new Komplexni(1.0, 2.0);
            Komplexni c2 = new Komplexni();

            c2.a = 2.0;
            c2.b = 3.0;

            var abs1 = Math.Sqrt(c1.a * c1.a + c1.b * c1.b);
            var abs2 = Math.Sqrt(c2.a * c2.a + c2.b * c2.b);


            if (abs1 > abs2)
            {
                Console.WriteLine("abs1 je větší");
            }
            else {
                Console.WriteLine("abs2 je větší");
            }


            Rectangle o = new Rectangle(2, 3);
            int s = o.Area();
            Console.WriteLine(s);


             Rectangle[] rects = { new Rectangle(2, 3), new Rectangle(3, 4) };


            int minIndex = 0;
            int min = 0;
            for (var i = 0; i < rects.Length; i++)
            {

                Console.WriteLine("Obvod " + (i + 1) + " " +" = " + 2 * (rects[i].ax + rects[i].bx));

                if (rects[i].ax + rects[i].bx < min) {
                    min = rects[i].ax + rects[i].bx;
                    minIndex = i;

                }

            }

            Console.WriteLine(rects[0].ax + "   " + rects[0].bx); // Nejmenší v poli

            // Hodnotové a referenční typy
            // Ref: Object, String, Class, Deleagte, Interface...
            // Hodn: Float Double Decimal, Int...


                /*
                 * 
                  isTriangle(2, 3, 8);
                  parity(2);
                  divisibleBy5or3();

                  int t1 = 5;
                  int t2 = 20;
                  int t3 = 15;

                  howMany(t1, t2, t3);

                 multiplesOf2();
                  */

                // Student [] students = new Student { Student("Filip", 2, 3)}

                Student[] students = { new Student("Filip", 12, 16, 12), new Student("Jana", 25, 25, 38) };

            /*  foreach (dynamic name in students) {

                  Console.WriteLine(name.test1);
              }*/

            // fix
            for (var i = 0; i < students.Length; i++) {
                var po = students[i];
                Console.WriteLine(po.Above3());
            }

            square(2, 3);


            int[] arr = new int[] { 1, 2, 9, 4, 8, 3 };

            // 1st number > 5

            firstBigger5(arr); // 9
            reverse(arr); // 3, 8, 9, 4, 2, 1
            lastOddNumber(arr);
        }


        static void lastOddNumber(int[] arr)
        {
            for (var i = arr.Length - 1; i > -1; i--)
            {
                if (i % 2 == 0) {
                    Console.WriteLine(arr[i]);
                }
               
            }
        }


        static void reverse(int[] arr)
        {
            for (var i = arr.Length - 1; i > -1; i--)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void firstBigger5(int[] arr)
        {

            for (var i = 0; i < arr.Length; i++)
            {

                if (arr[i] > 5)
                {
                    Console.WriteLine(arr[i]);
                    break;
                }
            }

        }


        static void sum(int[] arr) {
            int sum = 0;
            for (var i = 0; i < arr.Length; i++) {
                sum += arr[i];
            }

            Console.WriteLine("The sum is " + sum);
        }
        // GetBack !!!!!!!!

        static void square(int a, int power){
            int e = a;

            // 2
            for (var i = 1; i < power; i++){
                // e = 2 * 2
                // e = 4 * 4;
                e = e * i;
            }

            Console.WriteLine(a + "to the " + power + " power " + "is " + e);
        }


        static void multiplesOf2() {
            int i = 512;
            while (i >= 4) {
                i = i / 2;
                Console.WriteLine(i);
            }
        }


        static void divisibleBy5or3() {
            for (var i = 10; i <= 100; i++) {
                if ((i % 5 == 0) || (i % 3 == 0)) {
                    Console.WriteLine(i);
                }
            }
        }


       


        static void howMany(int t1, int t2, int t3) {
            int greater = 0;

            if (t1 >= 15) {
                greater += 1;
            }

            if (t2 >= 15){
                greater += 1;
            }

            if (t3 >= 15){
                greater += 1;
            }

            Console.WriteLine(greater + "Testů má hodnotu větší nebo rovno 15");
        }



        // Task 2
        static void isTriangle(int a, int b, int c) {
            if ((a + b > c) || (c + a > b) || (c + b > a)) {
                Console.WriteLine("Jedná se o trojúhelník");
            } else {
                Console.WriteLine("Nejedná se o trojúhelník");
            }
        }




        // Task 3
        static void parity(int a) {
            if ((a % 2) == 0) {
                Console.WriteLine("Číslo je sudé.");
            } else {
                Console.WriteLine("Číslo je liché.");
            }
        }

        // Task 4

    }
}
