using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.RealWorldCodes
{
    interface ITransport
    {
        void Drive();
    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("The car is on the road");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("The camel is walking through the desert sand");
        }
    }
    // Adapter from Camel to ITransport
    class CamelToTransportAdapter : ITransport
    {
        private readonly Camel _camel;
        public CamelToTransportAdapter(Camel c)
        {
            _camel = c;
        }

        public void Drive()
        {
            _camel.Move();
        }
    }
}
