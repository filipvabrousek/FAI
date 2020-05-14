using System;
using System.Collections.Generic;
using System.IO;
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







    /*--------------------------------------------------HANDLING EVENTS------------------------------------------------*/


public class Adder
    {
        public delegate void dgEventRaiser();
        public event dgEventRaiser OnMultipleOfFiveReached;

        public int Add()
        {
           // int iSum = x + y;
            /* if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
             { OnMultipleOfFiveReached(); }*/

            OnMultipleOfFiveReached();
            return 0;
        }
    }

    /*  public delegate void Notify();  // delegate

      public class ProcessBusinessLogic {
          public event Notify ProcessCompleted; // event

          public void StartProcess(){
              OnProcessCompleted();
          }

          protected virtual void OnProcessCompleted() {

              Console.WriteLine("WWW");
              ProcessCompleted?.Invoke();
          }
      }*/





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

            if (damage > 230)
            {
                // hasDone = true;
                Console.WriteLine($"Hero has lost his sword");
            }
            else
            {
                Console.WriteLine($"Sword has been damaged by {value} total damage is {damage}" );
            }
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

            if (damage > 230) {
               // hasDone = true;
                Console.WriteLine($"Hero has lost his shield");
            } else  {
                Console.WriteLine($"Shield has been damaged by {value} total damage is {damage}");
            }
        }
    }

    /*----------------------------------------------------------------------------------------------- CHARACTERS -----------------------------------------------------------------------------------------------*/
    abstract class Base: IComparable<Base>
    {

   
        public double health;
        public double maxDamage;
        public double maxDefense;
      //  public String characterType;

        public Base(double health, double maxDamage, double maxDefense/*, String characterType*/){
            this.health = health;
            this.maxDamage = maxDamage;
            this.maxDefense = maxDefense;
        }

        public abstract double randDefense();
        public abstract double randAttack();
        public abstract void hitBy(double damage);
        public abstract int chooseOponent(int oponentIndex, List<Base> b);

        public int CompareTo(Base that)
        {

           // Console.WriteLine("huii");
            if (health > that.maxDamage) return -1;
            if (health == that.maxDamage) return 0;
            return 1;
        }
    }

    class Hero : Base, IComparable<Hero>{
        String name;
        Sword sword;
        Shield shield;
        String type;

        public Hero(Sword sword, Shield shield, String name, double health, double maxDamage, double maxDefense): base(health, maxDamage, maxDefense/*, "Hero"*/) {
            this.sword = sword;
            this.shield = shield;
            this.name = name;
        }

        public override double randAttack() {
            int attackValue = Randomizer.Next(1, (int)maxDamage); // 1 to maxDamage
            sword.setDamage(attackValue);
            shield.setDamage(attackValue * 0.5);
            return attackValue;
        }

        public override double randDefense()
        {
            int attackValue = Randomizer.Next(1, (int)maxDamage); // 1 to maxDamage
            sword.setDamage(attackValue);
            shield.setDamage(attackValue * 0.5);
            return attackValue;
        }

        public override void hitBy(double damage){
           // int randDamage = Randomizer.Next(0, maxDamage);
            shield.setDamage(damage);
            health -= damage;
        }

        public double getHealth(){


            if (health < 0) {
                return 0;
            }

            return health;
        }

        public bool isDead(){
            return health <= 0;
        }

        public string getName(){
            return name;
        }

        public int CompareTo(Hero that){
            if (health > that.maxDamage) return -1;
            if (health == that.maxDamage) return 0;
            return 1;
        }

        public override int chooseOponent(int oponentIndex, List<Base> b) {
            Console.WriteLine($"Hero chose oponent at index {oponentIndex}");

            object conv = b[oponentIndex];

            Adder a = new Adder();
            a.OnMultipleOfFiveReached += () => // oponent name in Event handler
            {
                Console.WriteLine("WOW");

                if (conv is Dragon)
                {
    
                    Dragon he = (Dragon)(conv);
                     Console.WriteLine("His name in EVENT handler is " + he.getName());
                }
                else if (conv is Hero)
                {
                    // Get his name
                    Hero he = (Hero)(conv);
                     Console.WriteLine("His name in EVENT handler is " + he.getName());
                }
            };

            int iAnswer = a.Add();
           

            // Hero can attack other Heroes, but Dragon cannot attack other dragons
            if (conv is Dragon) {
                // Get his name
                // Get his name
                Dragon he = (Dragon)(conv);
               // Console.WriteLine("His name is " + he.getName());

                return oponentIndex;
            } else if (conv is Hero) {

                // Get his name
                Hero he = (Hero)(conv);
               // Console.WriteLine("His name is " + he.getName());

                return oponentIndex;
            }

            

           
            return -1;


            
        }

        private void reached()
        {
            Console.WriteLine("EVENT: Invoked after oponent selection.");
        }

        
    }


    class Dragon : Base, IComparable<Dragon> {
        String name;
     
        public Dragon(String name, double health, double maxDamage, double maxDefense) : base(health, maxDamage, maxDefense /*"Dragon"*/)
        {
            this.name = name;
        }

        public override double randAttack(){
            //  int attackValue = Randomizer.Next(1, 5);
            int attackValue = Randomizer.Next(1, (int)maxDamage); // 1 to maxDamage


            int fire = Randomizer.Next(1, 10); // random defense activation

            if (fire < 6) {
                return attackValue * 0.8;
            } else {
                return 0;
            }
           
              // health -= randDamage;
        }

        public override double randDefense()
        {
            int attackValue = Randomizer.Next(1, (int)maxDamage); // 1 to maxDamage


            int fire = Randomizer.Next(1, 10); // random defense activation

            if (fire < 6){
                return attackValue * 0.8;
            }
            else {
                return 0;
            }
        }


        public override void hitBy(double damage){
            health -= damage;
        }

        public double getHealth() {

            if (health < 0){
                return 0;
            }
            return health;
        }

        public bool isDead() {
            return health <= 0;
        }

        public string getName() {
            return name;
        }

        public int CompareTo(Dragon that){
            if (health > that.maxDamage) return -1;
            if (health == that.maxDamage) return 0;
            return 1;
        }

        public override int chooseOponent(int oponentIndex, List<Base> b)
        {
            Console.WriteLine($"Hero has chosen his oponent at index {oponentIndex}");

            object conv = b[oponentIndex];

            Adder a = new Adder();
            a.OnMultipleOfFiveReached += () => // oponent name in Event handler
            {
      

                if (conv is Dragon)
                {

                    Dragon he = (Dragon)(conv);
                    Console.WriteLine("His name in EVENT HANDLER is " + he.getName());
                }
                else if (conv is Hero)
                {
                    // Get his name
                    Hero he = (Hero)(conv);
                    Console.WriteLine("His name in EVENT HANDLER is " + he.getName());
                }
            };

            int iAnswer = a.Add();

            // Hero can attack other Heroes, but Dragon cannot attack other dragons
            if (conv is Dragon){
                return -1; // Dragon cannot attack other dragons
            } else if (conv is Hero) {
                return oponentIndex;
            }

           

            return -1;
        }

        
    }






    class Audit {




        /*static Base[] sorted(Base[] b) {
           return b.OrderBy(x => x.)
        }*/

        static Base convert(Base character)
        {
            if (character is Dragon)
            {
                return (Dragon)(character);
            }

            if (character is Hero)
            {
                return (Hero)(character);
            }

            return (Dragon)(character);
        }


        public double averagePower(List<Base> b) {
            double avg = b.Average(a => a.maxDefense);
            return avg;
        }

        public string largerThanAverage(List<Base> b){
            string res = "";

            double avga = averagePower(b);

            for (var i = 0; i < b.Count; i++) {
                object conv = b[i];

                if (conv is Dragon) {
                    Dragon conva = (Dragon)(conv);

                    if (conva.maxDamage > avga){
                        res += "\n" + conva.getName();
                    }
                }

                if (conv is Hero){
                    Hero conva = (Hero)(conv);

                    if (conva.maxDamage > avga){
                        res += "\n" + conva.getName();
                    }
                }
            }
            return res;
        }


        public bool allHaveGraterThaFourthOfAverage(List<Base> b){
           // bool all = false;



            double avga = averagePower(b);


            int count = 0;

            for (var i = 0; i < b.Count; i++){
                object conv = b[i];


                if (conv is Dragon){
                    Dragon conva = (Dragon)(conv);

                    if (conva.maxDamage > avga / 4){
                        //res += "\n" + conva.getName();
                        count += 1;
                        // Console.WriteLine(conva.getName());
                    }
                }

                if (conv is Hero){
                    Hero conva = (Hero)(conv);

                    if (conva.maxDamage > avga / 4){
                        count += 1;
                        // res += "\n" + conva.getName();
                        // Console.WriteLine(conva.getName());
                    }
                }
            }




            return count == b.Count;
        }














    }




    /*  class Counter
     {
         public event EventHandler ThresholdReached;

         protected virtual void OnThresholdReached(EventArgs e)
         {
             EventHandler handler = ThresholdReached;
             handler?.Invoke(this, e);
         }

         // provide remaining implementation for the class
     } */


    // https://docs.microsoft.com/en-us/dotnet/standard/events/


    class MainClass
    {



        /* static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
        } */










        public static void dataManipulation(List<Base> characters) {

            Audit ad = new Audit();

            double avg = ad.averagePower(characters);
            Console.WriteLine("Average power of characters is " + avg);

            string res = ad.largerThanAverage(characters);
            Console.WriteLine("Characters with power larger than average are: " + res);


            bool allHave = ad.allHaveGraterThaFourthOfAverage(characters);

            if (allHave) {
                Console.WriteLine("All characters HAVE larger defense than 1/4 of average defense value.");
            }
            else {
                Console.WriteLine("All characters DO NOT HAVE larger defense than 1/4 of average defense value.");
            }




        }

        /* TO MAIN

        // var c = new Counter();
        // c.ThresholdReached += c_ThresholdReached;

        // provide remaining implementation for the class
        */




        public static void listCharacters(List<Base> characters) {
            Console.WriteLine("----------------------------------- CHARACTERS -----------------------------------");
            for (var i = 0; i < characters.Count; i++) {
                object obj = convert(characters[i]);

                if (obj is Dragon) {
                    Dragon dragon = (Dragon)(obj);
                    Console.WriteLine($"Dragon {dragon.getName()} ");
                }

                if (obj is Hero) {
                    Hero hero = (Hero)(obj);
                    Console.WriteLine($"Hero {hero.getName()} ");
                }
            }
        }











        public static void fightHero(Hero me, Hero oponent) {

            // choose 2, 3
            Console.WriteLine("FIGHTING");
            int round = 0;
            string ara = "";

            StreamWriter writetext = new StreamWriter("write.txt");

            while (me.isDead() == false && oponent.isDead() == false)
            {

                round += 1;
                // oponent.randAttack();
                me.hitBy(oponent.randAttack());
                oponent.hitBy(me.randDefense());

                Console.WriteLine($"------------------------------- ROUND {round} -------------------------------");

                string meLost = $"I lost {oponent.randAttack()} lives. \n";
                string meRamining = $"I have remaining {me.getHealth()} lives. \n";

                string oponentLost = $" Oponent lost {me.randDefense()} lives. \n";
                string remainingLost = $"Oponent has remaining {oponent.getHealth()} lives. \n";

                Console.WriteLine(meLost);
                Console.WriteLine(meRamining);

                Console.WriteLine(oponentLost);
                Console.WriteLine(remainingLost);

                ara += meLost;
                ara += meRamining;

                ara += oponentLost;
                ara += remainingLost;
                //  string createText = "Hello and Welcome" + Environment.NewLine;
            }

            ara += "------------------------------------------ \n";

            if (oponent.isDead())
            {
                Console.WriteLine("I won!");
                ara += "I won";
            }
            else
            {
                Console.WriteLine("Oponent won!");
                ara += "Oponent won";
            }


            File.WriteAllText("results.txt", ara);
        }


        public static void fightHeroAndDragon(Hero me, Dragon oponent)
        {
            // choose 2, 3
            Console.WriteLine("FIGHTING");
            int round = 0;
            string ara = "";

            StreamWriter writetext = new StreamWriter("write.txt");

            while (me.isDead() == false && oponent.isDead() == false)
            {

                round += 1;
                // oponent.randAttack();
                me.hitBy(oponent.randAttack());
                oponent.hitBy(me.randDefense());

                Console.WriteLine($"------------------------------- ROUND {round} -------------------------------");

                string meLost = $"I lost {oponent.randAttack()} lives. \n";
                string meRamining = $"I have remaining {me.getHealth()} lives. \n";

                string oponentLost = $" Oponent lost {me.randDefense()} lives. \n";
                string remainingLost = $"Oponent has remaining {oponent.getHealth()} lives. \n";

                Console.WriteLine(meLost);
                Console.WriteLine(meRamining);

                Console.WriteLine(oponentLost);
                Console.WriteLine(remainingLost);

                ara += meLost;
                ara += meRamining;

                ara += oponentLost;
                ara += remainingLost;


                //  string createText = "Hello and Welcome" + Environment.NewLine;
            }


            ara += "------------------------------------------ \n";

            if (oponent.isDead())
            {
                Console.WriteLine("I won!");
                ara += "I won";
            }
            else
            {
                Console.WriteLine("Oponent won!");
                ara += "Oponent won";
            }


            File.WriteAllText("results.txt", ara);
        }

        public static void fight(Base ME, Base OPONENT) {


            // ME is Dragon and  oponent is Hero



            if ((ME is Hero) && (OPONENT is Dragon))
            {
                Hero me = ((Hero)ME);
                Dragon oponent = ((Dragon)OPONENT);
                fightHeroAndDragon(me, oponent);

            } else if ((ME is Hero) && (OPONENT is Hero)) {
                Hero me = ((Hero)ME);
                Hero oponent = ((Hero)OPONENT);
                fightHero(me, oponent);
            }
        }





















































       /* public static List<Base> SortUsingCompareTo (List<Base> characters){

           // characters.Sort();
              try
              {
                  characters.Sort();
              }
              catch (Exception e)
              {
                  Console.WriteLine("UIGIUG");
                  Console.WriteLine(e);
              }


           // return characters.Sort();

        }*/




        public static void Main(string[] args) {
            int round = 0;
           
            Sword sword = new Sword("NiceSword", 130);
            Shield shield = new Shield("NiceShield", 130);

            List<Base> characters = new List<Base>(){
            new Hero(sword, shield, "Filip", 100, 5, 100), // 5 is maxDamage
            new Hero(sword, shield, "Jana", 100, 5, 100),
            new Hero(sword, shield, "Terka", 100, 5, 100),
            new Dragon("Max", 100, 100, 5)
            };

            dataManipulation(characters);
            listCharacters(characters);


            // List<Base> usingCompareTo = SortUsingCompareTo(characters);

            
            characters.Sort(); // SORTED USING CompareTo
                               // characters.reverse(Sort()); // SORTED USING CompareTo
                               //  List<Base> usingCompareTo =




            Console.WriteLine("Strongest to least strong");

            // Strongest to least strong
            for (var i = 0; i < characters.Count; i++) {
                Base d = convert(characters[i]);
                if (d is Dragon) {
                    Dragon dra = ((Dragon)d);
                    Console.WriteLine(dra.getName());
                }

                if (d is Hero) {
                    Hero hero = ((Hero)d);
                    Console.WriteLine(hero.getName());
                }
            }


            // 97% :)
            Console.WriteLine("Least strong to strongest.");
            // Least Strong to Strongest
            for (var i = characters.Count - 1; i > 0; i--)
            {
                Base d = convert(characters[i]);
                if (d is Dragon)
                {
                    Dragon dra = ((Dragon)d);
                    Console.WriteLine(dra.getName());
                }

                if (d is Hero)
                {
                    Hero hero = ((Hero)d);
                    Console.WriteLine(hero.getName());
                }
            }




            Console.WriteLine("Choose your character (enter index)");
            int aidx = int.Parse(Console.ReadLine());


            object ME = characters[0];
            object OPONENT = characters[0];

            Console.WriteLine("You character is " + name(characters[aidx]));
            object o = convert(characters[aidx]);

            ME = characters[aidx];

            if (o is Dragon) {
                Dragon dra = ((Dragon)o);

                Console.WriteLine("Choose his oponent: (enter index)");
                int bidx = int.Parse(Console.ReadLine());
                int ipo = dra.chooseOponent(bidx, characters);
                Console.WriteLine("OPONENT IS" + name(characters[ipo]));
                OPONENT = characters[ipo];
            } else {
                Hero dra = ((Hero)o);

                Console.WriteLine("Choose his oponent: (enter index)");
                int bidx = int.Parse(Console.ReadLine());
                int ipo = dra.chooseOponent(bidx, characters);
                Console.WriteLine("OPONENT IS" + name(characters[ipo]));
                OPONENT = characters[ipo];
            }




            /*-----------------------------------AT THIS POINT, I WANT 2 CHARACTERS FIGHTING-----------------------------------*/





            fight(((Base)ME), ((Base)OPONENT));











                //  Console.WriteLine($"You have selected indexes A: {aidx}  B: {bidx}");










                // 1 - select 

                // someAlive(count)
                /* while (RealSomeAlive(characters)) {
                     count += 1;
                     for (var i = 0; i < characters.Count - 1; i++) {
                         object first = convert(characters[i]);
                         object second = convert(characters[i + 1]);
                         double firstAttackValue = 0;

                         round += 1;
                         Console.WriteLine($"=============================ROUND {round} ===========================");

                         if (first is Hero) {
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
                 }*/

















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


        static string name(Base character)
        {
            if (character is Dragon) {
                Dragon drg = (Dragon)(character);
                return $" Dragon {drg.getName()}";
            }

            if (character is Hero) {
                Hero hrg = (Hero)(character);
                return $" Hero {hrg.getName()}";
            }

            return "empty";
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
    }
}

// 14/05/20 - 19:03 The End
