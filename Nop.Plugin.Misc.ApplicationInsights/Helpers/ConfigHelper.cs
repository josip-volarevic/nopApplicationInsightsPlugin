using System.IO;
using Microsoft.Extensions.Configuration;
using Nop.Plugin.Misc.ApplicationInsights.Infrastructure;

namespace Nop.Plugin.Misc.ApplicationInsights.Helpers
{
    static class ConfigHelper
    {
        public static string GetConfigDirectory()
        {
            string assemblyPath = System.Reflection.Assembly.GetAssembly(typeof(PluginStartup)).Location;
            string pluginPath = Path.Combine(assemblyPath, @"..\..\Misc.ApplicationInsights");
            return Path.GetFullPath(pluginPath);
        }
        public static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(GetConfigDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
