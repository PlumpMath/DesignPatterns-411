using System.Threading;

namespace CreationalPatterns.RealWorldCodes.Singleton
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _configManager;
        private ConfigurationManager()
        {
        }
        private static readonly object SyncRoot = new object();
        public static ConfigurationManager GetInstance()
        {
            // для исключения возможности создания двух объектов 
            // при многопоточном приложении(потокобезопасно)
            if (_configManager == null)
            {
                Thread.Sleep(500);
                lock (SyncRoot) // Закомментировать lock для проверки.
                {
                    if (_configManager == null)
                        _configManager = new ConfigurationManager();
                }
            }

            return _configManager;
        }
    }
}
