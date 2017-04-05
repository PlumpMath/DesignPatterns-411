using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Pattern
{
    abstract class Prototype
    {
        public string Field { get; private set; }

        protected Prototype(string field)
        {
           Field = field;
        }
        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string field) : base (field)
        {
        }
        public override Prototype Clone()
        {
            return MemberwiseClone() as Prototype;
        }
    }
}
