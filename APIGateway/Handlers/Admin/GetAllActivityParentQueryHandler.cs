using APIGateway.Contracts.Queries.Admin;
using APIGateway.Contracts.Response.Admin;
using APIGateway.Contracts.V1;
using GODP.APIsContinuation.Repository.Interface.Admin; 
using GODPAPIs.Contracts.Response.Admin;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Admin
{
    public class GetAllActivityParentQueryHandler : IRequestHandler<GetAllActivityParentQuery, ActivityParentRespObj>
    {
        private readonly IAdminRepository _adminRepo;
        private readonly IHttpContextAccessor _httpContext;
        public GetAllActivityParentQueryHandler(IAdminRepository adminRepository, IHttpContextAccessor httpContext)
        {
            _adminRepo = adminRepository;
            _httpContext = httpContext;
        }
        public async Task<ActivityParentRespObj> Handle(GetAllActivityParentQuery request, CancellationToken cancellationToken)
        {
            var response = new ActivityParentRespObj();
            var list = await _adminRepo.GetAllActivityParentsAsync();

            response.ActivityParents = list.Select(x => new ActivityParentObj
            {
                Active = x.Active,
                ActivityParentId = x.ActivityParentId,
                ActivityParentName = x.ActivityParentName,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                Deleted = x.Deleted,
                UpdatedBy = x.UpdatedBy,
                UpdatedOn = x.UpdatedOn
            }).ToList();

            response.Status.IsSuccessful = true;
            response.Status.Message.FriendlyMessage = list.Count() > 0 ? null : "Search Complete! No record found";
            return response;
        }
    }
}
