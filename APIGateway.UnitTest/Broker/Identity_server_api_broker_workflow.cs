using APIGateway.AcceptanceTest.Test_endpints.V1;
using APIGateway.AcceptanceTest.Test_models.Common_models;
using APIGateway.Contracts.Commands.Workflow;
using GODPAPIs.Contracts.RequestResponse.Workflow;
using System.Net.Http; 
using System.Threading.Tasks;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Identity_server_api_broker
    {
        public async Task<WorkflowRespObj> Add_workflow_async(AddUpdateWorkflowCommand request)
        {
            var response = await this.baseClient.PostAsJsonAsync(Test_endpont_routes.WorkdlowEndpoints.ADD_UPDATE_WORKFLOW, request);
            return await response.Content.ReadAsAsync<WorkflowRespObj>();
        }
         
        public async Task<DeleteRespObj> Delete_workflow_async(int Id)
        {
            var response = await this.baseClient.DeleteAsync($"{Test_endpont_routes.WorkdlowEndpoints.DELETE_WORKFLOW}/{Id}");
            return await response.Content.ReadAsAsync<DeleteRespObj>();
        } 
    }
}
