using System;
using CreationalPatterns.Patterns.AbstractFactory;
using CreationalPatterns.Patterns.Builder;
using CreationalPatterns.Patterns.FactoryMethod;
using CreationalPatterns.Patterns.Prototype;
using CreationalPatterns.Patterns.Singleton;
using CreationalPatterns.RealWorldCodes.AbstractFactory;
using CreationalPatterns.RealWorldCodes.Builder;
using CreationalPatterns.RealWorldCodes.FactoryMethod;
using CreationalPatterns.RealWorldCodes.Prototype;
using CreationalPatterns.RealWorldCodes.Singleton;

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
            Prototype prototype = new ConcretePrototype1("Hellow, world");
            Prototype protoClone = prototype.Clone();
            Console.WriteLine("protoClone.Field: " + protoClone.Field + " , prototype: " + prototype.Field);

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

            Color color1 = colormanager["red"].Clone() as Color;
            Color color2 = colormanager["peace"].Clone() as Color;
            Color color3 = colormanager["flame"].Clone() as Color;
        }
        private static void ShowSingleton()
        {
            Console.WriteLine("\nPattern code (Singleton):");
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1.Equals(s2))
                Console.WriteLine("Objects are the same instance");

            Console.WriteLine("Real code (Singleton):");

            ConfigurationManager configManager1 = ConfigurationManager.GetInstance();
            ConfigurationManager configManager2 = ConfigurationManager.GetInstance();
            if (configManager1.Equals(configManager2))
                Console.WriteLine("Objects are the same instance");
        }
        private static void ShowBuilder()
        {
            Console.WriteLine("\nPattern code (Builder):");
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Patterns.Builder.Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Patterns.Builder.Product p2 = b2.GetResult();
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
                Patterns.FactoryMethod.Product product = creator.FactoryMethod();
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
    }
}
