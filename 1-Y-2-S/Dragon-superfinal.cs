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
        public event dgEventRaiser OnShouldFireEvent;

        public int Add()
        {
          
            OnShouldFireEvent();
            return 0;
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
        

        public Sword(string name, double weight, double damage): base(name) {
            this.name = name;
            this.weight = weight;
            this.damage = damage;
        }

        public double getDamage() {
            return damage;
        }

        public void setDamage(double value) {
            damage += value * weight;

            if (damage > 230)
            {
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
        double weight;

        public Shield(String name, double weight, double damage) : base(name){
            this.name = name;
            this.damage = damage;
            this.weight = weight;
        }

       public double getDamage(){
            return damage;
        }

        public void setDamage(double value){
            damage += value * weight;

            if (damage > 230) {
               // hasDone = true;
                Console.WriteLine($"Hero has lost his shield");
            } else  {
                Console.WriteLine($"Shield has been damaged by {value} total damage is {damage}");
            }
        }
    }

    /*----------------------------------------------------------------------------------------------- CHARACTERS -----------------------------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------------------------- BASE CLASS -----------------------------------------------------------------------------------------------*/
    abstract class Base: IComparable<Base>
    {   
        public double health;
        public double maxDamage;
        public double maxDefense;

        public Base(double health, double maxDamage, double maxDefense){
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
            if (health > that.maxDamage) return -1;
            if (health == that.maxDamage) return 0;
            return 1;
        }
    }


    /*----------------------------------------------------------------------------------------------- HERO -----------------------------------------------------------------------------------------------*/
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
            int attackValue = Randomizer.Next(1, (int)maxDefense); // 1 to maxDamage
            sword.setDamage(attackValue);
            shield.setDamage(attackValue * 0.5);
            return attackValue;
        }

        public override double randDefense()
        {
            /* int attackValue = Randomizer.Next(1, (int)maxDamage); // 1 to maxDamage
            // sword.setDamage(attackValue);
            // shield.setDamage(attackValue * 0.5);
             return attackValue;*/
            int attackValue = Randomizer.Next(1, (int)maxDefense); // 1 to maxDamage

            int fire = Randomizer.Next(1, 10); // random defense activation

            if (fire < 6) {
                return attackValue * 0.7;
            } else {
                return 0;
            }
        }

        public override void hitBy(double damage){
           // int randDamage = Randomizer.Next(0, maxDamage);
            shield.setDamage(damage);
            sword.setDamage(damage);


            if (damage < maxDamage)
            {
                health -= damage;
            }
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
            a.OnShouldFireEvent += () => // oponent name in Event handler
            {
                if (conv is Dragon){
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
                Dragon he = (Dragon)(conv);
                return oponentIndex;
            } else if (conv is Hero) {
                // Get his name
                Hero he = (Hero)(conv);
                return oponentIndex;
            }
            return -1;  
        }

        private void reached()
        {
            Console.WriteLine("EVENT: Invoked after oponent selection.");
        }
    }



    /*----------------------------------------------------------------------------------------------- DRAGON -----------------------------------------------------------------------------------------------*/
    class Dragon : Base, IComparable<Dragon> {
        String name;
     
        public Dragon(String name, double health, double maxDamage, double maxDefense) : base(health, maxDamage, maxDefense /*"Dragon"*/)
        {
            this.name = name;
        }

        public override double randAttack(){
            //  int attackValue = Randomizer.Next(1, 5);
            int attackValue = Randomizer.Next(1, (int)maxDefense); // 1 to maxDamage


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
            int attackValue = Randomizer.Next(1, (int)maxDefense); // 1 to maxDamage

            int fire = Randomizer.Next(1, 10); // random defense activation

            if (fire < 6){
                return attackValue * 0.8;
            }
            else {
                return 0;
            }
        }


        public override void hitBy(double damage){
            if (damage < maxDamage)
            {
                health -= damage;
            }
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
            a.OnShouldFireEvent += () => // oponent name in Event handler
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





    /*----------------------------------------------------------------------------------------------- (4) DATA MANIPULATION  -----------------------------------------------------------------------------------------------*/
    class Audit {
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
            double avga = averagePower(b);
            int count = 0;

            for (var i = 0; i < b.Count; i++){
                object conv = b[i];


                if (conv is Dragon){
                    Dragon conva = (Dragon)(conv);

                    if (conva.maxDamage > avga / 4){
                       
                        count += 1;
          
                    }
                }

                if (conv is Hero){
                    Hero conva = (Hero)(conv);

                    if (conva.maxDamage > avga / 4){
                        count += 1;
                       
                    }
                }
            }

            return count == b.Count;
        }
    }





    class MainClass
    {
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



        /*-----------------------------------FIGHT BETWEEN 2 HEROES-----------------------------------*/
        // data about the fight will be written in results.txt

        public static void fightHero(Hero me, Hero oponent) {

            // choose 2, 3
            Console.WriteLine("FIGHTING.");
            int round = 0;
            string ara = "";


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


            File.WriteAllText("results.txt", ara); // WRITE TO TEXT FILE
        }


        /*-----------------------------------FIGHT BETWEEN DRAGON AND HERO-----------------------------------*/
        // data about the fight will be written in results.txt

        public static void fightHeroAndDragon(Hero me, Dragon oponent)
        {
            // choose 2, 3
            Console.WriteLine("FIGHTING");
            int round = 0;
            string ara = "";


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


            File.WriteAllText("results.txt", ara); // WRITE TO TEXT FILE
        }

        public static void fight(Base ME, Base OPONENT) {
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

        /*----------------------------------------------------------------------------------------------- MAIN -----------------------------------------------------------------------------------------------*/
        public static void Main(string[] args) {
           
            Sword sword = new Sword("NiceSword", 1, 130);
            Shield shield = new Shield("NiceShield", 1, 130);

            List<Base> characters = new List<Base>(){
            new Hero(sword, shield, "Filip", 100, 5, 5), // 5 is maxDamage
            new Hero(sword, shield, "Jana", 100, 5, 5),
            new Hero(sword, shield, "Terka", 100, 5, 5),
            new Dragon("Max", 100, 100, 5)
            };


            List<Base> copyToSort = characters.ToList(); // make a copy, so our original array stays intact

            dataManipulation(characters);
            listCharacters(characters);

            copyToSort.Sort(); // SORTED USING CompareTo
                                            

            Console.WriteLine("Strongest to least strong");

            // Strongest to least strong
            for (var i = 0; i < copyToSort.Count; i++) {
                Base d = convert(copyToSort[i]);
                if (d is Dragon) {
                    Dragon dra = ((Dragon)d);
                    Console.WriteLine(dra.getName());
                }

                if (d is Hero) {
                    Hero hero = ((Hero)d);
                    Console.WriteLine(hero.getName());
                }
            }

            Console.WriteLine("Least strong to strongest.");

            // Least Strong to Strongest
            for (var i = copyToSort.Count - 1; i >= 0; i--)
            {
                Base d = convert(copyToSort[i]);
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




            /*-----------------------------------AT THIS POINT, 2 CHARACTERS FIGHTING-----------------------------------*/
            fight(((Base)ME), ((Base)OPONENT));
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

// 14/05/20 - 19:39 The End
