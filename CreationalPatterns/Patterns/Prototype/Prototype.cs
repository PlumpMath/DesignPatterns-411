namespace CreationalPatterns.Patterns.Prototype
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
