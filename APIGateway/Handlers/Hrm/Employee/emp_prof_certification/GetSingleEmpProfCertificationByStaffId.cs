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

namespace APIGateway.Handlers.Hrm.Employee.emp_prof_certification
{
    public class GetSingleEmpProfCertificationByStaffId_Query : IRequest<hrm_emp_prof_certification_contract_resp>
    {
        public int staffId { get; set; }
        public class GetSingleEmpProfCertificationByStaffId_QueryHandler : IRequestHandler<GetSingleEmpProfCertificationByStaffId_Query, hrm_emp_prof_certification_contract_resp>
        {
            private readonly DataContext _data;
            private readonly ISetupRepository _setupRepo;

            public GetSingleEmpProfCertificationByStaffId_QueryHandler(
                DataContext data, IEmployeeRepository employeeRepo, ISetupRepository setupRepo)
            {
                _data = data;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_emp_prof_certification_contract_resp> Handle(GetSingleEmpProfCertificationByStaffId_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_prof_certification_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var list = await _data.hrm_emp_prof_certification.Where(e => e.StaffId == request.staffId && e.Deleted == false).ToListAsync();
                var certificateList = await _setupRepo.GetAllProfCertificationsAsync();

                response.employeeList = list.Select(x => new hrm_emp_prof_certification_contract
                {
                    Id = x.Id,
                    CertificationId = x.CertificationId,
                    CertificateName = certificateList.FirstOrDefault(m => m.Id == x.CertificationId)?.Certification,
                    Institution = x.Institution,
                    DateGranted = x.DateGranted,
                    ExpiryDate = x.ExpiryDate,
                    GradeId = x.GradeId,
                    Attachment = x.Attachment,
                    ApprovalStatus = x.ApprovalStatus,
                    ApprovalStatusName = (x.ApprovalStatus == 1) ? "Approved" : (x.ApprovalStatus == 2) ? "Pending" : (x.ApprovalStatus == 3) ? "Declined" : null,
                    StaffId = x.StaffId
                }).ToList();

                response.Status.Message.FriendlyMessage = list.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;
            }
        }
    }
}
