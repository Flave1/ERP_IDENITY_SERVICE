using APIGateway.Data;
using GODPAPIs.Contracts.RequestResponse;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.proffesional_membership
{
    public class Deletehrm_setup_proffesional_membership : IRequest<DeleteRespObj>
    {
        public List<int> ItemIds { get; set; }
        public class Deletehrm_setup_proffesional_membershipHandler : IRequestHandler<Deletehrm_setup_proffesional_membership, DeleteRespObj>
        {
            private readonly ILoggerService _logger;
            private readonly DataContext _data;
            public Deletehrm_setup_proffesional_membershipHandler(
                ILoggerService loggerService,
                DataContext data)
            {
                _logger = loggerService;
                _data = data;
            }
            public async Task<DeleteRespObj> Handle(Deletehrm_setup_proffesional_membership request, CancellationToken cancellationToken)
            {
                var response = new DeleteRespObj { Deleted = false, Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                try
                {
                    if (request.ItemIds.Count > 0)
                    {
                        foreach (var Id in request.ItemIds)
                        {
                            var selected = await _data.hrm_setup_proffesional_membership.FindAsync(Id);
                            if (selected != null)
                                _data.hrm_setup_proffesional_membership.Remove(selected);
                        }
                        await _data.SaveChangesAsync();
                    }
                    response.Deleted = true;
                    response.Status.IsSuccessful = true;
                    response.Status.Message.FriendlyMessage = "Item(s) deleted successfully";
                    return response;
                }
                catch (Exception ex)
                {
                    #region Log error to file 
                    var errorCode = ErrorID.Generate(4);
                    _logger.Error($"ErrorID : {errorCode} Ex : {ex?.Message ?? ex?.InnerException?.Message} ErrorStack : {ex?.StackTrace}");
                    response.Status.Message.FriendlyMessage = "Error occured!! Unable to delete item, please contact help desk";
                    response.Status.Message.TechnicalMessage = ex.ToString();
                    return response;
                    #endregion
                }
            }
        }
    }

}
