using APIGateway.Data;
using GODPAPIs.Contracts.RequestResponse;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.sub_skill
{
    public class Deletehrm_setup_sub_skill : IRequest<DeleteRespObj>
    {
        public List<int> ItemIds { get; set; }
        public class Deletehrm_setup_sub_skillHandler : IRequestHandler<Deletehrm_setup_sub_skill, DeleteRespObj>
        {
            private readonly ILoggerService _logger;
            private readonly DataContext _context;
            public Deletehrm_setup_sub_skillHandler(ILoggerService loggerService, DataContext data)
            {
                _logger = loggerService;
                _context = data;
            }

            public async Task<DeleteRespObj> Handle(Deletehrm_setup_sub_skill request, CancellationToken cancellationToken)
            {
                var response = new DeleteRespObj { Deleted = false, Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                try
                {
                    if (request.ItemIds.Count > 0)
                    {
                        foreach (var Id in request.ItemIds)
                        {
                            var selected = await _context.hrm_setup_sub_skill.FindAsync(Id);
                            if (selected != null)
                                _context.hrm_setup_sub_skill.Remove(selected);
                        }
                        await _context.SaveChangesAsync();
                    }
                    response.Deleted = true;
                    response.Status.IsSuccessful = true;
                    response.Status.Message.FriendlyMessage = "Item(s) deleted successful";
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
