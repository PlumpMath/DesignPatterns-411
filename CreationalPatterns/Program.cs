using System;
using System.Threading;
using CreationalPatterns.Patterns;
using CreationalPatterns.RealWorldCodes;
namespace CreationalPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowFactoryMethod();
            ShowAbstractFactory();
            ShowBuilder();
            ShowSingleton();
            ShowPrototype();
            Console.ReadKey();
        }

        private static void ShowPrototype()
        {
            Console.WriteLine("\nPattern code (Prototype):");
            Prototype prototype = new ConcretePrototype("Hellow, world");
            Prototype prototypeClone = prototype.Clone();
            prototypeClone.ShowField();
            
            Console.WriteLine("Real code (Prototype):");
            ColorManager colormanager = new ColorManager
            {
                ["red"] = new Color(255, 0, 0),
                ["green"] = new Color(0, 255, 0),
                ["blue"] = new Color(0, 0, 255),
                ["angry"] = new Color(255, 54, 0),
                ["peace"] = new Color(128, 211, 128),
                ["flame"] = new Color(211, 34, 20)
            };

            ColorPrototype redColor = colormanager["red"].Clone();
            ColorPrototype peaceColor = colormanager["peace"].Clone();
            redColor.ShowColor();
            peaceColor.ShowColor();
        }
        private static void ShowSingleton()
        {
            Console.WriteLine("\nPattern code (Singleton):");
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            Console.WriteLine(s1.Equals(s2) ? "Objects are the same instance" : "Objects aren't the same instance");

            Console.WriteLine("Real code (Singleton):");

            Thread[] threads = { new Thread(TestMultithreadedSingleton), new Thread(TestMultithreadedSingleton) };

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

        }
        private static void ShowBuilder()
        {
            Console.WriteLine("\nPattern code (Builder):");
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.WriteLine("Real code (Builder):");
            Shop shop = new Shop();

            VehicleBuilder builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
        }
        private static void ShowAbstractFactory()
        {
            Console.WriteLine("\nPattern code (AbstractFactory):");
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            Console.WriteLine("Real code (AbstractFactory):");
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
        private static void ShowFactoryMethod()
        {
            Console.WriteLine("\nPattern code (FactoryMethod):");
            Creator[] creators = { new ConcreteCreatorA(), new ConcreteCreatorB() };
            foreach (Creator creator in creators)
            {
                ProductFm product = creator.FactoryMethod();
                Console.WriteLine(product.GetType().Name);
            }

            Console.WriteLine("Real code (FactoryMethod):");
            Application[] apps = { new AspNetApplication().CreateApplication(), new JavaApplication().CreateApplication() };
            foreach (Application app in apps)
            {
                Console.WriteLine(app.GetType().Name);
                foreach (Technology technology in app.Technologies)
                    Console.WriteLine("* " + technology.GetType().Name);
            }
        }
        private static void TestMultithreadedSingleton()
        {
            ConfigurationManager configManager = ConfigurationManager.GetInstance();
            Console.WriteLine(configManager.GetHashCode());
        }
    }
}
