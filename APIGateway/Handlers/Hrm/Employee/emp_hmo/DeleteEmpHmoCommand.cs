using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using GODPAPIs.Contracts.RequestResponse;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_hmo
{
    public class DeleteEmp_HmoCommand : IRequest<DeleteRespObj>
    {
        public List<int> ItemIds { get; set; }
        public class DeleteEmp_HmoCommandHandler : IRequestHandler<DeleteEmp_HmoCommand, DeleteRespObj>
        {
            private readonly ILoggerService _logger;
            private readonly DataContext _data;
            private readonly IEmployeeRepository _empRepo;
            public DeleteEmp_HmoCommandHandler(ILoggerService loggerService, DataContext data, IEmployeeRepository empRepo)
            {
                _logger = loggerService;
                _data = data;
                _empRepo = empRepo;
            }

            public async Task<DeleteRespObj> Handle(DeleteEmp_HmoCommand request, CancellationToken cancellationToken)
            {
                var response = new DeleteRespObj { Deleted = false, Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                try
                {
                    if (request.ItemIds.Count() > 0)
                    {
                        foreach (var itemId in request.ItemIds)
                        {
                            await _empRepo.DeleteEmpHmoAsync(itemId);
                        }
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
