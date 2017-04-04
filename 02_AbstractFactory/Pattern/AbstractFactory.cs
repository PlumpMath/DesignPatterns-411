using System;

namespace AbstractFactory.Pattern
{
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    abstract class AbstractProductA
    {
    }

    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }
    class ProductA1 : AbstractProductA
    {
    }
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(GetType().Name + " interacts with " + a.GetType().Name);
        }
    }
    class ProductA2 : AbstractProductA
    {
    }
    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(GetType().Name + " interacts with " + a.GetType().Name);
        }
    }
    class Client
    {
        private readonly AbstractProductA _abstractProductA;
        private readonly AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();  
        }

        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}
