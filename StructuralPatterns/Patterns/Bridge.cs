using System;

/*
 * Bridge decouples an abstraction from its implementation so that the two can vary independently.
 */

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
