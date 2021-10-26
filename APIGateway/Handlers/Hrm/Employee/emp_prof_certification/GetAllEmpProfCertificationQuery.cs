﻿using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Hrm_Employee;
using APIGateway.Repository.Interface.Setup;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.emp_prof_certification
{
    public class GetAllEmp_Prof_Certification_Query : IRequest<hrm_emp_prof_certification_contract_resp>
    {
        public class GetAllEmp_Prof_Certification_QueryHandler : IRequestHandler<GetAllEmp_Prof_Certification_Query, hrm_emp_prof_certification_contract_resp>
        {
            private readonly DataContext _dataContext;
            private readonly IEmployeeRepository _employeeRepo;
            private readonly ISetupRepository _setupRepo;

            public GetAllEmp_Prof_Certification_QueryHandler(DataContext datacontext, IEmployeeRepository employeeRepo, ISetupRepository setupRepo)
            {
                _dataContext = datacontext;
                _employeeRepo = employeeRepo;
                _setupRepo = setupRepo;
            }

            public async Task<hrm_emp_prof_certification_contract_resp> Handle(GetAllEmp_Prof_Certification_Query request, CancellationToken cancellationToken)
            {
                var response = new hrm_emp_prof_certification_contract_resp { employeeList = new List<hrm_emp_prof_certification_contract>(), Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                var emp_List = await _employeeRepo.GetAllEmpProfCertificationAsync();
                var certificateList = await _setupRepo.GetAllProfCertificationsAsync();

                response.employeeList = emp_List.Select(x => new hrm_emp_prof_certification_contract
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

                response.Status.Message.FriendlyMessage = emp_List.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                return response;

            }
        }
    }
}
