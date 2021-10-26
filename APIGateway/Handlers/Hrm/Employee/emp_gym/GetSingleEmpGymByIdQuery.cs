using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_gym
{
    public class GetSingleEmpGym_Query : IRequest<hrm_emp_gym_contract_resp>
    {
        public int EmpId { get; set; }
        public class GetSingleEmpGym_QueryHandler : IRequestHandler<GetSingleEmpGym_Query, hrm_emp_gym_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;

            public GetSingleEmpGym_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setup)
            {
                _data = data;
                _employeeRepo = employeeRepo;
                _setup = setup;
            }

            public async Task<hrm_emp_gym_contract_resp> Handle(GetSingleEmpGym_Query request, CancellationToken cancellationToken)
            {

                var response = new hrm_emp_gym_contract_resp { employeeList = new List<hrm_emp_gym_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _data.hrm_emp_gym.Where(e => e.Id == request.EmpId && e.Deleted == false).ToListAsync();
                var gymList = await _setup.GetAllGymWorkoutAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_gym_contract
                {

                    Id = x.Id,
                    GymId = x.GymId,
                    GymName = gymList.FirstOrDefault(m => m.Id == x.GymId).Gym,
                    GymRating = x.GymRating,
                    GymContactPhoneNo = gymList.FirstOrDefault(m => m.Id == x.GymId).Contact_phone_number,
                    StartDate = x.StartDate,
                    End_Date = x.End_Date,
                    ApprovalStatus = x.ApprovalStatus,
                    ApprovalStatusName = (x.ApprovalStatus == 1) ? "Confirmed" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Unconfirmed" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
