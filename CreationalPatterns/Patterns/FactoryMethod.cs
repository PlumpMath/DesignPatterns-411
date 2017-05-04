/*
 * Factory Method defines an interface for creating an object, 
 * but let subclasses decide which class to instantiate. 
 * Factory Method lets a class defer instantiation to subclasses.
 */

namespace CreationalPatterns.Patterns
{
    abstract class ProductFm
    {
    }
    class ConcreteProductA : ProductFm
    {
    }
    class ConcreteProductB : ProductFm
    {
    }

    abstract class Creator
    {
        public abstract ProductFm FactoryMethod();
    }
    class ConcreteCreatorA : Creator
    {
        public override ProductFm FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    class ConcreteCreatorB : Creator
    {
        public override ProductFm FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
