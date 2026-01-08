using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    public class ConfigurationUtil
    {

        private static readonly Lazy<IConfiguration> _configuration =
    new Lazy<IConfiguration>(BuildConfiguration, true);

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static string GetConnectionString(string name)
        {
            return _configuration.Value.GetConnectionString(name)
                   ?? throw new InvalidOperationException(
                       $"Connection string '{name}' not found.");
        }

        public static string GetValue(string key)
        {
            return _configuration.Value[key]
                   ?? throw new InvalidOperationException(
                       $"Configuration key '{key}' not found.");
        }

    }
}
