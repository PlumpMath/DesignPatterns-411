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

            Console.ReadKey();
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
