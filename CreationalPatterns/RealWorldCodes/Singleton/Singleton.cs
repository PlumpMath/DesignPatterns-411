using System.Threading;

namespace CreationalPatterns.RealWorldCodes.Singleton
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _configManager;
        private ConfigurationManager()
        {
        }
        private static volatile object _syncRoot = new object();
        public static ConfigurationManager GetInstance()
        {
            // для исключения возможности создания двух объектов 
            // при многопоточном приложении(потокобезопасно)
            if (_configManager == null)
            {
                Thread.Sleep(500);
                lock (_syncRoot) // Закомментировать lock для проверки.
                {
                    if (_configManager == null)
                        _configManager = new ConfigurationManager();
                }
            }

            return _configManager;
        }
    }
}
