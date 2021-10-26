using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GODP.APIsContinuation.Repository.Interface.Admin;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_gym
{
    public class GetAllEmp_Gym_Meeting_Query : IRequest<hrm_emp_gym_meeting_contract_resp>
    {
        public class GetAllEmp_Gym_Meeting_QueryHandler : IRequestHandler<GetAllEmp_Gym_Meeting_Query, hrm_emp_gym_meeting_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setup;
            private readonly IAdminRepository _adminRepo;

            public GetAllEmp_Gym_Meeting_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setup, IAdminRepository adminRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setup = setup;
                _adminRepo = adminRepo;
            }

            public async Task<hrm_emp_gym_meeting_contract_resp> Handle(GetAllEmp_Gym_Meeting_Query request, CancellationToken cancellationToken)
            {

                var response = new hrm_emp_gym_meeting_contract_resp { employeeList = new List<hrm_emp_gym_meeting_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpGymMeetingAsync();
                var gymList = await _setup.GetAllGymWorkoutAsync();
                var staffList = await _adminRepo.GetAllStaffAsync();
                response.employeeList = emp_List.Select(x => new hrm_emp_gym_meeting_contract
                {
                    Id = x.Id,
                    GymId = x.GymId,
                    GymName = gymList.FirstOrDefault(m => m.Id == x.GymId).Gym,
                    GymEmail = gymList.FirstOrDefault(m => m.Id == x.GymId).Email,
                    DateOfRequest = x.DateOfRequest,
                    ProposedMeetingDate = x.ProposedMeetingDate,
                    ReasonsForMeeting = x.ReasonsForMeeting,
                    StaffId = x.StaffId,
                    StaffCode = staffList.FirstOrDefault(m => m.StaffId == x.StaffId).StaffCode
                }).ToList();

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
