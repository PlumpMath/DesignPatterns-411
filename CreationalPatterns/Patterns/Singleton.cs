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
