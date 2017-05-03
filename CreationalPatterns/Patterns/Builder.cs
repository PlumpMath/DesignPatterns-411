using System;
using System.Collections.Generic;

/*
 * Строитель (Builder) - шаблон проектирования, который инкапсулирует создание объекта и позволяет разделить его на различные этапы.
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
            _product.Add(" *Часть А");
        }

        public override void BuildPartB()
        {
            _product.Add(" *Часть B");
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
            _product.Add(" *Часть X");
        }

        public override void BuildPartB()
        {
            _product.Add(" *Часть Y");
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
            Console.WriteLine("Составные части товара:");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }
}
