using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemetry.API.Models;
using MongoDB.Bson;

namespace Telemetry.API.Service
{
    public class MongoService
    {
        private readonly MongoClient _client;
        private IMongoDatabase database { get; set; }
        public readonly IMongoCollection<TelemetryModels> _collection;

        public MongoService(IDatabaseConfigurationSettings settings)
        {
             //Creates MongoDB Client
            _client = new MongoClient(settings.ConnectionString);
            //Gets specified database name 
            database = _client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TelemetryModels>(settings.CollectionName);

        }

        public List<TelemetryModels> Get() => _collection.Find(model => true).ToList();
        public TelemetryModels Get(ObjectId id) => _collection.Find(model => model.Id == id).FirstOrDefault();
    }
}
