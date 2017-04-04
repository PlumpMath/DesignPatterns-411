using System;
using AbstractFactory.Pattern;
using AbstractFactory.RealWorldCode;

/*
 * Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс для создания 
 * семейств связанных или зависимых объектов без указания их конкретных классов.
 */


namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern code:");
            Pattern.AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            Pattern.AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            Console.ReadKey();

            //--------------------------------------------------------------//

            Console.WriteLine("\nReal code:");
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            Console.ReadKey();
        }
    }
}
