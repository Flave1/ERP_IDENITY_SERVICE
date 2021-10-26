using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Common;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.location
{
    public class GetAllSetup_Location_Query : IRequest<hrm_setup_location_contract_resp>
    {
        public class GetAllSetup_Location_QueryHandler : IRequestHandler<GetAllSetup_Location_Query, hrm_setup_location_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly ISetupRepository _setup;
            private readonly ICommonRepository _commonRepository;

            public GetAllSetup_Location_QueryHandler(DataContext datacontext, ISetupRepository setup, ICommonRepository commonRepository)
            {
                _dataContext = datacontext;
                _setup = setup;
                _commonRepository = commonRepository;
            }

            public async Task<hrm_setup_location_contract_resp> Handle(GetAllSetup_Location_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_setup_location_contract_resp { Setuplist = new List<hrm_setup_location_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
               
                var locationList = await _setup.GetAllLocationsAsync();
                var countryList = await _commonRepository.GetAllCountryAsync();
                var stateList = await _commonRepository.GetAllStateAsync();
                response.Setuplist = locationList.Select(x => new hrm_setup_location_contract
                {
                    Id = x.Id,
                    Location = x.Location,
                    Address = x.Address,
                    City = x.City,
                    StateId = x.StateId,
                    StateName = stateList.FirstOrDefault(m => m.StateId == x.StateId)?.StateName,
                    CountryId = x.CountryId,
                    CountryName = countryList.FirstOrDefault(m => m.CountryId == x.CountryId)?.CountryName,
                    AdditionalInformation = x.AdditionalInformation

                }).ToList();

                response.Status.Message.FriendlyMessage = locationList.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
