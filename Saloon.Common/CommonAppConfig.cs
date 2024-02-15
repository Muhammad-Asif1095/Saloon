using Microsoft.Extensions.Configuration;

namespace Saloon.Common
{
    public static class CommonAppConfig
    {

        public static IConfiguration configuration { get; set; }

        public static string GetConnectionString(string ConnectionStringName)
        {
            return configuration.GetConnectionString(ConnectionStringName);
        }

        public static string GetKey(string Key)
        {
            return configuration.GetSection(Key).Value;
        }
    }
}
