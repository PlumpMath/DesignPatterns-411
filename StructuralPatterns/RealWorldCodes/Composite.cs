using System;
using System.Collections.Generic;

namespace StructuralPatterns.RealWorldCodes
{
    abstract class DrawingElement
    {
        protected string Name;

        protected DrawingElement(string name)
        {
            Name = name;
        }

        public abstract void Add(DrawingElement d);
        public abstract void Remove(DrawingElement d);
        public abstract void Display(int indent);
    }

    class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name) : base(name)
        {
        }

        public override void Add(DrawingElement c)
        {
            Console.WriteLine("Cannot add to a PrimitiveElement");
        }

        public override void Remove(DrawingElement c)
        {
            Console.WriteLine("Cannot remove from a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) + " " + Name);
        }
    }

    class CompositeElement : DrawingElement
    {
        private readonly List<DrawingElement> _elements = new List<DrawingElement>();

        public CompositeElement(string name) : base(name)
        {
        }

        public override void Add(DrawingElement d)
        {
            _elements.Add(d);
        }

        public override void Remove(DrawingElement d)
        {
            _elements.Remove(d);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new string('-', indent) + "+ " + Name);

            foreach (DrawingElement d in _elements)
            {
                d.Display(indent + 2);
            }
        }
    }
}
