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
        private IMongoDatabase database { get; set; }
        public readonly IMongoCollection<TelemetryModels> _collection;

        public MongoDB(IDatabaseConfigurationSettings settings)
        {
             //Creates MongoDB Client
            _client = new MongoClient(settings.ConnectionString);
            //Gets specified database name 
            database = _client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TelemetryModels>(settings.CollectionName);
            
        }

        public List<TelemetryModels> Get() => _collection.Find(model => true).ToList();
        public TelemetryModels Get(string id) => _collection.Find<Telemetry.API.Models.TelemetryModels>(model => model.Id == id).FirstOrDefault();
    }
}
