using System;
using StructuralPatterns.Patterns;
using StructuralPatterns.RealWorldCodes;

namespace StructuralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAdapter();
            ShowBridge();
            ShowComposite();
            ShowDecorator();
            ShowFacade();
            ShowFlyweight();
            ShowProxy();

            Console.ReadKey();
        }

        private static void ShowProxy()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Proxy):");
            Proxy proxy = new Proxy();
            proxy.Request();
            Console.WriteLine("\nReal code (Proxy):");
            // Create math proxy
            MathProxy mathProxy = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + mathProxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + mathProxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + mathProxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + mathProxy.Div(4, 2));
        }
        private static void ShowFlyweight()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Flyweight):");
            int extrinsicstate = 22;
            FlyweightFactory factory = new FlyweightFactory();
            Flyweight fx = factory.GetFlyweight("X");
            fx.Operation(--extrinsicstate);
            Flyweight fy = factory.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);
            Flyweight fz = factory.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);
            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicstate);
            Console.WriteLine("\nReal code (Flyweight):");
            // Build a document with text
            string document = "AAZZBBZB";
            char[] chars = document.ToCharArray();
            CharacterFactory characterFactory = new CharacterFactory();

            // extrinsic state
            int pointSize = 10;

            // For each character use a flyweight object
            foreach (char c in chars)
            {
                pointSize++;
                Character character = characterFactory.GetCharacter(c);
                character.Display(pointSize);
            }
        }
        private static void ShowFacade()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Facade):");
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            Console.WriteLine("\nReal code (Facade):");
            Mortgage mortgage = new Mortgage();
            Customer customer = new Customer("Ann McKinsey");
            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));
        }
        private static void ShowDecorator()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Decorator):");
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            Console.WriteLine("\nReal code (Decorator):");

            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());

        }
        private static void ShowComposite()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Composite):");
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);


            Console.WriteLine("\nReal code (Composite):");
            CompositeElement picture = new CompositeElement("Picture");
            picture.Add(new PrimitiveElement("Red Line"));
            picture.Add(new PrimitiveElement("Blue Circle"));
            picture.Add(new PrimitiveElement("Green Box"));

            CompositeElement circles = new CompositeElement("Two Circles");
            circles.Add(new PrimitiveElement("Black Circle"));
            circles.Add(new PrimitiveElement("White Circle"));
            picture.Add(circles);

            PrimitiveElement line = new PrimitiveElement("Yellow Line");
            picture.Add(line);
            picture.Remove(line);

            picture.Display(1);
        }
        private static void ShowBridge()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Bridge):");
            Abstraction ab = new RefinedAbstraction();
            ab.Implementor = new ConcreteImplementorA();
            ab.Operation();
            ab.Implementor = new ConcreteImplementorB();
            ab.Operation();

            Console.WriteLine("\nReal code (Bridge):");
            Programmer freelancer = new FreelanceProgrammer(new CppLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();
        }
        private static void ShowAdapter()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Pattern code (Adapter):");
            Target target = new Adapter();
            target.Request();

            Console.WriteLine("\nReal code (Adapter):");
            Driver driver = new Driver();
            Auto auto = new Auto();
            driver.Travel(auto);
            Camel camel = new Camel();
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);
        }
    }
}
