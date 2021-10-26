using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Common;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.location
{
    public class GetSingleSetupLocation_Query : IRequest<hrm_setup_location_contract_resp>
    {
        public int setupId { get; set; }
        public class GetSingleSetupLocation_QueryHandler : IRequestHandler<GetSingleSetupLocation_Query, hrm_setup_location_contract_resp>
        {
            private readonly DataContext _data;
            private readonly ISetupRepository _setup;
            private readonly ICommonRepository _commonRepository;

            public GetSingleSetupLocation_QueryHandler(
                DataContext data, ISetupRepository setup, ICommonRepository commonRepository)
            {
                _data = data;
                _setup = setup;
                _commonRepository = commonRepository;
            }

            public async Task<hrm_setup_location_contract_resp> Handle(GetSingleSetupLocation_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_setup_location_contract_resp { Setuplist = new List<hrm_setup_location_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var setup_List = await _data.hrm_setup_location.Where(e => e.Id == request.setupId).ToListAsync();
                var countryList = await _commonRepository.GetAllCountryAsync();
                var stateList = await _commonRepository.GetAllStateAsync();
                response.Setuplist = setup_List.Select(x => new hrm_setup_location_contract
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

                response.Status.Message.FriendlyMessage = setup_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
