using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> SConfiguration;
        private static IConfiguration Configuration => SConfiguration.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        public static string Username => Configuration[nameof(Username)];
        public static string Password => Configuration[nameof(Password)];
        public static string NotAdminUsername => Configuration[nameof(NotAdminUsername)];
        public static string NotAdminPassword => Configuration[nameof(NotAdminPassword)];

        static Configurator()
        {
            SConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}