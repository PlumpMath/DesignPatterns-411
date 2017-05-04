using System.Threading;

namespace CreationalPatterns.RealWorldCodes
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
            //Thread-safe
            if (_configManager == null)
            {
                Thread.Sleep(500);
                lock (SyncRoot) // Comment out lock for check.
                {
                    if (_configManager == null)
                        _configManager = new ConfigurationManager();
                }
            }

            return _configManager;
        }
    }
}
