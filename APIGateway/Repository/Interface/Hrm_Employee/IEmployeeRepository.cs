using APIGateway.DomainObjects.hrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Repository.Interface.Hrm_Employee
{
    public interface IEmployeeRepository
    {
        //HRM EMPLOYEE IDENTIFICATION
        Task<List<hrm_emp_identification>> GetAllEmpIdentificationAsync();
        Task<bool> AddUpdateEmpIdentificationAsync(hrm_emp_identification model);
        Task<bool> DeleteEmpIdentificationAsync(int Id);
        Task<hrm_emp_identification> GetEmpIdentificationByIdAsync(int Id);
        Task<hrm_emp_identification> GetEmpIdentificationByStaffIdAsync(int staffId);

        //HRM EMPLOYEE EMERGENCY CONTACT
        Task<List<hrm_emp_emergency_contact>> GetAllEmpEmergencyContactAsync();
        Task<bool> AddUpdateEmpEmergencyContactAsync(hrm_emp_emergency_contact model);
        Task<bool> DeleteEmpEmergencyContactAsync(int Id);
        Task<hrm_emp_emergency_contact> GetEmpEmergencyContactByIdAsync(int Id);
        Task<hrm_emp_emergency_contact> GetEmpEmergencyContactByStaffIdAsync(int staffId);

        //HRM EMPLOYEE DEPENDENT CONTACT
        Task<List<hrm_emp_dependent_contact>> GetAllEmpDependentContactAsync();
        Task<bool> AddUpdateEmpDependentContactAsync(hrm_emp_dependent_contact model);
        Task<bool> DeleteEmpDependentContactAsync(int Id);
        Task<hrm_emp_dependent_contact> GetEmpEmpDependentContactByIdAsync(int Id);
        Task<hrm_emp_dependent_contact> GetEmpEmpDependentContactByStaffIdAsync(int staffId);

        //HRM EMPLOYEE LANGUAGE
        Task<List<hrm_emp_language>> GetAllEmpLanguageAsync();
        Task<bool> AddUpdateEmpLanguageAsync(hrm_emp_language model);
        Task<bool> DeleteEmpLanguageAsync(int Id);
        Task<hrm_emp_language> GetEmpLanguageByIdAsync(int Id);
        Task<hrm_emp_language> GetEmpLanguageByStaffIdAsync(int staffId);

        //HMR EMPLOYEE CAREER
        Task<List<hrm_emp_career>> GetAllEmpCareerAsync();
        Task<bool> AddUpdateEmpCareerAsync(hrm_emp_career model);
        Task<bool> DeleteEmpCareerAsync(int Id);
        Task<hrm_emp_career> GetEmpCareerByIdAsync(int Id);
        Task<hrm_emp_career> GetEmpCareerByStaffIdAsync(int staffId);

        //HMR EMPLOYEE HOBBIES
        Task<List<hrm_emp_hobbies>> GetAllEmpHobbiesAsync();
        Task<bool> AddUpdateEmpHobbyAsync(hrm_emp_hobbies model);
        Task<bool> DeleteEmpHobbyAsync(int Id);
        Task<hrm_emp_hobbies> GetEmpHobbyByIdAsync(int Id);
        Task<hrm_emp_hobbies> GetEmpHobbyByStaffIdAsync(int staffId);

        //HRM EMPLOYEE REFEREE
        Task<List<hrm_emp_referees>> GetAllEmpRefereesAsync();
        Task<bool> AddUpdateEmpRefereeAsync(hrm_emp_referees model);
        Task<bool> DeleteEmpRefereeAsync(int Id);
        Task<hrm_emp_referees> GetEmpRefereeByIdAsync(int Id);
        Task<hrm_emp_referees> GetEmpRefereeByStaffIdAsync(int staffId);

        //HRM EMPLOYEE REFEREE
        Task<List<hrm_emp_assets>> GetAllEmpAssetsAsync();
        Task<bool> AddUpdateEmpAssetAsync(hrm_emp_assets model);
        Task<bool> DeleteEmpAssetAsync(int Id);
        Task<hrm_emp_assets> GetEmpAssetByIdAsync(int Id);
        Task<hrm_emp_assets> GetEmpAssetByStaffIdAsync(int staffId);

        //HRM EMPLOYEE Prof_Certification
        Task<List<hrm_emp_prof_certification>> GetAllEmpProfCertificationAsync();
        Task<bool> AddUpdateEmpProfCertificationAsync(hrm_emp_prof_certification model);
        Task<bool> DeleteEmpProfCertificationAsync(int Id);
        Task<hrm_emp_prof_certification> GetEmpProfCertificationByIdAsync(int Id);
        Task<hrm_emp_prof_certification> GetEmpProfCertificationByStaffIdAsync(int staffId);

        //HRM EMPLOYEE QUALIFICATION
        Task<List<hrm_emp_qualification>> GetAllEmpQualificationAsync();
        Task<bool> AddUpdateEmpQualificationAsync(hrm_emp_qualification model);
        Task<bool> DeleteEmpQualificationAsync(int Id);
        Task<hrm_emp_qualification> GetEmpQualificationByIdAsync(int Id);
        Task<hrm_emp_qualification> GetEmpQualificationByStaffIdAsync(int staffId);

        //HRM EMPLOYEE HMO
        Task<List<hrm_emp_hmo>> GetAllEmpHmoAsync();
        Task<bool> AddUpdateEmpHmoAsync(hrm_emp_hmo model);
        Task<bool> DeleteEmpHmoAsync(int Id);
        Task<hrm_emp_hmo> GetEmpHmoByIdAsync(int Id);
        Task<hrm_emp_hmo> GetEmpHmoByStaffIdAsync(int staffId);
        Task<bool> AddUpdateEmpHmoChangeRequestAsync(hrm_emp_hmo_change_request model);
        Task<List<hrm_emp_hmo_change_request>> GetAllEmpHmoChangeRequestAsync();

        //HRM EMPLOYEE Hospital
        Task<List<hrm_emp_hospital>> GetAllEmpHospitalAsync();
        Task<bool> AddUpdateEmpHospitalAsync(hrm_emp_hospital model);
        Task<bool> DeleteEmpHospitalAsync(int Id);
        Task<hrm_emp_hospital> GetEmpHospitalByIdAsync(int Id);
        Task<hrm_emp_hospital> GetEmpHospitalByStaffIdAsync(int staffId);
        Task<bool> AddUpdateEmpHospitalChangeRequestAsync(hrm_emp_hospital_change_request model);
        Task<List<hrm_emp_hospital_change_request>> GetAllEmpHospitalChangeRequestAsync();
        Task<bool> AddUpdateEmpHospitalMeetingAsync(hrm_emp_hospital_meeting model);
        Task<List<hrm_emp_hospital_meeting>> GetAllEmpHospitalMeetingAsync();

        //HRM EMPLOYEE Gym
        Task<List<hrm_emp_gym>> GetAllEmpGymAsync();
        Task<bool> AddUpdateEmpGymAsync(hrm_emp_gym model);
        Task<hrm_emp_gym> GetEmpGymByIdAsync(int Id);
        Task<hrm_emp_gym> GetEmpGymByStaffIdAsync(int staffId);
        Task<bool> AddUpdateEmpGymChangeRequestAsync(hrm_emp_gym_change_request model);
        Task<List<hrm_emp_gym_change_request>> GetAllEmpGymChangeRequestAsync();
        Task<bool> AddUpdateEmpGymMeetingAsync(hrm_emp_gym_meeting model);
        Task<List<hrm_emp_gym_meeting>> GetAllEmpGymMeetingAsync();

        //HRM EMPLOYEE SKILLS
        Task<List<hrm_emp_skills>> GetAllEmpSkillsAsync();
        Task<bool> AddUpdateEmpSkillAsync(hrm_emp_skills model);
        Task<bool> DeleteEmpSkillAsync(int Id);
        Task<hrm_emp_skills> GetEmpSkillByIdAsync(int Id);
        Task<hrm_emp_skills> GetEmpSkillByStaffIdAsync(int staffId);

        //HRM EMPLOYEE Staff
        Task<List<hrm_staffs>> GetAllHrmStaffAsync();
        Task<bool> AddUpdateHrmStaffAsync(hrm_staffs model);
        Task<bool> DeleteHrmStaffAsync(int Id);
        Task<hrm_staffs> GetHrmStaffByIdAsync(int Id);
    }
}
