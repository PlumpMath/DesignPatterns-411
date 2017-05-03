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
            Console.WriteLine("=====================================================");
            Console.WriteLine("Код шаблона (Prototype):");
            Prototype prototype = new ConcretePrototype("Привет, мир");
            Prototype prototypeClone = prototype.Clone();
            prototypeClone.ShowField();

            Console.WriteLine("Применение шаблона в реальных ситуациях (Prototype):");
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
            Console.WriteLine("=====================================================");
            Console.WriteLine("Код шаблона (Singleton):");
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();
            Console.WriteLine(s1.Equals(s2) ? "Ссылки экземпляров объектов эквивалентны" : "Ссылки экземпляров объектов указывают на разные ячейки памяти");

            Console.WriteLine("Применение шаблона в реальных ситуациях (Singleton):");

            Thread[] threads = { new Thread(TestMultithreadedSingleton), new Thread(TestMultithreadedSingleton), new Thread(TestMultithreadedSingleton) };
            for (var index = 0; index < threads.Length; index++)
            {
                threads[index].Start();
                if (index == threads.Length - 1)
                    threads[index].Join();
            }
        }
        private static void ShowBuilder()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("Код шаблона (Builder):");
            Director director = new Director();

            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.WriteLine("Применение шаблона в реальных ситуациях (Builder):");
            Shop shop = new Shop();

            VehicleBuilder builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();
        }
        private static void ShowAbstractFactory()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("Код шаблона (AbstractFactory):");
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();

            Console.WriteLine("Применение шаблона в реальных ситуациях (AbstractFactory):");
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
        }
        private static void ShowFactoryMethod()
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("Код шаблона (FactoryMethod):");
            Creator[] creators = { new ConcreteCreatorA(), new ConcreteCreatorB() };
            foreach (Creator creator in creators)
            {
                Good product = creator.FactoryMethod();
                Console.WriteLine(product.GetType().Name);
            }

            Console.WriteLine("Применение шаблона в реальных ситуациях (FactoryMethod):");
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
