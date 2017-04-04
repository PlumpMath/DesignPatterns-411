using System.Collections.Generic;

namespace FactoryMethod.RealWorldCode
{
    abstract class Application
    {
        public abstract Application CreateApplication();
        public List<Technology> Technologies { get; } = new List<Technology>();
    }

    class AspNetApplication : Application
    {
        public override Application CreateApplication()
        {
            Technologies.Add(new AspNetMvc());
            Technologies.Add(new CSharp());
            Technologies.Add(new SqlServer());

            return this;
        }
    }

    class JavaApplication : Application
    {
        public override Application CreateApplication()
        {
            Technologies.Add(new Java());
            Technologies.Add(new Hibernate());

            return this;
        }
    }

    abstract class Technology
    {
    }
    class AspNetMvc : Technology
    {
    }
    class CSharp : Technology
    {

    }
    class Hibernate : Technology
    {

    }
    class Java : Technology
    {

    }
    class SqlServer : Technology
    {

    }
}
