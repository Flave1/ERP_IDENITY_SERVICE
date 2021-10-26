using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Setup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Repository.Inplimentation.Setup
{
    public class SetupRepository : ISetupRepository
    {
        private readonly DataContext _context;

        public SetupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUpdateAcademicDisciplineAsync(hrm_setup_academic_discipline model)
        {

            if (model.Id == 0) await _context.hrm_setup_academic_discipline.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateAcademicGradeAsync(hrm_setup_academic_grade model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_academic_grade.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_academic_grade.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateAcademicQualificationAsync(hrm_setup_academic_qualification model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_academic_qualification.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_academic_qualification.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmploymentTypeAsync(hrm_setup_employmenttype model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_employmenttype.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_employmenttype.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateEmploymentLevelAsync(hrm_setup_employmentlevel model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_employmentlevel.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_employmentlevel.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<hrm_setup_academic_discipline>> GetAllAcademicDisciplineAsync()
        {
            return await _context.hrm_setup_academic_discipline.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<hrm_setup_academic_grade>> GetAllAcademicGradeAsync()
        {
            return await _context.hrm_setup_academic_grade.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<hrm_setup_academic_qualification>> GetAllAcademicQualificationAsync()
        {
            return await _context.hrm_setup_academic_qualification.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<hrm_setup_employmentlevel>> GetAllEmploymentLevelAsync()
        {
            return await _context.hrm_setup_employmentlevel.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<hrm_setup_employmenttype>> GetAllEmploymentTypeAsync()
        {
            return await _context.hrm_setup_employmenttype.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<hrm_setup_gym_workouts>> GetAllGymWorkoutAsync()
        {
            return await _context.hrm_setup_gym_workouts.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateGymWorkoutAsync(hrm_setup_gym_workouts model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_gym_workouts.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_gym_workouts.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_high_school_grade>> GetAllHighSchoolGradesAsync()
        {
            return await _context.hrm_setup_high_school_grades.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateHighSchoolGradeAsync(hrm_setup_high_school_grade model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_high_school_grades.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_high_school_grades.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_high_school_subjects>> GetAllHighSchoolSubjectsAsync()
        {
            return await _context.hrm_setup_high_school_subjects.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateHighSchoolSubjectsAsync(hrm_setup_high_school_subjects model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_high_school_subjects.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_high_school_subjects.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_hmo>> GetAllHMOAsync()
        {
            return await _context.hrm_setup_hmo.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateHMOAsync(hrm_setup_hmo model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_hmo.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_hmo.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_jobtitle>> GetAllJobTitleAsync()
        {
            return await _context.hrm_setup_jobtitle.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateJobTitleAsync(hrm_setup_jobtitle model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_jobtitle.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_jobtitle.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_jobgrade>> GetAllJobGradesAsync()
        {
            return await _context.hrm_setup_jobgrade.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateJobGradeAsync(hrm_setup_jobgrade model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_jobgrade.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_jobgrade.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_languages>> GetAllLanguagesAsync()
        {
            return await _context.hrm_setup_languages.Where(x => x.Deleted == false).ToListAsync();
        }


        public async Task<bool> AddUpdateLanguageAsync(hrm_setup_languages model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_languages.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_languages.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_proffesional_membership>> GetAllProfMembershipsAsync()
        {
            return await _context.hrm_setup_proffesional_membership.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateProfMembershipAsync(hrm_setup_proffesional_membership model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_proffesional_membership.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_proffesional_membership.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_proffessional_certification>> GetAllProfCertificationsAsync()
        {
            return await _context.hrm_setup_proffessional_certification.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateProfCertificationAsync(hrm_setup_proffessional_certification model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_proffessional_certification.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_proffessional_certification.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddUpdateJobSkillsAsync(hrm_setup_sub_skill model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_sub_skill.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_sub_skill.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_sub_skill>> GetAllJobSkillsAsync()
        {
            return await _context.hrm_setup_sub_skill.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<IEnumerable<hrm_setup_hospital_management>> GetAllHospitalManagementsAsync()
        {
            return await _context.hrm_setup_hospital_management.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateHospitalManagementAsync(hrm_setup_hospital_management model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_hospital_management.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_hospital_management.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<hrm_setup_location>> GetAllLocationsAsync()
        {
            return await _context.hrm_setup_location.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<bool> AddUpdateLocationAsync(hrm_setup_location model)
        {
            if (model.Id > 0)
            {
                var item = await _context.hrm_setup_location.FindAsync(model.Id);
                _context.Entry(item).CurrentValues.SetValues(model);
            }
            else
                await _context.hrm_setup_location.AddAsync(model);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
