using System;
using System.Collections.Generic;
/*
 * Builder separates the construction of a complex object 
 * from its representation so that the same construction process can create different representations.
 */

namespace CreationalPatterns.Patterns
{
    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    class ConcreteBuilder1 : Builder
    {
        private readonly Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add(" *PartA");
        }

        public override void BuildPartB()
        {
            _product.Add(" *PartB");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private readonly Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add(" *PartX");
        }

        public override void BuildPartB()
        {
            _product.Add(" *PartY");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }


    class Product
    {
        private readonly List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("Product Parts");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }
}
