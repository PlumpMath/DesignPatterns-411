using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Console.ReadKey();
        }

        private static void ShowComposite()
        {
            Console.WriteLine("\nPattern code (Composite):");
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
            Console.WriteLine("\nPattern code (Bridge):");
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
