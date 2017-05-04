namespace StructuralPatterns.RealWorldCodes
{
    abstract class Pizza
    {
        protected Pizza(string n)
        {
            Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Italian pizza")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Bulgarian pizza")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza Pizza;

        protected PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            Pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p) : base(p.Name + ", with tomatoes", p)
        { }

        public override int GetCost()
        {
            return Pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", with cheese", p)
        { }

        public override int GetCost()
        {
            return Pizza.GetCost() + 5;
        }
    }
}
