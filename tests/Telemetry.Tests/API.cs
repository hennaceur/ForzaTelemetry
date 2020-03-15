using System;
using System.Net.Http;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Telemetry.API;

namespace Telemetry.Tests
{
    public class API: IClassFixture<WebApplicationFactory<Startup>>
    {  
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
    }
}
