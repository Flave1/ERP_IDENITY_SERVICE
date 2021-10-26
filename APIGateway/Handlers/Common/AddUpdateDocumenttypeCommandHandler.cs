using APIGateway.Contracts.Commands.Common;
using APIGateway.Contracts.Response.Common;
using APIGateway.Data;
using APIGateway.DomainObjects.Credit;
using APIGateway.Repository.Interface.Common;
using GODPCloud.Helpers.Extensions;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Common
{
    public class AddUpdateDocumenttypeCommandHandler : IRequestHandler<AddUpdateDocumenttypeCommand, LookUpRegRespObj>
    {
        private readonly ICommonRepository _repo;
        private readonly DataContext _dataContext;
        public AddUpdateDocumenttypeCommandHandler(ICommonRepository commonRepository, DataContext dataContext)
        {
            _dataContext = dataContext;
            _repo = commonRepository;
        }
        public async Task<LookUpRegRespObj> Handle(AddUpdateDocumenttypeCommand request, CancellationToken cancellationToken)
        {
            var response = new LookUpRegRespObj { Status = new APIResponseStatus { Message = new APIResponseMessage() } };
            try
            {
                var item = _dataContext.credit_documenttype.Find(request.DocumentTypeId);
                if (item == null)
                {
                    if (await _dataContext.credit_documenttype.AnyAsync(x => x.Name.Trim().ToLower() == request.Name.Trim().ToLower() && x.Deleted == false))
                    {
                        response.Status.IsSuccessful = false;
                        response.Status.Message.FriendlyMessage = "This Name Already Exist";
                        return response;
                        //return new LookUpRegRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "This Name Already Exist" } } };
                    }
                    if (_dataContext.credit_documenttype.Any(e => e.Doc_identifier == (int)Doc_identifier.Signature && request.Document_identifier == (int)Doc_identifier.Signature))
                    {
                        response.Status.IsSuccessful = false;
                        response.Status.Message.FriendlyMessage = "Document of type signature already added";
                        return response;
                    }
                    item = new credit_documenttype(); 
                }

                item.Name = request.Name;
                item.Doc_identifier = request.Document_identifier;

                await _repo.AddUpdateDocumentTypeAsync(item);
                response.Status.IsSuccessful = true;
                response.Status.Message.FriendlyMessage = "Successful";
                return response;
            }
            catch (Exception ex)
            {
                #region Log error to file 
                return new LookUpRegRespObj
                {

                    Status = new APIResponseStatus
                    {
                        IsSuccessful = false,
                        Message = new APIResponseMessage
                        {
                            FriendlyMessage = "Error occured!! Unable to process request",
                            TechnicalMessage = $"{ex?.Message ?? ex?.InnerException?.Message} ErrorStack : {ex?.StackTrace}"
                        }
                    }
                };
                #endregion
            }
        }
    }
}
