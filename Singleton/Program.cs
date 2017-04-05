using System;
using Singleton.RealWorldCode;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern code:");
            Pattern.Singleton s1 = Pattern.Singleton.Instance();
            Pattern.Singleton s2 = Pattern.Singleton.Instance();

            if (s1.Equals(s2))
                Console.WriteLine("Objects are the same instance");

            Console.ReadKey();

            Console.WriteLine("\nReal code:");
            
            ConfigurationManager configManager1 = ConfigurationManager.GetInstance();
            ConfigurationManager configManager2 = ConfigurationManager.GetInstance();
            if (configManager1.Equals(configManager2))
                Console.WriteLine("Objects are the same instance");

            Console.ReadKey();
        }
    }
}
