using System;
using FactoryMethod.Pattern;
using FactoryMethod.RealCode;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern code:");
            Creator[] creators = { new ConcreteCreatorA(), new ConcreteCreatorB() };
            foreach (Creator creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine(product.GetType().Name);
            }

            Console.ReadKey();

            //----------------------------------------------------------------//

            Console.WriteLine("\nReal code:");
            Application[] apps = { new AspNetApplication() , new JavaApplication() };         
            foreach (Application app in apps)
            {
                Console.WriteLine(app.GetType().Name);
                foreach (Technology technology in app.Technologies)
                    Console.WriteLine("* " + technology.GetType().Name);
            }

            Console.ReadKey();
        }
    }
}

