using System;
using System.Collections.Generic;
using System.Linq;




namespace DragonCopy
{

    /*----------------------------------------------------------------------------------------------- RANDOM -----------------------------------------------------------------------------------------------*/

   public static class Randomizer {

        private static Random random = new Random();
        private static object _lock = new object();


    public static int Next() {
        lock (_lock) {
                return random.Next();
            }
         }
            

     public static int Next(int min, int max) {
            lock (_lock) {
                    return random.Next(min, max);
                }
        }

        public static double NextDouble() {
            lock (_lock) {
                return random.NextDouble();
            }
        }
}


    // 16:24 begin
    /*----------------------------------------------------------------------------------------------- DEFENSE -----------------------------------------------------------------------------------------------*/

    class DefenseBase {
        public String name;

        public DefenseBase(String name) {
            this.name = name;
        }
    }


    class Sword : DefenseBase {
         double damage;
         double weight;

        public Sword(String name, double damage): base(name) {
            this.damage = damage;
        }

        public double getDamage() {
            return damage;
        }

        public void setDamage(double value) {
            damage += value;
        }
    }


    class Shield : DefenseBase
    {
        double damage;
        int weight;

        public Shield(String name, int damage) : base(name){
            this.damage = damage;
        }

       public double getDamage(){
            return damage;
        }

        public void setDamage(double value){
            damage += value;
        }
    }

    /*----------------------------------------------------------------------------------------------- CHARACTERS -----------------------------------------------------------------------------------------------*/
    abstract class Base
    {

   
        public double health;
        public double maxDamage;
        public double maxDefense;
        public String characterType;

        public Base(double health, double maxDamage, double maxDefense, String characterType){
            this.health = health;
            this.maxDamage = maxDamage;
            this.maxDefense = maxDefense;
        }

        public abstract double randAttack();
        public abstract void hitBy(double damage);
    }

    class Hero : Base {
        String name;
        Sword sword;
        Shield shield;
        String type;

        public Hero(Sword sword, Shield shield, String name, double health, double maxDamage, double maxDefense): base(health, maxDamage, maxDefense, "Hero") {
            this.sword = sword;
            this.shield = shield;
            this.name = name;
        }

        public override double randAttack() {
            int attackValue = Randomizer.Next(1, 5); // 1 to maxDamage
            return attackValue;
        }

        public override void hitBy(double damage){
           // int randDamage = Randomizer.Next(0, maxDamage);
            shield.setDamage(damage);
            health -= damage;
        }

        public double getHealth(){
            return health;
        }

        public bool isDead(){
            return health <= 0;
        }
    }


    class Dragon : Base {
        String name;
     
        public Dragon(String name, double health, double maxDamage, double maxDefense) : base(health, maxDamage, maxDefense, "Dragon")
        {
            this.name = name;
        }

        public override double randAttack(){
            int attackValue = Randomizer.Next(1, 5);
            return attackValue;
              // health -= randDamage;
        }

        public override void hitBy(double damage){
           //  int randDamage = Randomizer.Next(0, maxDamage);
            health -= damage;
        }

        public double getHealth() {
            return health;
        }

        public bool isDead() {
            return health <= 0;
        }
    }






    class Audit {




        /*static Base[] sorted(Base[] b) {
           return b.OrderBy(x => x.)
        }*/



        public double averagePower(List<Base> b) {
            double avg = b.Average(a => a.maxDefense);
            return avg;
        }



    }


    class MainClass
    {
        public static void Main(string[] args)
        {
            int round = 0;
            Audit ad = new Audit();

            Sword sword = new Sword("NiceSword", 130);
            Shield shield = new Shield("NiceShield", 130);

            List<Base> characters = new List<Base>(){
            new Hero(sword, shield, "Filip", 100, 100, 100),
            new Hero(sword, shield, "Jana", 100, 100, 100),
            new Hero(sword, shield, "Jana", 100, 100, 100),
            new Dragon("Max", 100, 100, 100)
            };

           double avg = ad.averagePower(characters);
           Console.WriteLine("Average power of characters is " + avg);


            var count = 0;





            // someAlive(count)
            while (RealSomeAlive(characters)) {
                count += 1;



                for (var i = 0; i < characters.Count - 1; i++) {
                    object first = convert(characters[i]);
                    object second = convert(characters[i + 1]);
                    double firstAttackValue = 0;

                    round += 1;
                    Console.WriteLine($"=============================ROUND {round} ===========================");

                    if (first is Hero)
                    {
                        firstAttackValue = ((Hero)first).randAttack();
                        Console.WriteLine($"Hero attacked Dragon with {firstAttackValue}");
                    }

                    if (second is Dragon){
                      //  Console.WriteLine($"Dragon {second.GetType()}");
                        Dragon dra = ((Dragon)second);
                        dra.hitBy(firstAttackValue);
                        Console.WriteLine($"Dragon lost {firstAttackValue} health and has {dra.getHealth()} lives");
                      


                        //2nd character strikes back
                        double attack = dra.randAttack();

                        if (first is Hero)
                        {
                            Hero hra = ((Hero)first);
                            hra.hitBy(attack);
                            Console.WriteLine($"Dragin strikes back by {attack} and hero has  {hra.getHealth()} ");
                        }
                    }
                }
            }
        }

        static Base convert(Base character) {
            if (character is Dragon) {
                return (Dragon)(character);
            }

            if (character is Hero){
                return (Hero)(character);
            }

            return (Dragon)(character);
        }




        /*static bool someAlive(int count) {
            // ISDEAD METHOD WILL BE FALSE
            if (count < 6) {
                return true;
            }
            return false;
        }*/







        static void writeResults() {
            Console.WriteLine("");
            Console.WriteLine("::::::::::::::::::::::::::::::::::::: RESULTS :::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("");
        } 

        static bool RealSomeAlive(List<Base> b) {
            for (var i = 0; i < b.Count; i++) {
                object somebody = convert(b[i]);


                if (somebody is Hero) {
                    Hero hra = ((Hero)somebody);
                    if (hra.isDead()) {
                        writeResults();
                        Console.WriteLine("Hero is dead.");
                        Console.WriteLine("Dragon is the winner.");
                        return false;
                    }   
                }

                if (somebody is Dragon) {
                    Dragon hra = ((Dragon)somebody);
                    if (hra.isDead()){
                        writeResults();
                        Console.WriteLine("Dragon is dead.");
                        Console.WriteLine("Hero is the winner.");
                        return false;
                    }
                }
            }

            return true;
        }


        /*

         public double averagePower(List<Base> b) {
            double avg = b.Average(a => a.maxDefense);
            return avg;
        }



         */



    }
}
