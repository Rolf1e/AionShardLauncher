using System;

namespace AionShardLauncher.infra.loader
{
    public class ParseConfigFile
    {
        public static string GetDefaultPath()
        {
            var path = new PropertiesLoader()
                .Content();
            var indexOf = path.IndexOf("=", StringComparison.Ordinal);
            return path.Substring(indexOf + 1);
        }
    }
}