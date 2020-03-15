using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemetry.API.Service
{
    public class MongoDB
    {
        public MongoDB()
        {
            MongoClient dbClient = new MongoClient();

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}
