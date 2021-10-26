using APIGateway.Data;

using GOSLibraries.GOS_Error_logger.Service;
using GODP.APIsContinuation.Repository.Interface;
using GODP.APIsContinuation.Repository.Interface.Setup.Company.CompanyStructure;
using GODPAPIs.Contracts.Commands.Company;
using GODPAPIs.Contracts.RequestResponse;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GODP.APIsContinuation.Handlers.Ccompany
{
    public class DeleteCompanyStructureDefinitionCommandHandler : IRequestHandler<DeleteCompanyStructureDefinitionCommand, DeleteRespObj>
    {

        private readonly ICompanyRepository _repo;
        private readonly ILoggerService _logger;
        public DeleteCompanyStructureDefinitionCommandHandler(ICompanyRepository repository, ILoggerService loggerService)
        {
            _repo = repository;
            _logger = loggerService;
        }
        public async Task<DeleteRespObj> Handle(DeleteCompanyStructureDefinitionCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteRespObj { Status = new APIResponseStatus { Message = new APIResponseMessage() } };
            if (request.StructureDefinitionIds.Count() > 0)
            {
                foreach (var itemId in request.StructureDefinitionIds)
                {
                    await _repo.DeleteCompanyStructureDefinitionAsync(itemId);
                }
            }
            response.Status.IsSuccessful = true;
            response.Deleted = true;
            response.Status.Message.FriendlyMessage = "Successful";
            return response;
        }
    }
} 
