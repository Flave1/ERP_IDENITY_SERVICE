using APIGateway.ActivityRequirement;
using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.Handlers.Hrm.setup.academic_discipline;
using APIGateway.Handlers.Hrm.setup.academic_grade;
using APIGateway.Handlers.Hrm.setup.academic_qualification;
using APIGateway.Handlers.Hrm.setup.employmenttype;
using APIGateway.Handlers.Hrm.setup.employmetlevel;
using APIGateway.Handlers.Hrm.setup.gym_workouts;
using APIGateway.Handlers.Hrm.setup.high_school_grade;
using APIGateway.Handlers.Hrm.setup.high_school_subjects;
using APIGateway.Handlers.Hrm.setup.hmo;
using APIGateway.Handlers.Hrm.setup.hospital_management;
using APIGateway.Handlers.Hrm.setup.jobdetail;
using APIGateway.Handlers.Hrm.setup.jobgrade;
using APIGateway.Handlers.Hrm.setup.languages;
using APIGateway.Handlers.Hrm.setup.location;
using APIGateway.Handlers.Hrm.setup.proffesional_membership;
using APIGateway.Handlers.Hrm.setup.proffessional_certification;
using APIGateway.Handlers.Hrm.setup.sub_skill;
using GODPAPIs.Contracts.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIGateway.Controllers.V1.hrm
{
    [ERPAuthorize]
    public class Hrm_setupController : Controller
    {
        private readonly IMediator _mediator;
        public Hrm_setupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region academic_discipline 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_ACADEMIC_DISCPLINE)]
        public async Task<IActionResult> ADD_UPDATE_ACADEMIC_DISCPLINE([FromBody] hrm_setup_academic_discipline_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_ACADEMIC_DISCPLINE)]
        public async Task<IActionResult> DELETE_ACADEMIC_DISCPLINE([FromBody] Deletehrm_setup_academic_discipline command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_ACADEMIC_DISCPLINE)]
        public async Task<IActionResult> GET_ALL_ACADEMIC_DISCPLINE()
        {
            var query = new GetAll_hrm_setup_academic_discipline_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_ACADEMIC_DISCPLINE)]
        public async Task<IActionResult> GET_SINGLE_ACADEMIC_DISCPLINE([FromQuery] GetSingle_hrm_setup_academic_discipline_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_ACADEMIC_DISCPLINE)]
        public async Task<IActionResult> DOWNLOAD_ACADEMIC_DISCIPLINE()
        {
            var query = new DownloadAcademicDisciplineQuery();
            return Ok(await _mediator.Send(query));
        }
      
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_ACADEMIC_DISCIPLINE)]
        public async Task<IActionResult> UPLOAD_ACADEMIC_DISCIPLINE()
        {
            var query = new UploadAcademicDisciplineCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }




        #endregion

        #region academic_grade 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_ACADEMIC_GRADES)]
        public async Task<IActionResult> ADD_UPDATE_ACADEMIC_GRADES([FromBody] hrm_setup_academic_grade_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_ACADEMIC_GRADES)]
        public async Task<IActionResult> DELETE_ACADEMIC_GRADES([FromBody] Deletehrm_setup_academic_grade command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_ACADEMIC_GRADES)]
        public async Task<IActionResult> GET_ALL_ACADEMIC_GRADES()
        {
            var query = new GetAll_hrm_setup_academic_grade_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_ACADEMIC_GRADES)]
        public async Task<IActionResult> GET_SINGLE_ACADEMIC_GRADES([FromQuery] GetSingle_hrm_setup_academic_grade_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_ACADEMIC_GRADES)]
        public async Task<IActionResult> DOWNLOAD_ACADEMIC_GRADES()
        {
            var query = new DownloadAcademicGradeQuery();
            return Ok(await _mediator.Send(query));
        }
        
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_ACADEMIC_GRADE)]
        public async Task<IActionResult> UPLOAD_ACADEMIC_GRADE()
        {
            var query = new UploadAcademicGradeCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        #endregion

        #region academic_qualification 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_ACADEMIC_QUALIFICATION)]
        public async Task<IActionResult> ADD_UPDATE_ACADEMIC_QUALIFICATION([FromBody] hrm_setup_academic_qualification_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_ACADEMIC_QUALIFICATION)]
        public async Task<IActionResult> DELETE_ACADEMIC_QUALIFICATION([FromBody] Deletehrm_setup_academic_qualification command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_ACADEMIC_QUALIFICATION)]
        public async Task<IActionResult> GET_ALL_ACADEMIC_QUALIFICATION()
        {
            var query = new GetAll_hrm_setup_academic_qualification_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_ACADEMIC_QUALIFICATION)]
        public async Task<IActionResult> GET_SINGLE_ACADEMIC_QUALIFICATION([FromQuery] GetSingle_hrm_setup_academic_qualification_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_ACADEMIC_QUALIFICATIONS)]
        public async Task<IActionResult> DOWNLOAD_ACADEMIC_QUALIFICATIONS()
        {
            var query = new DownloadAcademicQualificationQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_ACADEMIC_QUALIFICATION)]
        public async Task<IActionResult> UPLOAD_ACADEMIC_QUALIFICATION()
        {
            var query = new UploadAcademicQualificationCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region employmenttype 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_EMPLYMENT_TYPE)]
        public async Task<IActionResult> ADD_UPDATE_EMPLYMENT_TYPE([FromBody] hrm_setup_employmenttype_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_EMPLYMENT_TYPE)]
        public async Task<IActionResult> DELETE_EMPLYMENT_TYPE([FromBody] Deletehrm_setup_employmenttype command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_EMPLYMENT_TYPE)]
        public async Task<IActionResult> GET_ALL_EMPLYMENT_TYPE()
        {
            var query = new GetAll_hrm_setup_employmenttype_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_EMPLYMENT_TYPE)]
        public async Task<IActionResult> GET_SINGLE_EMPLYMENT_TYPE([FromQuery] GetSingle_hrm_setup_employmenttype_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_EMPLOYMENT_TYPE)]
        public async Task<IActionResult> DOWNLOAD_EMPLOYMENT_TYPE()
        {
            var query = new DownloadEmploymentTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_EMPLOYMENT_TYPE)]
        public async Task<IActionResult> UPLOAD_EMPLOYMENT_TYPE()
        {
            var query = new UploadEmploymentTypeCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region employmetlevel 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_EMPLYMENT_LEVEL)]
        public async Task<IActionResult> ADD_UPDATE_EMPLYMENT_LEVEL([FromBody] hrm_setup_employmentlevel_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_EMPLYMENT_LEVEL)]
        public async Task<IActionResult> DELETE_EMPLYMENT_LEVEL([FromBody] Deletehrm_setup_employmentlevel command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_EMPLYMENT_LEVEL)]
        public async Task<IActionResult> GET_ALL_EMPLYMENT_LEVEL()
        {
            var query = new GetAll_hrm_setup_employmentlevel_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_EMPLYMENT_LEVEL)]
        public async Task<IActionResult> GET_SINGLE_EMPLYMENT_LEVEL([FromQuery] GetSingle_hrm_setup_employmentlevel_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_EMPLOYMENT_LEVEL)]
        public async Task<IActionResult> DOWNLOAD_EMPLOYMENT_LEVEL()
        {
            var query = new DownloadEmploymentLevelQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_EMPLOYMENT_LEVEL)]
        public async Task<IActionResult> UPLOAD_EMPLOYMENT_LEVEL()
        {
            var query = new UploadEmploymentLevelCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region gym_workouts 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_GYM_WORKOUT)]
        public async Task<IActionResult> ADD_UPDATE_GYM_WORKOUT([FromBody] hrm_setup_gym_workouts_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_GYM_WORKOUT)]
        public async Task<IActionResult> DELETE_GYM_WORKOUT([FromBody] Deletehrm_setup_gym_workouts command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_GYM_WORKOUT)]
        public async Task<IActionResult> GET_ALL_GYM_WORKOUT()
        {
            var query = new GetAll_hrm_setup_gym_workouts_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_GYM_WORKOUT)]
        public async Task<IActionResult> GET_SINGLE_GYM_WORKOUT([FromQuery] GetSingle_hrm_setup_gym_workouts_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_GYM_WORKOUT)]
        public async Task<IActionResult> DOWNLOAD_GYM_WORKOUT()
        {
            var query = new DownloadGymWorkoutQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_GYM_WORKOUT)]
        public async Task<IActionResult> UPLOAD_GYM_WORKOUT()
        {
            var query = new UploadGymWorkoutCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region high_school_grade 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_HIGH_SCHOOL_GRADE)]
        public async Task<IActionResult> ADD_UPDATE_HIGH_SCHOOL_GRADE([FromBody] hrm_setup_high_school_grade_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_HIGH_SCHOOL_GRADE)]
        public async Task<IActionResult> DELETE_HIGH_SCHOOL_GRADE([FromBody] Deletehrm_setup_high_school_grade command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_HIGH_SCHOOL_GRADE)]
        public async Task<IActionResult> GET_ALL_HIGH_SCHOOL_GRADE()
        {
            var query = new GetAll_hrm_setup_high_school_grade_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_HIGH_SCHOOL_GRADE)]
        public async Task<IActionResult> GET_SINGLE_HIGH_SCHOOL_GRADE([FromQuery] GetSingle_hrm_setup_high_school_grade_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_HIGH_SCHOOL_GRADE)]
        public async Task<IActionResult> DOWNLOAD_HIGH_SCHOOL_GRADE()
        {
            var query = new DownloadHighSchoolGradeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_HIGH_SCHOOL_GRADE)]
        public async Task<IActionResult> UPLOAD_HIGH_SCHOOL_GRADE()
        {
            var query = new UploadHighSchoolGradesCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region high_school_subjects 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_HIGH_SCHOOL_SUBJECT)]
        public async Task<IActionResult> ADD_UPDATE_HIGH_SCHOOL_SUBJECT([FromBody] hrm_setup_high_school_subjects_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_HIGH_SCHOOL_SUBJECT)]
        public async Task<IActionResult> DELETE_HIGH_SCHOOL_SUBJECT([FromBody] Deletehrm_setup_high_school_subjects command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_HIGH_SCHOOL_SUBJECT)]
        public async Task<IActionResult> GET_ALL_HIGH_SCHOOL_SUBJECT()
        {
            var query = new GetAll_hrm_setup_high_school_subjects_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_HIGH_SCHOOL_SUBJECT)]
        public async Task<IActionResult> GET_SINGLE_HIGH_SCHOOL_SUBJECT([FromQuery] GetSingle_hrm_setup_high_school_subjects_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_HIGH_SCHOOL_SUBJECT)]
        public async Task<IActionResult> DOWNLOAD_HIGH_SCHOOL_SUBJECTS()
        {
            var query = new DownloadHighSchoolSubjectsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_HIGH_SCHOOL_SUBJECT)]
        public async Task<IActionResult> UPLOAD_HIGH_SCHOOL_SUBJECT()
        {
            var query = new UploadHighSchoolSubjectCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region hmo 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_HMO)]
        public async Task<IActionResult> ADD_UPDATE_HMO([FromBody] hrm_setup_hmo_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_HMO)]
        public async Task<IActionResult> DELETE_HMO([FromBody] Deletehrm_setup_hmo command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_HMO)]
        public async Task<IActionResult> GET_ALL_HMO()
        {
            var query = new GetAll_hrm_setup_hmo_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_HMO)]
        public async Task<IActionResult> GET_SINGLE_HMO([FromQuery] GetSingle_hrm_setup_hmo_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_HMO)]
        public async Task<IActionResult> DOWNLOAD_HMO()
        {
            var query = new DownloadHMOQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_HMO)]
        public async Task<IActionResult> UPLOAD_HMO()
        {
            var query = new UploadHMOCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        #endregion

        #region jobtitle
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_JOB_TITLE)]
        public async Task<IActionResult> ADD_UPDATE_JOB_TITLE([FromBody] hrm_setup_jobtitle_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_JOB_TITLE)]
        public async Task<IActionResult> DELETE_JOB_TITLE([FromBody] Deletehrm_setup_jobtitle command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_JOB_TITLE)]
        public async Task<IActionResult> GET_ALL_JOB_TITLE()
        {
            var query = new GetAll_hrm_setup_jobtitle_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_JOB_TITLE)]
        public async Task<IActionResult> GET_SINGLE_JOB_TITLE([FromQuery] GetSingle_hrm_setup_jobtitle_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_JOB_TITLE)]
        public async Task<IActionResult> DOWNLOAD_JOB_TITLE()
        {
            var query = new DownloadJobTitleQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_JOB_TITLE)]
        public async Task<IActionResult> UPLOAD_JOB_TITLE()
        {
            var query = new UploadJobTitleCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region job grade 
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_JOB_GRADE)]
        public async Task<IActionResult> ADD_UPDATE_JOB_GRADE([FromBody] hrm_setup_jobgrade_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_JOB_GRADE)]
        public async Task<IActionResult> DELETE_JOB_GRADE([FromBody] Deletehrm_setup_jobgrade command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_JOB_GRADE)]
        public async Task<IActionResult> GET_ALL_JOB_GRADE()
        {
            var query = new GetAll_hrm_setup_jobgrade_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_JOB_GRADE)]
        public async Task<IActionResult> GET_SINGLE_JOB_GRADE([FromQuery] GetSingle_hrm_setup_jobgrade_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_JOB_GRADE)]
        public async Task<IActionResult> DOWNLOAD_JOBGRADE()
        {
            var query = new DownloadJobGradeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_JOB_GRADE)]
        public async Task<IActionResult> UPLOAD_JOBGRADE()
        {
            var query = new UploadJobGradeCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }




        #endregion

        #region languages
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_LANGUAGE)]
        public async Task<IActionResult> ADD_UPDATE_LANGUAGE([FromBody] hrm_setup_languages_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_LANGUAGE)]
        public async Task<IActionResult> DELETE_LANGUAGE([FromBody] Deletehrm_setup_languages command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_LANGUAGE)]
        public async Task<IActionResult> GET_ALL_LANGUAGE()
        {
            var query = new GetAll_hrm_setup_languages_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_LANGUAGE)]
        public async Task<IActionResult> GET_SINGLE_LANGUAGE([FromQuery] GetSingle_hrm_setup_languages_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_LANGUAGE)]
        public async Task<IActionResult> DOWNLOAD_LANGUAGE()
        {
            var query = new DownloadLanguagesQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_LANGUAGE)]
        public async Task<IActionResult> UPLOAD_LANGUAGE()
        {
            var query = new UploadLanguagesCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        #endregion

        #region professional membership
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_PROF_MEMBERSHIP)]
        public async Task<IActionResult> ADD_UPDATE_PROF_MEMBERSHIP([FromBody] hrm_setup_proffesional_membership_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_PROF_MEMBERSHIP)]
        public async Task<IActionResult> DELETE_PROF_MEMBERSHIP([FromBody] Deletehrm_setup_proffesional_membership command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_PROF_MEMBERSHIP)]
        public async Task<IActionResult> GET_ALL_PROF_MEMBERSHIP()
        {
            var query = new GetAll_hrm_setup_proffesional_membership_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_PROF_MEMBERSHIP)]
        public async Task<IActionResult> GET_SINGLE_PROF_MEMBERSHIP([FromQuery] GetSingle_hrm_setup_proffesional_membership_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_PROF_MEMBERSHIP)]
        public async Task<IActionResult> DOWNLOAD_PROF_MEMBERSHIP()
        {
            var query = new DownloadProf_MembershipQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_PROF_MEMBERSHIP)]
        public async Task<IActionResult> UPLOAD_PROF_MEMBERSHIP()
        {
            var query = new UploadProf_MembershipCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region professional certification
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_PROF_CERTIFICATION)]
        public async Task<IActionResult> ADD_UPDATE_PROF_CERTIFICATION([FromBody] hrm_setup_proffessional_certification_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_PROF_CERTIFICATION)]
        public async Task<IActionResult> DELETE_PROF_CERTIFICATION([FromBody] Deletehrm_setup_proffessional_certification command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_PROF_CERTIFICATION)]
        public async Task<IActionResult> GET_ALL_PROF_CERTIFICATION()
        {
            var query = new GetAll_hrm_setup_proffessional_certification_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_PROF_CERTIFICATION)]
        public async Task<IActionResult> GET_SINGLE_PROF_CERTIFICATION([FromQuery] GetSingle_hrm_setup_proffessional_certification_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_PROF_CERTIFICATION)]
        public async Task<IActionResult> DOWNLOAD_PROF_CERTIFICATION()
        {
            var query = new DownloadProf_CertificationQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_PROF_CERTIFICATION)]
        public async Task<IActionResult> UPLOAD_PROF_CERTIFICATION()
        {
            var query = new UploadProfCertificationCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }


        #endregion

        #region job_skill
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_JOB_SKILL)]
        public async Task<IActionResult> ADD_UPDATE_JOB_SKILL([FromBody] hrm_setup_sub_skill_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_JOB_SKILL)]
        public async Task<IActionResult> DELETE_JOB_SKILL([FromBody] Deletehrm_setup_sub_skill command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_JOB_SKILL)]
        public async Task<IActionResult> GET_ALL_SUB_SKILL()
        {
            var query = new GetAll_hrm_setup_subskill_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_JOB_SKILL)]
        public async Task<IActionResult> GET_SINGLE_SUB_SKILL([FromQuery] GetSingle_hrm_setup_sub_skill_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_JOB_SKILL)]
        public async Task<IActionResult> UPLOAD_SUB_SKILL()
        {
            var query = new UploadSubSkillCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_JOB_SKILL)]
        public async Task<IActionResult> DOWNLOAD_SUB_SKILL([FromQuery] DownloadSubSkillQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        #endregion

        #region location
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_LOCATION)]
        public async Task<IActionResult> ADD_UPDATE_LOCATION([FromBody] hrm_setup_location_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_LOCATION)]
        public async Task<IActionResult> DELETE_LOCATION([FromBody] Deletehrm_setup_location command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_LOCATION)]
        public async Task<IActionResult> GET_ALL_LOCATION()
        {
            var query = new GetAllSetup_Location_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_LOCATION)]
        public async Task<IActionResult> GET_SINGLE_LOCATION([FromQuery] GetSingleSetupLocation_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_LOCATION)]
        public async Task<IActionResult> UPLOAD_LOCATION()
        {
            var query = new UploadLocationCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_LOCATION)]
        public async Task<IActionResult> DOWNLOAD_LOCATION()
        {
            var query = new DownloadLocationQuery();
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region hospital_management
        [HttpPost(ApiRoutes.Hrm_setup_endpoints.ADD_UPDATE_HOSPITAL_MANAGEMENT)]
        public async Task<IActionResult> ADD_UPDATE_HOSPITAL_MANAGEMENT([FromBody] hrm_setup_hospital_management_contract command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.DELETE_HOSPITAL_MANAGEMENT)]
        public async Task<IActionResult> DELETE_LOCATION([FromBody] Deletehrm_setup_hospital_managementCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_ALL_HOSPITAL_MANAGEMENT)]
        public async Task<IActionResult> GET_ALL_HOSPITAL_MANAGEMENT()
        {
            var query = new GetAllHospitalManagement_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.GET_SINGLE_HOSPITAL_MANAGEMENT)]
        public async Task<IActionResult> GET_SINGLE_HOSPITAL_MANAGEMENT([FromQuery] GetSingleHospitalManagement_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.Hrm_setup_endpoints.UPLOAD_HOSPITAL_MANAGEMENT)]
        public async Task<IActionResult> UPLOAD_HOSPITAL_MANAGEMENT()
        {
            var query = new UploadHospitalManagementCommand();
            var res = await _mediator.Send(query);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.Hrm_setup_endpoints.DOWNLOAD_HOSPITAL_MANAGEMENT)]
        public async Task<IActionResult> DOWNLOAD_HOSPITAL_MANAGEMENT()
        {
            var query = new DownloadHospitalManagementQuery();
            return Ok(await _mediator.Send(query));
        }
        #endregion

    }
}
