using System;
using Builder.Pattern;
using Builder.RealWorldCode;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pattern code:");
            Director director = new Director();

            Pattern.Builder b1 = new ConcreteBuilder1();
            Pattern.Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.ReadKey();
            //------------------------------------------------------//
            Console.WriteLine("\nReal code:");
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

            Console.ReadKey();

        }
    }
}
