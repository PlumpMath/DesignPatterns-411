using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralPatterns.Patterns
{
    class Abstraction
    {
        public Implementor Implementor { get; set; }

        public virtual void Operation()
        {
            Implementor.Operation();
        }
    }

    abstract class Implementor
    {
        public abstract void Operation();
    }

    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            Implementor.Operation();
        }
    }

    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
}
