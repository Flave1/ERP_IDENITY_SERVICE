using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Common;
using APIGateway.Repository.Interface.Hrm_Employee;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_emergency_contact
{
    public class GetSingleEmpEmergencyContactByStaffId_Query : IRequest<hrm_emp_emergency_contact_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpEmergencyContactByStaffId_QueryHandler : IRequestHandler<GetSingleEmpEmergencyContactByStaffId_Query, hrm_emp_emergency_contact_contract_resp>
        {
            private readonly DataContext _data;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ICommonRepository _commonRepository;

            public GetSingleEmpEmergencyContactByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ICommonRepository commonRepository)
            {
                _data = data;
                _employeeRepo = employeeRepo;
                _commonRepository = commonRepository;
            }

            public async Task<hrm_emp_emergency_contact_contract_resp> Handle(GetSingleEmpEmergencyContactByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_emergency_contact_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_emergency_contact.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                var countryList = await _commonRepository.GetAllCountryAsync();
                response.employeeList = list.Select(x => new hrm_emp_emergency_contact_contract
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

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
