using GODPAPIs.Contracts.GeneralExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DomainObjects.hrm
{
    //public class hrm_setup_location : GeneralEntity
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    public string Address { get; set; }
    //    public int City { get; set; }
    //    public int State { get; set; }
    //    public int Country { get; set; }
    //    public string Additionalinformtion { get; set; }
    //}
    public class hrm_setup_jobtitle : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Job_title { get; set; }
        public string Job_description { get; set; }
        public List<hrm_setup_sub_skill> Sub_Skills { get; set; }
    }

    
    public class hrm_setup_sub_skill : GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public int Job_details_Id { get; set; }
        public string Skill { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
    }
    //hrm_setup_jobdetails
    public class hrm_setup_jobgrade : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Job_grade { get; set; }
        public string Job_grade_reporting_to { get; set; }
        public int Rank { get; set; }
        public int Probation_period_in_months { get; set; }
        public string Description { get; set; }
    }

    public class hrm_setup_employmenttype : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Employment_type { get; set; }
        public string Description { get; set; }
    }

    public class hrm_setup_employmentlevel : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Employment_level { get; set; }
        public string Description { get; set; }
    }

    public class hrm_setup_academic_qualification : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Qualification { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }

    public class hrm_setup_academic_discipline : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Discipline { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }

    public class hrm_setup_academic_grade : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Grade { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }

    public class hrm_setup_high_school_subjects : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }
    }

    public class hrm_setup_high_school_grade : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Grade { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }
    public class hrm_setup_proffessional_certification : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Certification { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
    }
    public class hrm_setup_languages : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Language { get; set; }
        public string Description { get; set; }
    }

    public class hrm_setup_proffesional_membership : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Professional_membership { get; set; }
        public string Description { get; set; }
    }

    public class hrm_setup_hmo : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Hmo_name { get; set; }
        public string Hmo_code { get; set; }
        public string Contact_phone_number { get; set; }
        public string Contact_email { get; set; }
        public string Address { get; set; }
        public DateTime Reg_date { get; set; }
        public decimal Rating { get; set; }
        public string Other_comments { get; set; }
    }
    public class hrm_setup_gym_workouts : GeneralEntity
    {
        [Key]
        public int Id { get; set; }

        public string Gym { get; set; }
        public string Contact_phone_number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Ratings { get; set; }
        public string Other_comments { get; set; }

    }
    public class hrm_setup_location: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string AdditionalInformation { get; set; }
    }
    public class hrm_setup_hospital_management: GeneralEntity
    {
        [Key]
        public int Id { get; set; }
        public string Hospital { get; set; }
        public int HmoId { get; set; }
        public string ContactPhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }
        public string OtherComments { get; set; }
    }
}
