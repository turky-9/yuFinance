using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.Configuration;


namespace yuFinanceGUI
{
    public class UtlConfig
    {
        public static bool IsDev = false;
        public static readonly string BasePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private static IConfigurationRoot Configuration = null;

        public static string GetSetting(string name)
        {
            if (Configuration == null)
            {
                var environmentName = Environment.GetEnvironmentVariable("YU_ENVIRONMENT");

                var builder = new ConfigurationBuilder()
                .SetBasePath(BasePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true, true);

                if(IsDev && environmentName != "development")
                {
                    builder = builder.AddJsonFile($"appsettings.development.json", true, true);
                }

                Configuration = builder.Build();
            }

            return Configuration[name];
        }

    }
}
