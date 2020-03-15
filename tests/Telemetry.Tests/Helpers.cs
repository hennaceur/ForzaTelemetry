using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Telemetry.API.Models;

namespace Telemetry.Tests
{
    public static class Helpers
    {
        public static IDatabaseConfigurationSettings LoadConfiguration()
        {
            IDatabaseConfigurationSettings config;

            // Create instance for config
            config = new DatabaseConfigurationSettings();
            var configRoot = new ConfigurationBuilder()
               .AddEnvironmentVariables()
               .AddJsonFile(@"C:\Users\Hazem\Desktop\repos\ForzaTelemetry\tests\Telemetry.Tests\IntegrationTestsDeployment.json", false).Build();

            // Assign values into IDatabaseConfigurtionSettings
            config.ConnectionString = configRoot["ConnectionString"];
            config.DatabaseName = configRoot["DatabaseName"];
            config.CollectionName = configRoot["CollectionName"];

            return config;
        }
    }
}
