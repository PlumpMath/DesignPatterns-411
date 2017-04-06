namespace Singleton.RealWorldCode
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
                lock (SyncRoot)
                {
                    if (_configManager == null)
                        _configManager = new ConfigurationManager();
                }
            }

            return _configManager;
        }
    }
}
