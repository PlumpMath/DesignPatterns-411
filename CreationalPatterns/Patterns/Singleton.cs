/*
 * Singleton ensures a class has only one instance and provide a global point of access to it.
 */

namespace CreationalPatterns.Patterns
{
    class Singleton
    {
        private static Singleton _instance;
        private Singleton()
        { }
        public static Singleton Instance()
        {
            return _instance ?? (_instance = new Singleton());
        }
    }
}
