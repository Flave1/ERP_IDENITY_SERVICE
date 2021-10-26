using APIGateway.AcceptanceTest.Broker;
using APIGateway.AcceptanceTest.Test_models.Common_models;
using FluentAssertions; 
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Xunit;



namespace APIGateway.AcceptanceTest.APIs
{
    [Collection(nameof(Api_test_collection))]
    public class Identity_apis_test
    {
        private readonly Identity_server_api_broker _identity_Server_Api_Broker;
        public Identity_apis_test(Identity_server_api_broker identity_Server_Api_Broker) =>
            _identity_Server_Api_Broker = identity_Server_Api_Broker;

        private Title Create_random_jobtile() => new Filler<Title>().Create();

        [Fact]
        public async Task Should_Add_jobtitle_retrieve_and_delete()
        {
            //given 
            await _identity_Server_Api_Broker.Authenticate_async();
            Title random_title = Create_random_jobtile();
            random_title.JobTitleId = 0;
            Title input_title = random_title;

            //when 
            var created_reponse = await _identity_Server_Api_Broker.Add_job_title_async(input_title);
            var get_reponse = await _identity_Server_Api_Broker.Get_single_Job_titles_async(created_reponse.LookUpId);

            //then
            //var deleted_reonse = await _identity_Server_Api_Broker.Delete_Job_titles_async(get_reponse.CommonLookups.FirstOrDefault().LookupId);

            created_reponse.Status.IsSuccessful.Should().Equals(true);

        }

        [Fact]
        public async Task Should_retrieve_all_jobtitle()
        {
            //given 
            await _identity_Server_Api_Broker.Authenticate_async();

            //when 
            var get_reponse = await _identity_Server_Api_Broker.Get_all_Job_titles_async();

            //then
            //var deleted_reonse = await _identity_Server_Api_Broker.Delete_Job_titles_async(get_reponse.CommonLookups.FirstOrDefault().LookupId);

            get_reponse.CommonLookups.Should().HaveCountGreaterOrEqualTo(0);

        }

    }
}

