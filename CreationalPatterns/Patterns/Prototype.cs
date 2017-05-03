using System;

/*
 * Паттерн Прототип (Prototype) позволяет создавать объекты на основе уже ранее созданных объектов-прототипов.
 * То есть по сути данный паттерн предлагает технику клонирования объектов.
 */

namespace CreationalPatterns.Patterns
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
