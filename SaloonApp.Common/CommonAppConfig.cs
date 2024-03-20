using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SaloonApp.Common
{
    public static class CommonAppConfig
    {
        private static IConfigurationRoot GetConfig()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true);

            return builder.Build();
        }

        public static string GetConnectionString(string ConnectionStringName)
        {
            return Environment.GetEnvironmentVariable(ConnectionStringName);
        }

        public static string GetKey(string Key)
        {
            return GetConfig().GetSection(Key).Value;
        }
    }
}
