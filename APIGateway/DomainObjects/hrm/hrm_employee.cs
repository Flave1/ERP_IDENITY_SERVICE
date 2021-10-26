using GODP.APIsContinuation.DomainObjects.Company;
using GODP.APIsContinuation.DomainObjects.Workflow;
using GODPAPIs.Contracts.GeneralExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DomainObjects.hrm
{
    public class hrm_emp_identification : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string Identification { get; set; }
        public string Identification_number { get; set; }
        public string IdIssues { get; set; }
        public DateTime? IdExpiry_date { get; set; }
        public string IdentificationFilePath { get; set; }
        public int Approval_status { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_emergency_contact : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contact_phone_number { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int Approval_status { get; set; }
        public int StaffId { get; set; }
    }

    public class hrm_emp_dependent_contact : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Contact_phone_number { get; set; }
        public string Email { get; set; }
        public string Relationship { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int Approval_status { get; set; }
        public int StaffId { get; set; }

    }
    public class hrm_emp_qualification : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string Certificate { get; set; }
        public string Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int GradeId { get; set; }
        public string Attachment { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }

    }
    public class hrm_emp_language : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int Reading_Rating { get; set; }
        public int Writing_Rating { get; set; }
        public int Speaking_Rating { get; set; }
        public int Approval_status { get; set; }
        public int StaffId { get; set; }

    }
    public class hrm_emp_career : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int Job_GradeId { get; set; }
        public int Job_titleId { get; set; }
        public string Job_type { get; set; }
        public int CountryId { get; set; }
        public int LocationId { get; set; }
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

    public class hrm_emp_hobbies : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string HobbyName { get; set; }
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }

    }
    public  class hrm_emp_referees: GeneralEntity
    {
        [Key]
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
        public int StaffId { get; set; }

    }
    public class hrm_emp_assets: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string AssetNumber { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        public int PhysicalCondition { get; set; }
        public int LocationId { get; set; }
        public int RequestApprovalStatus { get; set; }
        public int ReturnApprovalStatus { get; set; }
        public int StaffId { get; set; }

    }
    public class hrm_emp_prof_certification: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int CertificationId { get; set; }
        public string Institution { get; set; }
        public DateTime? DateGranted { get; set; }
        public string ExpiryDate { get; set; }
        public int GradeId { get; set; }
        public string Attachment { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_hmo: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int HmoId { get; set; }
        public decimal Hmo_rating { get; set; }
        public string ContactPhoneNo { get; set; }
        public DateTime? StartDate { get; set; }
        public string End_Date { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }

    }
    public class hrm_emp_hmo_change_request: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int HmoId { get; set; }
        public string ExistingHmo { get; set; }
        public int SuggestedHmo { get; set; }
        public string SuggestedHmoName { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public DateTime? ExpectedDateOfChange { get; set; }
        public int ApprovalStatus { get; set; }
        public string FileUrl { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_hospital: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public decimal HospitalRating { get; set; }
        public string ContactPhoneNo { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }

    }
    public class hrm_emp_hospital_change_request: GeneralEntity
    {

        [Key]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int SuggestedHospital { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public DateTime? ExpectedDateOfChange { get; set; }
        public int ApprovalStatus { get; set; }
        public string FileUrl { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_hospital_meeting: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime ProposedMeetingDate { get; set; }
        public string ReasonsForMeeting { get; set; }
        public int StaffId { get; set; }
        public string FileUrl { get; set; }

    }
    public class hrm_emp_gym : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        public decimal GymRating { get; set; }
        public string GymContactPhoneNo { get; set; }
        public DateTime? StartDate { get; set; }
        public string End_Date { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_gym_change_request : GeneralEntity
    {

        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        public int SuggestedGym { get; set; }
        public DateTime? DateOfRequest { get; set; }
        public DateTime? ExpectedDateOfChange { get; set; }
        public int ApprovalStatus { get; set; }
        public string FileUrl { get; set; }
        public int StaffId { get; set; }
    }
    public class hrm_emp_gym_meeting : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int GymId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime ProposedMeetingDate { get; set; }
        public string ReasonsForMeeting { get; set; }
        public int StaffId { get; set; }
        public string FileUrl { get; set; }

    }
    public class hrm_emp_skills : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int ExpectedScore { get; set; }
        public int ActualScore { get; set; }
        public string ProofOfSkills { get; set; }
        public string ProofOfSkillsUrl { get; set; }
        public int ApprovalStatus { get; set; }
        public int StaffId { get; set; }

    }
    

}
