using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Repository.Interface.Setup;
using GODP.APIsContinuation.DomainObjects.UserAccount;
using GOSLibraries.GOS_API_Response;
using GOSLibraries.GOS_Error_logger.Service;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.Employee.hrm_staff
{
    public class GetSingleHrmStaffByIdQuery : IRequest<hrm_staff_contract_resp>
    {
        public int StaffId { get; set; }
        public class GetSingleHrmStaffByIdQueryHandler : IRequestHandler<GetSingleHrmStaffByIdQuery, hrm_staff_contract_resp>
        {
            private readonly ILoggerService _logger;
            private readonly DataContext _dataContext;
            private readonly UserManager<cor_useraccount> _userManager;

            public GetSingleHrmStaffByIdQueryHandler(
                DataContext dataContext, ISetupRepository setupRepo, ILoggerService loggerService, UserManager<cor_useraccount> userManager)
            {
                _logger = loggerService;
                _userManager = userManager;
                _dataContext = dataContext;
            }
            private List<string> GetAllRoleIds(string userId)
            {
                return _dataContext?.UserRoles?.Where(s => s.UserId == userId)?.Select(c => c.RoleId)?.ToList();
            }
            private List<int> GetAccessLevels(int staffId)
            {
                var userAccessList = _dataContext.cor_useraccess.Where(d => d.Deleted == false).ToList();

                var user = _userManager.Users.FirstOrDefault(d => d.StaffId == staffId);
                if (user != null)
                {
                    return userAccessList.Where(x => x.UserId == user.Id).Select(g => g.AccessLevelId).Distinct().ToList();
                }
                return new List<int>();
            }
            private List<string> GetAllRoleNames(IList<string> roleIds)
            {
                return _dataContext.Roles.Where(s => roleIds.Contains(s.Id)).Select(c => c.Name).ToList();
            }
            public async Task<hrm_staff_contract_resp> Handle(GetSingleHrmStaffByIdQuery request, CancellationToken cancellationToken)
            {
                var response = new hrm_staff_contract_resp { Status = new APIResponseStatus { IsSuccessful = true, Message = new APIResponseMessage() } };
                try
                {
                    var JobTItleList = _dataContext.hrm_setup_jobtitle.Where(x => x.Deleted == false).ToList();
                    var JobGradeList = _dataContext.hrm_setup_jobgrade.Where(x => x.Deleted == false).ToList();
                    //var companystructureList = _dataContext.cor_companystructure.Where(c => c.Deleted == false).ToList();
                    var respList = new List<hrm_staff_contract_objects>();
                    var staff = await _dataContext.hrm_staffs.FirstOrDefaultAsync(c => c.StaffId == request.StaffId);
                    if (staff != null)
                    {
                        var userDetail = await _dataContext.Users.FirstOrDefaultAsync(f => f.StaffId == request.StaffId);
                        if (userDetail != null)
                        {

                            if (staff != null)
                            {
                                var item = new hrm_staff_contract_objects();
                                item.FirstName = staff.FirstName;
                                item.AccessLevel = staff.AccessLevel;
                                item.Email = staff.Email;
                                item.Gender = staff.Gender;
                                item.JobTitle = staff.JobTitle;
                                item.JobTitleName = JobTItleList?.FirstOrDefault(m => m.Id == staff.JobTitle)?.Job_title;
                                item.JobGradeName = JobGradeList.FirstOrDefault(m => m.Id == staff.JobGrade)?.Job_grade;
                                item.ReportingTo = JobGradeList.FirstOrDefault(x => x.Id == item.JobGrade)?.Job_grade_reporting_to;
                                item.LastName = staff.LastName;
                                item.MiddleName = staff.MiddleName;
                                item.PhoneNumber = staff.PhoneNumber;
                                item.Photo = staff.Photo;
                                item.Address = staff.Address;
                                item.CountryId = staff.CountryId;
                                item.StaffCode = staff.StaffCode;
                                item.StaffId = staff.StaffId;
                                item.StateId = staff.StateId;
                                item.StaffLimit = staff.StaffLimit;
                                item.AccessLevelId = (int)staff.AccessLevel;
                                item.DateOfBirth = staff.DateOfBirth;
                                item.StaffOfficeId = staff.StaffOfficeId;
                                item.UserAccessLevels = GetAccessLevels(staff.StaffId);
                                item.UserRoleIds = GetAllRoleIds(userDetail.Id);
                                item.UserName = userDetail.UserName;
                                item.UserId = userDetail.Id;
                                item.UserStatus = userDetail.Active;
                                item.UserRoleNames = GetAllRoleNames(GetAllRoleIds(userDetail.Id));
                                item.UserAccessLevels.Distinct();
                                respList.Add(item);
                            }
                        }


                    }

                    response.Status.Message.FriendlyMessage = respList.Count() > 0 ? string.Empty : "Search Complete!! No record found";
                    response.employeeList = respList;
                    return response;

                }
                catch (Exception ex)
                {
                    #region Log error to file 
                    response.Status.Message.FriendlyMessage = "Error Occurred !! Please contact help desk";
                    response.Status.Message.TechnicalMessage = ex.ToString();
                    _logger.Error(ex.ToString());
                    return response;
                    #endregion
                }
            }
        }
    }
}

