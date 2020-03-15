using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetry.API.Models
{
    public interface IDatabaseConfigurationSettings
    {
        public string ProjectCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public class DatabaseConfigurationSettings : IDatabaseConfigurationSettings
    {
        public string ProjectCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
