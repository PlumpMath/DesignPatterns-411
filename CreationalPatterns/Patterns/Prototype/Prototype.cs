using System;

namespace CreationalPatterns.Patterns.Prototype
{
    abstract class Prototype
    {
        protected readonly string Field;

        public virtual void ShowField()
        {
            Console.WriteLine(Field);
        } 
        protected Prototype(string field)
        {
           Field = field;
        }
        public abstract Prototype Clone();
    }

    class ConcretePrototype : Prototype
    {
        public ConcretePrototype(string field) : base (field)
        {
        }
        public override Prototype Clone()
        {
            return MemberwiseClone() as Prototype;
        }
    }
}
