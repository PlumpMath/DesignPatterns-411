/*
 * Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует, 
 * что для определенного класса будет создан только один объект, 
 * а также предоставит к этому объекту точку доступа.
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
