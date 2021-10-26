using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Validations.Hrm.employee
{
    public class hrm_emp_identification_contractValidator : AbstractValidator<hrm_emp_Identification_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_identification_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.Identification).NotEmpty();
            RuleFor(e => e.Identification_number).NotEmpty();
            RuleFor(e => e.IdIssues).NotEmpty();
            RuleFor(e => e.IdExpiry_date).NotEmpty();
            RuleFor(e => e.Approval_status).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_emergency_contact_contractValidator : AbstractValidator<hrm_emp_emergency_contact_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_emergency_contact_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.FullName).NotEmpty();
            RuleFor(e => e.Contact_phone_number).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.Relationship).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.CountryId).NotEmpty();
            RuleFor(e => e.Approval_status).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_dependent_contact_contractValidator : AbstractValidator<hrm_emp_dependent_contact_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_dependent_contact_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.FullName).NotEmpty();
            RuleFor(e => e.Contact_phone_number).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.Relationship).NotEmpty();
            RuleFor(e => e.DateOfBirth).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.CountryId).NotEmpty();
            RuleFor(e => e.Approval_status).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_language_contractValidator : AbstractValidator<hrm_emp_language_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_language_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.LanguageId).NotEmpty();
            RuleFor(e => e.Reading_Rating).NotEmpty();
            RuleFor(e => e.Writing_Rating).NotEmpty();
            RuleFor(e => e.Speaking_Rating).NotEmpty();
            RuleFor(e => e.Approval_status).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_career_contractValidator : AbstractValidator<hrm_emp_career_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_career_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.Job_GradeId).NotEmpty();
            RuleFor(e => e.Job_titleId).NotEmpty();
            RuleFor(e => e.Job_type).NotEmpty();
            RuleFor(e => e.CountryId).NotEmpty();
            RuleFor(e => e.LocationId).NotEmpty();
            RuleFor(e => e.Office).NotEmpty();
            RuleFor(e => e.Line_Manager).NotEmpty();
            RuleFor(e => e.First_Level_Reviewer).NotEmpty();
            RuleFor(e => e.Second_Level_Reviewer).NotEmpty();
            RuleFor(e => e.Start_month).NotEmpty();
            RuleFor(e => e.Start_year).NotEmpty();
            RuleFor(e => e.End_month).NotEmpty();
            RuleFor(e => e.End_year).NotEmpty();
            RuleFor(e => e.Approval_status).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_hobby_contractValidator : AbstractValidator<hrm_emp_hobbies_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_hobby_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.HobbyName).NotEmpty();
            RuleFor(e => e.Description).NotEmpty();
            RuleFor(e => e.Rating).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_referee_contractValidator : AbstractValidator<hrm_emp_referees_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_referee_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.FullName).NotEmpty();
            RuleFor(e => e.PhoneNumber).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.Relationship).NotEmpty();
            RuleFor(e => e.NumberOfYears).NotEmpty();
            RuleFor(e => e.Organization).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.ConfirmationReceived).NotEmpty();
            RuleFor(e => e.ConfirmationDate).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_asset_contractValidator : AbstractValidator<hrm_emp_assets_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_asset_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.AssetName).NotEmpty();
            RuleFor(e => e.AssetNumber).NotEmpty();
            RuleFor(e => e.Classification).NotEmpty();
            RuleFor(e => e.PhysicalCondition).NotEmpty();
            RuleFor(e => e.LocationId).NotEmpty();
            RuleFor(e => e.RequestApprovalStatus).NotEmpty();
            RuleFor(e => e.ReturnApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_prof_certification_contractValidator : AbstractValidator<hrm_emp_prof_certification_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_prof_certification_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.CertificationId).NotEmpty();
            RuleFor(e => e.Institution).NotEmpty();
            RuleFor(e => e.DateGranted).NotEmpty();
            RuleFor(e => e.ExpiryDate).NotEmpty();
            RuleFor(e => e.GradeId).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_qualification_contractValidator : AbstractValidator<hrm_emp_qualification_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_qualification_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.Certificate).NotEmpty();
            RuleFor(e => e.Institution).NotEmpty();
            RuleFor(e => e.StartDate).NotEmpty();
            RuleFor(e => e.EndDate).NotEmpty();
            RuleFor(e => e.GradeId).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_hmo_contractValidator : AbstractValidator<hrm_emp_hmo_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_hmo_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.HmoId).NotEmpty();
            RuleFor(e => e.Hmo_rating).NotEmpty();
            RuleFor(e => e.ContactPhoneNo).NotEmpty();
            RuleFor(e => e.StartDate).NotEmpty();
            RuleFor(e => e.End_Date).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_hospital_contractValidator : AbstractValidator<hrm_emp_hospital_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_hospital_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.HospitalId).NotEmpty();
            RuleFor(e => e.HospitalRating).NotEmpty();
            RuleFor(e => e.ContactPhoneNo).NotEmpty();
            RuleFor(e => e.StartDate).NotEmpty();
            RuleFor(e => e.EndDate).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_gym_contractValidator : AbstractValidator<hrm_emp_gym_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_gym_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.GymId).NotEmpty();
            RuleFor(e => e.GymRating).NotEmpty();
            RuleFor(e => e.GymContactPhoneNo).NotEmpty();
            RuleFor(e => e.StartDate).NotEmpty();
            RuleFor(e => e.End_Date).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_hmo_change_request_contractValidator : AbstractValidator<hrm_emp_hmo_change_request_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_hmo_change_request_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.HmoId).NotEmpty();
            RuleFor(e => e.SuggestedHmo).NotEmpty();
            RuleFor(e => e.DateOfRequest).NotEmpty();
            RuleFor(e => e.ExpectedDateOfChange).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_hospital_change_request_contractValidator : AbstractValidator<hrm_emp_hospital_change_request_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_hospital_change_request_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.HospitalId).NotEmpty();
            RuleFor(e => e.ExistingHospital).NotEmpty();
            RuleFor(e => e.SuggestedHospital).NotEmpty();
            RuleFor(e => e.DateOfRequest).NotEmpty();
            RuleFor(e => e.ExpectedDateOfChange).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_hospital_meeting_contractValidator : AbstractValidator<hrm_emp_hospital_meeting_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_hospital_meeting_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.HospitalId).NotEmpty();
            RuleFor(e => e.DateOfRequest).NotEmpty();
            RuleFor(e => e.ProposedMeetingDate).NotEmpty();
            RuleFor(e => e.ReasonsForMeeting).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_gym_change_request_contractValidator : AbstractValidator<hrm_emp_gym_change_request_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_gym_change_request_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.GymId).NotEmpty();
            RuleFor(e => e.ExistingGym).NotEmpty();
            RuleFor(e => e.SuggestedGym).NotEmpty();
            RuleFor(e => e.DateOfRequest).NotEmpty();
            RuleFor(e => e.ExpectedDateOfChange).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_gym_meeting_contractValidator : AbstractValidator<hrm_emp_gym_meeting_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_gym_meeting_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.GymId).NotEmpty();
            RuleFor(e => e.DateOfRequest).NotEmpty();
            RuleFor(e => e.ProposedMeetingDate).NotEmpty();
            RuleFor(e => e.ReasonsForMeeting).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }
    public class hrm_emp_skills_contractValidator : AbstractValidator<hrm_emp_skills_contract>
    {
        private readonly DataContext _dataContext;
        public hrm_emp_skills_contractValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.SkillId).NotEmpty();
            RuleFor(e => e.ActualScore).NotEmpty();
            RuleFor(e => e.ProofOfSkills).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotEmpty();
            RuleFor(e => e.StaffId).NotEmpty();
        }

    }

}
