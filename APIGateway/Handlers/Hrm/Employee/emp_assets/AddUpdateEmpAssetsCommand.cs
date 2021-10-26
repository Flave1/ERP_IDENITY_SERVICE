using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_assets
{
	public class AddUpdate_hrm_emp_assetsCommand : IRequest<hrm_emp_add_update_response>
	{
		public class AddUpdate_hrm_emp_assetsCommandHandler : IRequestHandler<hrm_emp_assets_contract, hrm_emp_add_update_response>
		{
			private readonly DataContext _context;
			private readonly IEmployeeRepository _empRepo;
			private readonly ILoggerService _logger;

			public AddUpdate_hrm_emp_assetsCommandHandler(DataContext context, IEmployeeRepository empRepo, ILoggerService logger)
			{
				_context = context;
				_empRepo = empRepo;
				_logger = logger;
			}

			public async Task<hrm_emp_add_update_response> Handle(hrm_emp_assets_contract request, CancellationToken cancellationToken)
			{
				var response = new hrm_emp_add_update_response();
				try
				{
					var item = _context.hrm_emp_assets.Find(request.Id);
					if (item == null)
						 item = new hrm_emp_assets();
					item.AssetName = request.AssetName;
					item.AssetNumber = request.AssetNumber;
					item.Description = request.Description;
					item.Classification = request.Classification;
					item.PhysicalCondition = request.PhysicalCondition;
					item.LocationId = request.LocationId;
					item.RequestApprovalStatus = request.RequestApprovalStatus;
					item.ReturnApprovalStatus = request.ReturnApprovalStatus;
					item.StaffId = request.StaffId;
					await _empRepo.AddUpdateEmpAssetAsync(item);

					response.Employee_Id = item.Id;
					response.Status.IsSuccessful = true;
					response.Status.Message.FriendlyMessage = "Record saved successfully";
					return response;

				}
				catch (Exception e)
				{
					#region Log error to file 
					response.Status.Message.FriendlyMessage = "Error Occurred !! Please contact help desk";
					response.Status.Message.TechnicalMessage = e.ToString();
					_logger.Error(e.ToString());
					return response;
					#endregion
				}
			}
		}
	}
}
