using System.IO;

namespace AionShardLauncher.infra.loader
{
    public class PropertiesLoader
    {
        private string _resourceName;
        
        public PropertiesLoader()
        {
            _resourceName = "config.txt";
        }
        
        public string Content()
        {
            using (StreamReader reader = new StreamReader(_resourceName))
            {
                return reader.ReadToEnd();
            }
        }
    }
}