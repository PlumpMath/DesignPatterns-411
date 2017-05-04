using System;

/*
 * Proxy provides a surrogate or placeholder for another object to control access to it.
 */

namespace StructuralPatterns.Patterns
{
    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }

    class Proxy : Subject
    {
        private RealSubject _realSubject;

        public override void Request()
        {
            // Use 'lazy initialization'
            if (_realSubject == null)
                _realSubject = new RealSubject();

            _realSubject.Request();
        }
    }
}
