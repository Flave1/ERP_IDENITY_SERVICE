using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIGateway.Contracts.Response.HRM
{
    public class hrm_emp_add_update_response
    {
        public hrm_emp_add_update_response()
        {
            Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() };
        }
        public int Employee_Id { get; set; }
        public APIResponseStatus Status { get; set; }

    }
    public class hrm_emp_identification_contract_resp
    {
        public hrm_emp_identification_contract_resp()
        {
            employeeList = new List<hrm_emp_Identification_contract>();
        }

        public List<hrm_emp_Identification_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }

    public class hrm_emp_Identification_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string Identification_number { get; set; }
        public string IdIssues { get; set; }
        public DateTime? IdExpiry_date { get; set; }
        public string IdentificationFilePath { get; set; }
        public int Approval_status { get; set; }
        public string Approval_status_name { get; set; }
        public int StaffId { get; set; }
        public IFormFile IdenticationFile { get; set; }

    }
    public class hrm_emp_emergency_contact_contract_resp
    {
        public hrm_emp_emergency_contact_contract_resp()
        {
            employeeList = new List<hrm_emp_emergency_contact_contract>();
        }

        public List<hrm_emp_emergency_contact_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_emergency_contact_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contact_phone_number { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int Approval_status { get; set; }
        public string Approval_status_name { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_dependent_contact_contract_resp
    {
        public hrm_emp_dependent_contact_contract_resp()
        {
            employeeList = new List<hrm_emp_dependent_contact_contract>();
        }

        public List<hrm_emp_dependent_contact_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_dependent_contact_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contact_phone_number { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int Approval_status { get; set; }
        public string Approval_status_name { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_qualification_contract_resp
    {
        public hrm_emp_qualification_contract_resp()
        {
            employeeList = new List<hrm_emp_qualification_contract>();
        }

        public List<hrm_emp_qualification_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }

    public class hrm_emp_qualification_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string Certificate { get; set; }
        public string Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Attachment { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }

        public IFormFile qualificationFile { get; set; }
    }

    public class hrm_emp_language_contract_resp
    {
        public hrm_emp_language_contract_resp()
        {
            employeeList = new List<hrm_emp_language_contract>();
        }

        public List<hrm_emp_language_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_language_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public int Reading_Rating { get; set; }
        public int Writing_Rating { get; set; }
        public int Speaking_Rating { get; set; }
        public int Approval_status { get; set; }
        public string Approval_status_name { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_career_contract_resp
    {
        public hrm_emp_career_contract_resp()
        {
            employeeList = new List<hrm_emp_career_contract>();
        }

        public List<hrm_emp_career_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_career_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int Job_GradeId { get; set; }
        public int Job_titleId { get; set; }
        public string Job_Grade { get; set; }
        public string Job_title { get; set; }
        public string Job_type { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Office { get; set; }
        public string Line_Manager { get; set; }
        public string Start_date { get; set; }
        public string First_Level_Reviewer { get; set; }
        public string Second_Level_Reviewer { get; set; }
        public string Start_month { get; set; }
        public string Start_year { get; set; }
        public string End_month { get; set; }
        public string End_year { get; set; }
        public int Approval_status { get; set; }
        public string Approval_status_name { get; set; }
        public int StaffId { get; set; }
    }

    public class hrm_emp_hobbies_contract_resp
    {
        public hrm_emp_hobbies_contract_resp()
        {
            employeeList = new List<hrm_emp_hobbies_contract>();
        }

        public List<hrm_emp_hobbies_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_hobbies_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string HobbyName { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int ApprovalStatus { get; set; }
        public string Approval_status_name { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_referees_contract_resp
    {
        public hrm_emp_referees_contract_resp()
        {
            employeeList = new List<hrm_emp_referees_contract>();
        }

        public List<hrm_emp_referees_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_referees_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public int NumberOfYears { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public bool ConfirmationReceived { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public string RefereeFilePath { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
        public IFormFile RefereeFile { get; set; }
    }

    public class hrm_emp_assets_contract_resp
    {
        public hrm_emp_assets_contract_resp()
        {
            employeeList = new List<hrm_emp_assets_contract>();
        }

        public List<hrm_emp_assets_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_assets_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string AssetNumber { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public int PhysicalCondition { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int RequestApprovalStatus { get; set; }
        public string RequestApprovalStatusName { get; set; }
        public int ReturnApprovalStatus { get; set; }
        public string ReturnApprovalStatusName { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_prof_certification_contract_resp
    {
        public hrm_emp_prof_certification_contract_resp()
        {
            employeeList = new List<hrm_emp_prof_certification_contract>();
        }

        public List<hrm_emp_prof_certification_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_prof_certification_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int CertificationId { get; set; }
        public string CertificateName { get; set; }
        public string Institution { get; set; }
        public DateTime? DateGranted { get; set; }
        public string ExpiryDate { get; set; }
        public int GradeId { get; set; }
        public string Attachment { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
        public IFormFile ProfCertificationFile { get; set; }
    }
    public class hrm_emp_hmo_contract_resp
    {
        public hrm_emp_hmo_contract_resp()
        {
            employeeList = new List<hrm_emp_hmo_contract>();
        }

        public List<hrm_emp_hmo_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_hmo_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int HmoId { get; set; }
        public string HmoName { get; set; }
        public decimal Hmo_rating { get; set; }
        public string ContactPhoneNo { get; set; }
        public DateTime? StartDate { get; set; }
        public string End_Date { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_hmo_change_request_contract_resp
    {
        public hrm_emp_hmo_change_request_contract_resp()
        {
            employeeList = new List<hrm_emp_hmo_change_request_contract>();
        }

        public List<hrm_emp_hmo_change_request_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_hmo_change_request_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int HmoId { get; set; }
        public string ExistingHmo { get; set; }
        public int SuggestedHmo { get; set; }
        public string SuggestedHmoName { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public DateTime? ExpectedDateOfChange { get; set; }
        public string FileUrl { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public IFormFile hmoFile { get; set; }
    }
    public class hrm_emp_hospital_contract_resp
    {
        public hrm_emp_hospital_contract_resp()
        {
            employeeList = new List<hrm_emp_hospital_contract>();
        }

        public List<hrm_emp_hospital_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_hospital_contract: IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public decimal HospitalRating { get; set; }
        public string ContactPhoneNo { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_hospital_change_request_contract_resp
    {
        public hrm_emp_hospital_change_request_contract_resp()
        {
            employeeList = new List<hrm_emp_hospital_change_request_contract>();
        }

        public List<hrm_emp_hospital_change_request_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_hospital_change_request_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string ExistingHospital { get; set; }
        public int SuggestedHospital { get; set; }
        public string SuggestedHospitalName { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public DateTime? ExpectedDateOfChange { get; set; }
        public string FileUrl { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public IFormFile hospitalFile { get; set; }
    }
    public class hrm_emp_hospital_meeting_contract_resp
    {
        public hrm_emp_hospital_meeting_contract_resp()
        {
            employeeList = new List<hrm_emp_hospital_meeting_contract>();
        }

        public List<hrm_emp_hospital_meeting_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_hospital_meeting_contract: IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalEmail { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime ProposedMeetingDate { get; set; }
        public string FileUrl { get; set; }
        public string ReasonsForMeeting { get; set; }
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public IFormFile hospitalMeetingFile { get; set; }
    }
    public class hrm_emp_gym_contract_resp
    {
        public hrm_emp_gym_contract_resp()
        {
            employeeList = new List<hrm_emp_gym_contract>();
        }

        public List<hrm_emp_gym_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_gym_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int GymId { get; set; }
        public string GymName { get; set; }
        public decimal GymRating { get; set; }
        public string GymContactPhoneNo { get; set; }
        public DateTime? StartDate { get; set; }
        public string End_Date { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_gym_change_request_contract_resp
    {
        public hrm_emp_gym_change_request_contract_resp()
        {
            employeeList = new List<hrm_emp_gym_change_request_contract>();
        }

        public List<hrm_emp_gym_change_request_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_gym_change_request_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int GymId { get; set; }
        public string ExistingGym { get; set; }
        public int SuggestedGym { get; set; }
        public string SuggestedGymName { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public DateTime? ExpectedDateOfChange { get; set; }
        public string FileUrl { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public IFormFile gymFile { get; set; }
    }
    public class hrm_emp_gym_meeting_contract_resp
    {
        public hrm_emp_gym_meeting_contract_resp()
        {
            employeeList = new List<hrm_emp_gym_meeting_contract>();
        }

        public List<hrm_emp_gym_meeting_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_gym_meeting_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int GymId { get; set; }
        public string GymName { get; set; }
        public string GymEmail { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime ProposedMeetingDate { get; set; }
        public string ReasonsForMeeting { get; set; }
        public string FileUrl { get; set; }
        public int StaffId { get; set; }
        public string StaffCode { get; set; }
        public IFormFile gymMeetingFile { get; set; }
    }

    public class hrm_emp_skills_contract_resp
    {
        public hrm_emp_skills_contract_resp()
        {
            employeeList = new List<hrm_emp_skills_contract>();
        }

        public List<hrm_emp_skills_contract> employeeList { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_emp_skills_contract : IRequest<hrm_emp_add_update_response>
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int ExpectedScore { get; set; }
        public int ActualScore { get; set; }
        public string ProofOfSkills { get; set; }
        public string ProofOfSkillsUrl { get; set; }
        public int ApprovalStatus { get; set; }
        public string ApprovalStatusName { get; set; }
        public int StaffId { get; set; }
        public IFormFile SkillFile { get; set; }
    }


}
