/*
 * Фабричный метод (Factory Method) - это паттерн, который определяет интерфейс для создания объектов некоторого класса, но 
 * непосредственное решение о том, объект какого класса создавать происходит в подклассах.
 */

namespace CreationalPatterns.Patterns
{
    abstract class Good
    {
    }
    class ConcreteGoodA : Good
    {
    }
    class ConcreteGoodB : Good
    {
    }

    abstract class Creator
    {
        public abstract Good FactoryMethod();
    }
    class ConcreteCreatorA : Creator
    {
        public override Good FactoryMethod()
        {
            return new ConcreteGoodA();
        }
    }
    class ConcreteCreatorB : Creator
    {
        public override Good FactoryMethod()
        {
            return new ConcreteGoodB();
        }
    }
}
