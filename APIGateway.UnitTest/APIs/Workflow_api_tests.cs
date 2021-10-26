using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Common_models;
using APIGateway.Contracts.Commands.Workflow;
using FluentAssertions; 
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;

namespace APIGateway.AcceptanceTest.APIs
{ 
    namespace APIGateway.AcceptanceTest.APIs
    {
        [Collection(nameof(Api_test_collection))]
        public class Workflow_api_tests
        {
            private readonly Identity_server_api_broker _identity_Server_Api_Broker;
            public Workflow_api_tests(Identity_server_api_broker identity_Server_Api_Broker) =>
                this._identity_Server_Api_Broker = identity_Server_Api_Broker;

            private AddUpdateWorkflowCommand Create_Workflow() => new Filler<AddUpdateWorkflowCommand>().Create();

            [Fact]
            public async Task Should_create_and_validate_workflow()
            {
                //given 
                await _identity_Server_Api_Broker.Authenticate_async();
                AddUpdateWorkflowCommand random_data = Create_Workflow();
                random_data.OperationId = 0; 

                //when 
                var created_reponse = await _identity_Server_Api_Broker.Add_workflow_async(random_data); 

                //then 

                created_reponse.Status.Should().Equals(null);

            }

           

        }
    }

}
