## Singleton
* only 1 instance in entire code

```cs
using System;

namespace ConsoleApp28
{
    class Logger
    {
        private static Logger logger = null;

        public static Logger Instance
        {
            get
            {
                return logger ?? (logger = new Logger());
            }
        }

        private Logger()
        {

        }

        public void Log(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.Instance;
            logger1.Log("Program spusten");

            Logger logger2 = Logger.Instance;
            logger1.Log("Program pokracuje");
        }
    }
}
```
