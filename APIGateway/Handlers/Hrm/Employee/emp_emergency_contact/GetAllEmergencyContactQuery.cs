using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Common;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_emergency_contact
{
    public class GetAllEmp_Emergency_Contact_Query : IRequest<hrm_emp_emergency_contact_contract_resp>
    {
        public class GetAllEmp_Emergency_Contact_QueryHandler : IRequestHandler<GetAllEmp_Emergency_Contact_Query, hrm_emp_emergency_contact_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ICommonRepository _commonRepository;

            public GetAllEmp_Emergency_Contact_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ICommonRepository commonRepository)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _commonRepository = commonRepository;
            }

            public async Task<hrm_emp_emergency_contact_contract_resp> Handle(GetAllEmp_Emergency_Contact_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_emergency_contact_contract_resp { employeeList = new List<hrm_emp_emergency_contact_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpEmergencyContactAsync();
                var countryList = await _commonRepository.GetAllCountryAsync();
               
                response.employeeList = emp_List.Select(x => new hrm_emp_emergency_contact_contract
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Contact_phone_number = x.Contact_phone_number,
                    Email = x.Email,
                    Relationship = x.Relationship,
                    Address = x.Address,
                    CountryId = x.CountryId,
                    CountryName = countryList.FirstOrDefault(m => m.CountryId == x.CountryId)?.CountryName,
                    Approval_status = x.Approval_status,
                    Approval_status_name = (x.Approval_status == 1) ? "Approved" : (x.Approval_status == 2) ? "Pending" : (x.Approval_status == 3) ? "Declined" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;

            }
        }
    }
}
