using APIGateway.DomainObjects.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Repository.Interface.Setup
{
    public interface ISetupRepository
    {
        Task<List<hrm_setup_academic_discipline>> GetAllAcademicDisciplineAsync();
        Task<bool> AddUpdateAcademicDisciplineAsync(hrm_setup_academic_discipline model);
        Task<IEnumerable<hrm_setup_academic_grade>> GetAllAcademicGradeAsync();
        Task<bool> AddUpdateAcademicGradeAsync(hrm_setup_academic_grade model);
        Task<IEnumerable<hrm_setup_academic_qualification>> GetAllAcademicQualificationAsync();
        Task<bool> AddUpdateAcademicQualificationAsync(hrm_setup_academic_qualification model);
        Task<IEnumerable<hrm_setup_employmenttype>> GetAllEmploymentTypeAsync();
        Task<bool> AddUpdateEmploymentTypeAsync(hrm_setup_employmenttype model);
        Task<IEnumerable<hrm_setup_employmentlevel>> GetAllEmploymentLevelAsync();
        Task<bool> AddUpdateEmploymentLevelAsync(hrm_setup_employmentlevel model);
        Task<IEnumerable<hrm_setup_gym_workouts>> GetAllGymWorkoutAsync();
        Task<bool> AddUpdateGymWorkoutAsync(hrm_setup_gym_workouts model);
        Task<IEnumerable<hrm_setup_high_school_grade>> GetAllHighSchoolGradesAsync();
        Task<bool> AddUpdateHighSchoolGradeAsync(hrm_setup_high_school_grade model);
        Task<IEnumerable<hrm_setup_high_school_subjects>> GetAllHighSchoolSubjectsAsync();
        Task<bool> AddUpdateHighSchoolSubjectsAsync(hrm_setup_high_school_subjects model);
        Task<IEnumerable<hrm_setup_hmo>> GetAllHMOAsync();
        Task<bool> AddUpdateHMOAsync(hrm_setup_hmo model);
        Task<IEnumerable<hrm_setup_jobtitle>> GetAllJobTitleAsync();
        Task<bool> AddUpdateJobTitleAsync(hrm_setup_jobtitle model);
        Task<IEnumerable<hrm_setup_sub_skill>> GetAllJobSkillsAsync();
        Task<bool> AddUpdateJobSkillsAsync( hrm_setup_sub_skill model);
        Task<IEnumerable<hrm_setup_jobgrade>> GetAllJobGradesAsync();
        Task<bool> AddUpdateJobGradeAsync(hrm_setup_jobgrade model);
        Task<IEnumerable<hrm_setup_languages>> GetAllLanguagesAsync();
        Task<bool> AddUpdateLanguageAsync(hrm_setup_languages model);
        Task<IEnumerable<hrm_setup_proffesional_membership>> GetAllProfMembershipsAsync();
        Task<bool> AddUpdateProfMembershipAsync(hrm_setup_proffesional_membership model);
        Task<IEnumerable<hrm_setup_proffessional_certification>> GetAllProfCertificationsAsync();
        Task<bool> AddUpdateProfCertificationAsync(hrm_setup_proffessional_certification model);
        Task<IEnumerable<hrm_setup_location>> GetAllLocationsAsync();
        Task<bool> AddUpdateLocationAsync(hrm_setup_location model);
        Task<IEnumerable<hrm_setup_hospital_management>> GetAllHospitalManagementsAsync();
        Task<bool> AddUpdateHospitalManagementAsync(hrm_setup_hospital_management model);

    }
}
