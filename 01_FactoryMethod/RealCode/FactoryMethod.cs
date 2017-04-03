using System.Collections.Generic;

namespace FactoryMethod.RealCode
{
    abstract class Application
    {
        protected abstract void CreateApplication();
        protected Application()
        {
            CreateApplication();
        }
        public List<Technology> Technologies { get; } = new List<Technology>();
    }

    class AspNetApplication : Application
    {
        protected override void CreateApplication()
        {
            Technologies.Add(new AspNetMvc());
            Technologies.Add(new CSharp());
            Technologies.Add(new SqlServer());
        }
    }

    class JavaApplication : Application
    {
        protected override void CreateApplication()
        {
            Technologies.Add(new Java());
            Technologies.Add(new Hibernate());
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
