using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetry.API.Models;

namespace Telemetry.API.Service
{
    public class MongoDB
    {
        private readonly MongoClient _client;

        public MongoDB(DatabaseConfigurationSettings settings)
        {
            _client = new MongoClient(settings.ConnectionString);
      
        }
    }
}
