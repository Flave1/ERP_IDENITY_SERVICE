using APIGateway.AcceptanceTest.Test_endpints.V1;
using APIGateway.AcceptanceTest.Test_models.Common_models; 
using System.Net.Http; 
using System.Threading.Tasks;

namespace APIGateway.AcceptanceTest.Broker
{
    public partial class Identity_server_api_broker
    {
        public async Task<LookUpRegRespObj> Add_job_title_async(Title request)
        {
            var response = await this.baseClient.PostAsJsonAsync(Test_endpont_routes.CommonEnpoint.ADD_UPDATE_JOB_TITLE, request);
            return await response.Content.ReadAsAsync<LookUpRegRespObj>();
        }
        
        public async Task<CommonLookupRespObj> Get_single_Job_titles_async(int Id)
        {
           var response = await this.baseClient.GetAsync($"{Test_endpont_routes.CommonEnpoint.GET_JOB_TITLE}/{Id}");
            return await response.Content.ReadAsAsync<CommonLookupRespObj>();
        }

        public async Task<CommonLookupRespObj> Get_all_Job_titles_async()
        {
            var response = await this.baseClient.GetAsync($"{Test_endpont_routes.CommonEnpoint.JOB_TITLE}");
            return await response.Content.ReadAsAsync<CommonLookupRespObj>();
        }

        public async Task<DeleteRespObj> Delete_Job_titles_async(int Id)
        {
            var response = await this.baseClient.DeleteAsync($"{Test_endpont_routes.CommonEnpoint.DELETE_JOB_TITLE}/{Id}");
            return await response.Content.ReadAsAsync<DeleteRespObj>();
        } 
    }
}
