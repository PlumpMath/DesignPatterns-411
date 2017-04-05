using System;
using Prototype.Pattern;
using Prototype.RealWorldCode;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern code:");
            Pattern.Prototype prototype = new ConcretePrototype1("Hellow, world");
            Pattern.Prototype protoClone = prototype.Clone();
            Console.WriteLine("protoClone.Field: " + protoClone.Field + " , prototype: " + prototype.Field);
            Console.ReadKey();

            //--------------------------------------//
            Console.WriteLine("\nReal code:");
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

            Console.ReadKey();
        }
    }
}
