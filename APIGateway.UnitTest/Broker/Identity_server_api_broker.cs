using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using RESTFulSense.Clients;
using System.Net.Http;

namespace APIGateway.AcceptanceTest.Broker
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(x => { x.UseStartup<Startup>().UseTestServer(); });
            return builder;
        }
    }
    public partial class Identity_server_api_broker
{
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly HttpClient baseClient;
        private readonly IRESTFulApiFactoryClient apiFactoryClient;

        public Identity_server_api_broker()
        { 
            _factory = new CustomWebApplicationFactory<Startup>();
            baseClient = _factory.CreateClient(); 
            apiFactoryClient = new RESTFulApiFactoryClient(baseClient); 
        } 
    }
}
    