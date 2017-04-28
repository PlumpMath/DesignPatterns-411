/*
 * Фабричный метод (Factory Method) - это паттерн, который определяет интерфейс для создания объектов некоторого класса, но 
 * непосредственное решение о том, объект какого класса создавать происходит в подклассах.
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
