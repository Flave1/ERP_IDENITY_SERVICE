using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Hrm_Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Repository.Inplimentation.Hrm_Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUpdateEmpAssetAsync(hrm_emp_assets model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_assets.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_assets.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpCareerAsync(hrm_emp_career model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_career.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_career.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpDependentContactAsync(hrm_emp_dependent_contact model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_dependent_contact.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_dependent_contact.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpEmergencyContactAsync(hrm_emp_emergency_contact model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_emergency_contact.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_emergency_contact.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpGymAsync(hrm_emp_gym model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_gym.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_gym.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpGymChangeRequestAsync(hrm_emp_gym_change_request model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_gym_change_request.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_gym_change_request.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpGymMeetingAsync(hrm_emp_gym_meeting model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_gym_meeting.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_gym_meeting.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpHmoAsync(hrm_emp_hmo model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_hmo.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_hmo.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpHmoChangeRequestAsync(hrm_emp_hmo_change_request model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_hmo_change_request.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_hmo_change_request.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpHobbyAsync(hrm_emp_hobbies model)
        {

            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_hobbies.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_hobbies.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpHospitalAsync(hrm_emp_hospital model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_hospital.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_hospital.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpHospitalChangeRequestAsync(hrm_emp_hospital_change_request model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_hospital_change_request.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_hospital_change_request.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpHospitalMeetingAsync(hrm_emp_hospital_meeting model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_hospital_meeting.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_hospital_meeting.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpIdentificationAsync(hrm_emp_identification model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_identifications.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_identifications.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpLanguageAsync(hrm_emp_language model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_language.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_language.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpProfCertificationAsync(hrm_emp_prof_certification model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_prof_certification.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_prof_certification.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpQualificationAsync(hrm_emp_qualification model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_qualification.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_qualification.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpRefereeAsync(hrm_emp_referees model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_referees.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_referees.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmpSkillAsync(hrm_emp_skills model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_emp_skills.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_emp_skills.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateHrmStaffAsync(hrm_staffs model)
        {
            if (model.StaffId > 0)
            {
                var item = await _context.hrm_staffs.FindAsync(model.StaffId);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_staffs.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpAssetAsync(int Id)
        {
            var item = await _context.hrm_emp_assets.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpCareerAsync(int Id)
        {
            var item = await _context.hrm_emp_career.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpDependentContactAsync(int Id)
        {
            var item = await _context.hrm_emp_dependent_contact.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpEmergencyContactAsync(int Id)
        {
            var item = await _context.hrm_emp_emergency_contact.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpHmoAsync(int Id)
        {
            var item = await _context.hrm_emp_hmo.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpHobbyAsync(int Id)
        {
            var item = await _context.hrm_emp_hobbies.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpHospitalAsync(int Id)
        {
            var item = await _context.hrm_emp_hospital.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpIdentificationAsync(int Id)
        {
            var item = await _context.hrm_emp_identifications.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpLanguageAsync(int Id)
        {
            var item = await _context.hrm_emp_language.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpProfCertificationAsync(int Id)
        {
            var item = await _context.hrm_emp_prof_certification.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpQualificationAsync(int Id)
        {
            var item = await _context.hrm_emp_qualification.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpRefereeAsync(int Id)
        {
            var item = await _context.hrm_emp_referees.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmpSkillAsync(int Id)
        {
            var item = await _context.hrm_emp_skills.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteHrmStaffAsync(int Id)
        {
            var item = await _context.hrm_staffs.FindAsync(Id);
            if (item != null)
            {
                item.Deleted = true;
                _context.Entry(item).CurrentValues.SetValues(item);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<hrm_emp_assets>> GetAllEmpAssetsAsync()
        {
            return await _context.hrm_emp_assets.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_career>> GetAllEmpCareerAsync()
        {
            return await _context.hrm_emp_career.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_dependent_contact>> GetAllEmpDependentContactAsync()
        {
            return await _context.hrm_emp_dependent_contact.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_emergency_contact>> GetAllEmpEmergencyContactAsync()
        {
            return await _context.hrm_emp_emergency_contact.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_gym>> GetAllEmpGymAsync()
        {
            return await _context.hrm_emp_gym.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_gym_change_request>> GetAllEmpGymChangeRequestAsync()
        {
            return await _context.hrm_emp_gym_change_request.Where(x => x.Deleted == false && x.ApprovalStatus == 2).ToListAsync();
        }

        public async Task<List<hrm_emp_gym_meeting>> GetAllEmpGymMeetingAsync()
        {
            return await _context.hrm_emp_gym_meeting.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_hmo>> GetAllEmpHmoAsync()
        {
            return await _context.hrm_emp_hmo.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_hmo_change_request>> GetAllEmpHmoChangeRequestAsync()
        {
            return await _context.hrm_emp_hmo_change_request.Where(x => x.Deleted == false && x.ApprovalStatus == 2).ToListAsync();
        }

        public async Task<List<hrm_emp_hobbies>> GetAllEmpHobbiesAsync()
        {
            return await _context.hrm_emp_hobbies.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_hospital>> GetAllEmpHospitalAsync()
        {
            return await _context.hrm_emp_hospital.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_hospital_change_request>> GetAllEmpHospitalChangeRequestAsync()
        {
            return await _context.hrm_emp_hospital_change_request.Where(x => x.Deleted == false && x.ApprovalStatus == 2).ToListAsync();
        }

        public async Task<List<hrm_emp_hospital_meeting>> GetAllEmpHospitalMeetingAsync()
        {
            return await _context.hrm_emp_hospital_meeting.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_identification>> GetAllEmpIdentificationAsync()
        {
            return await _context.hrm_emp_identifications.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_language>> GetAllEmpLanguageAsync()
        {
            return await _context.hrm_emp_language.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_prof_certification>> GetAllEmpProfCertificationAsync()
        {
            return await _context.hrm_emp_prof_certification.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_qualification>> GetAllEmpQualificationAsync()
        {
            return await _context.hrm_emp_qualification.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_referees>> GetAllEmpRefereesAsync()
        {
            return await _context.hrm_emp_referees.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_emp_skills>> GetAllEmpSkillsAsync()
        {
            return await _context.hrm_emp_skills.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<List<hrm_staffs>> GetAllHrmStaffAsync()
        {
            return await _context.hrm_staffs.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<hrm_emp_assets> GetEmpAssetByIdAsync(int Id)
        {
            return await _context.hrm_emp_assets.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_assets> GetEmpAssetByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_assets.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_career> GetEmpCareerByIdAsync(int Id)
        {
            return await _context.hrm_emp_career.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_career> GetEmpCareerByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_career.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_emergency_contact> GetEmpEmergencyContactByIdAsync(int Id)
        {
            return await _context.hrm_emp_emergency_contact.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_emergency_contact> GetEmpEmergencyContactByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_emergency_contact.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_dependent_contact> GetEmpEmpDependentContactByIdAsync(int Id)
        {
            return await _context.hrm_emp_dependent_contact.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_dependent_contact> GetEmpEmpDependentContactByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_dependent_contact.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_gym> GetEmpGymByIdAsync(int Id)
        {
            return await _context.hrm_emp_gym.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_gym> GetEmpGymByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_gym.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_hmo> GetEmpHmoByIdAsync(int Id)
        {
            return await _context.hrm_emp_hmo.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_hmo> GetEmpHmoByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_hmo.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_hobbies> GetEmpHobbyByIdAsync(int Id)
        {
            return await _context.hrm_emp_hobbies.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_hobbies> GetEmpHobbyByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_hobbies.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_hospital> GetEmpHospitalByIdAsync(int Id)
        {
            return await _context.hrm_emp_hospital.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_hospital> GetEmpHospitalByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_hospital.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_identification> GetEmpIdentificationByIdAsync(int Id)
        {
            return await _context.hrm_emp_identifications.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_identification> GetEmpIdentificationByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_identifications.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_language> GetEmpLanguageByIdAsync(int Id)
        {
            return await _context.hrm_emp_language.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_language> GetEmpLanguageByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_language.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_prof_certification> GetEmpProfCertificationByIdAsync(int Id)
        {
            return await _context.hrm_emp_prof_certification.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_prof_certification> GetEmpProfCertificationByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_prof_certification.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_qualification> GetEmpQualificationByIdAsync(int Id)
        {
            return await _context.hrm_emp_qualification.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_qualification> GetEmpQualificationByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_qualification.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_referees> GetEmpRefereeByIdAsync(int Id)
        {
            return await _context.hrm_emp_referees.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_referees> GetEmpRefereeByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_referees.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_emp_skills> GetEmpSkillByIdAsync(int Id)
        {
            return await _context.hrm_emp_skills.FirstOrDefaultAsync(x => x.Id == Id && x.Deleted == false);
        }

        public async Task<hrm_emp_skills> GetEmpSkillByStaffIdAsync(int staffId)
        {
            return await _context.hrm_emp_skills.FirstOrDefaultAsync(x => x.StaffId == staffId && x.Deleted == false);
        }

        public async Task<hrm_staffs> GetHrmStaffByIdAsync(int Id)
        {
            return await _context.hrm_staffs.FirstOrDefaultAsync(x => x.StaffId == Id && x.Deleted == false);
        }
    }
}
