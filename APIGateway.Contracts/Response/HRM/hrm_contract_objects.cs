using GODPAPIs.Contracts.GeneralExtension;
using GOSLibraries.GOS_API_Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Contracts.Response.HRM
{

    public class hrm_setup_add_update_response
    {
        public hrm_setup_add_update_response()
        {
            Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() };
        }
        public int Setup_id { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_jobtitle_contract_resp
    {
        public hrm_setup_jobtitle_contract_resp()
        {
            Setuplist = new List<hrm_setup_jobtitle_contract>();
        }
        public List<hrm_setup_jobtitle_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_jobtitle_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }
        public string Job_title { get; set; }
        public string Job_description { get; set; }
        public int ExcelLineNumber { get; set; }
        public decimal TotalSkillWeight { get; set; }
        public List<hrm_setup_sub_skill_contract> Sub_Skills { get; set; }
    }
    public class hrm_setup_sub_skill_contract_resp
    {
        public List<hrm_setup_sub_skill_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_sub_skill_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }
        public int Job_details_Id { get; set; }
        public string Skill { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public string Job_title { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_jobgrade_contract_resp
    {
        public List<hrm_setup_jobgrade_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_jobgrade_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Job_grade { get; set; }
        public string Job_grade_reporting_to { get; set; }
        public int Rank { get; set; }
        public int Probation_period_in_months { get; set; }
        public string Description { get; set; }
        public int ExcelLineNumber { get; set; }

        //public string Job_grade_reporting_to_name { get; set; }
    }

    public class hrm_setup_employmenttype_contract_resp
    {
        public List<hrm_setup_employmenttype_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }

    public class hrm_setup_employmenttype_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Employment_type { get; set; }
        public string Description { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_employmentlevel_contract_resp
    {
        public List<hrm_setup_employmentlevel_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_employmentlevel_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Employment_level { get; set; }
        public string Description { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_academic_qualification_contract_resp
    {
        public List<hrm_setup_academic_qualification_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_academic_qualification_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }
        public string Qualification { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_academic_discipline_contract_resp
    {
        public List<hrm_setup_academic_discipline_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_academic_discipline_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Discipline { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_academic_grade_contract_resp
    {
        public List<hrm_setup_academic_grade_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_academic_grade_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Grade { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_high_school_subjects_contract_resp
    {
        public List<hrm_setup_high_school_subjects_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_high_school_subjects_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }
        public int ExcelLineNumber { get; set; }

    }

    public class hrm_setup_high_school_grade_contract_resp
    {
        public List<hrm_setup_high_school_grade_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_high_school_grade_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Grade { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_proffessional_certification_contract_resp
    {
        public List<hrm_setup_proffessional_certification_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_proffessional_certification_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Certification { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_languages_contract_resp
    {
        public List<hrm_setup_languages_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_languages_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Language { get; set; }
        public string Description { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_proffesional_membership_contract_resp
    {
        public List<hrm_setup_proffesional_membership_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_proffesional_membership_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Professional_membership { get; set; }
        public string Description { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_hmo_contract_resp
    {
        public List<hrm_setup_hmo_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_hmo_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Hmo_name { get; set; }
        public string Hmo_code { get; set; }
        public string Contact_phone_number { get; set; }
        public string Contact_email { get; set; }
        public string Address { get; set; }
        public DateTime Reg_date { get; set; }
        public decimal Rating { get; set; }
        public string Other_comments { get; set; }
        public int ExcelLineNumber { get; set; }
    }

    public class hrm_setup_gym_workouts_contract_resp
    {
        public List<hrm_setup_gym_workouts_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_gym_workouts_contract : IRequest<hrm_setup_add_update_response>
    {

        public int Id { get; set; }

        public string Gym { get; set; }
        public string Contact_phone_number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Ratings { get; set; }
        public string Other_comments { get; set; }
        public int ExcelLineNumber { get; set; }

    }
    public class hrm_setup_location_contract_resp
    {
        public List<hrm_setup_location_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_location_contract : IRequest<hrm_setup_add_update_response>
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string AdditionalInformation { get; set; }
        public int ExcelLineNumber { get; set; }
    }
    public class hrm_setup_hospital_management_contract_resp
    {
        public List<hrm_setup_hospital_management_contract> Setuplist { get; set; }
        public APIResponseStatus Status { get; set; }
    }
    public class hrm_setup_hospital_management_contract : IRequest<hrm_setup_add_update_response>
    {
        public int Id { get; set; }
        public string Hospital { get; set; }
        public int HmoId { get; set; }
        public string HmoName { get; set; }
        public string ContactPhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }
        public string OtherComments { get; set; }
        public int ExcelLineNumber { get; set; }
    }
}