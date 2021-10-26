using Xunit;

namespace APIGateway.AcceptanceTest.Broker
{
    [CollectionDefinition(nameof(Api_test_collection))]
    public class Api_test_collection : ICollectionFixture<Identity_server_api_broker> { }
}
 