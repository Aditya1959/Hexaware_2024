using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace ProjectManagementApp.util
{
    public static class DBPropertyUtil
    {
        private static IConfigurationRoot configuration;

        static DBPropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
