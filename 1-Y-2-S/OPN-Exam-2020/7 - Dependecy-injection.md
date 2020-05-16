## Dependency injection
```cs
using System;

namespace ConsoleApp8
{
    interface IMotor
    {
        void Nastartuj();
    }

    class BenzinovyMotor : IMotor
    {
        public void Nastartuj()
        {
            Console.WriteLine("Zapalil jsem smes benzinu a vzduchu zapalovaci svickou.");
        }

    }

    class NaftovyMotor : IMotor
    {
        public void Nastartuj()
        {
            Console.WriteLine("Zapalil jsem jsem smes díky vznícení způsobené vysokou teplotou stlačeného vzduchu.");
        }
    }

    class Automobil
    {
        private IMotor motor;

        public Automobil(IMotor motor)
        {
            this.motor = motor;
        }

        public void Jed()
        {
            Console.WriteLine("Startuji ...");
            motor.Nastartuj();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Automobil automobilBenzin = new Automobil(new BenzinovyMotor());
            automobilBenzin.Jed();

            Automobil automobilNafta = new Automobil(new NaftovyMotor());
            automobilNafta.Jed();
        }
    }
}
```
