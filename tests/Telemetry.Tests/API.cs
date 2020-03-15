using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Telemetry.API;
using System.Threading.Tasks;
using Telemetry.API.Models;
using Telemetry.API.Service;
using MongoDB.Bson;

namespace Telemetry.Tests
{
    public class API: IClassFixture<WebApplicationFactory<Startup>>
    {
        private IDatabaseConfigurationSettings _config;
        /// <summary>
        /// Internal webAPI factory reference
        /// </summary>
        private readonly WebApplicationFactory<Startup> _factory;
        /// <summary>
        /// Constructor passes the web factory from the text fixture inwards
        /// </summary>
        /// <param name="factory"></param>
        public API(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public void CreateConfiguration()
        {
            _config = Helpers.LoadConfiguration();
            var db = new MongoService(_config);
        }

        [Fact]
        public async void APIController_WhenHealthEndPointCalled_ShouldReturnHealthy()
        {
            //var client = new HttpClient();  
            var client = _factory.CreateClient();   //Create the web client
            var response = await client.GetAsync("/health"); //Executes HealthCheck endpoint

            Assert.True(response.IsSuccessStatusCode);  //Asserts successful http response

            string responseString = await response.Content.ReadAsStringAsync(); //Read content as string
            Assert.Equal("Healthy", responseString);    //Assert string response is `Healthy`
        }

        [Fact]
        public void MongoDB_WhenRequestingCollectionList_ShouldReturnListWithAllCollections()
        {
            
            CreateConfiguration();
            MongoService db = new MongoService(_config);

            var result = db.Get(ObjectId.Parse("573a1390f29313caabcd4135"));

            Assert.Equal("Three men hammer on an anvil and pass a bottle of beer around.", result.plot);
        }
    }
}
