using APIGateway.ActivityRequirement;
using APIGateway.Contracts.Commands.hrm.employee;
using APIGateway.Contracts.Response.HRM;
using APIGateway.Contracts.V1;
using APIGateway.Handlers.Hrm.Employee.emp_assets;
using APIGateway.Handlers.Hrm.Employee.emp_career;
using APIGateway.Handlers.Hrm.Employee.emp_dependent_contact;
using APIGateway.Handlers.Hrm.Employee.emp_emergency_contact;
using APIGateway.Handlers.Hrm.Employee.emp_gym;
using APIGateway.Handlers.Hrm.Employee.emp_hmo;
using APIGateway.Handlers.Hrm.Employee.emp_hobbies;
using APIGateway.Handlers.Hrm.Employee.emp_hospital;
using APIGateway.Handlers.Hrm.Employee.emp_identification;
using APIGateway.Handlers.Hrm.Employee.emp_language;
using APIGateway.Handlers.Hrm.Employee.emp_prof_certification;
using APIGateway.Handlers.Hrm.Employee.emp_qualification;
using APIGateway.Handlers.Hrm.Employee.emp_referees;
using APIGateway.Handlers.Hrm.Employee.emp_skills;
using APIGateway.Handlers.Hrm.Employee.hrm_staff;
using APIGateway.Repository.Inplimentation.Cache;
using GODPAPIs.Contracts.V1;
using GOSLibraries.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers.V1.hrm
{
    public class Hrm_employeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IResponseCacheService _cacheService;

        public Hrm_employeeController(IMediator mediator, IResponseCacheService cacheService)
        {
            _mediator = mediator;
            _cacheService = cacheService;
        }

        #region emp_Identification
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_IDENTIFICATION)]
        public async Task<IActionResult> GET_ALL_EMP_IDENTIFICATION()
        {
            var query = new GetAllEmp_Identification_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_IDENTIFICATION)]
        public async Task<IActionResult> ADD_UPDATE_EMP_IDENTIFICATION([FromForm] hrm_emp_Identification_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_IDENTIFICATION)]
        public async Task<IActionResult> DeleteEmployeeIdentification([FromBody] DeleteEmp_IdentificationCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_IDENTIFICATION)]
        public async Task<IActionResult> GET_SINGLE_EMP_IDENTIFICATION([FromQuery] GetSingleEmpIdentification_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_IDENTIFICATION_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_IDENTIFICATION_BY_STAFFID([FromQuery] GetSingleEmpIdentificationByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_IDENTIFICATION_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_IDENTIFICATION_BY_ID([FromQuery] Download_hrm_emp_identificationById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_emergency_contact
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_EMERGENCY_CONTACT)]
        public async Task<IActionResult> ADD_UPDATE_EMP_EMERGENCY_CONTACT([FromBody] hrm_emp_emergency_contact_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_EMERGENCY_CONTACT)]
        public async Task<IActionResult> GET_ALL_EMP_EMERGENCY_CONTACT()
        {
            var query = new GetAllEmp_Emergency_Contact_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_EMERGENCY_CONTACT)]
        public async Task<IActionResult> DeleteEmployeeEmergencyContact([FromBody] DeleteEmp_EmergencyContactCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_EMERGENCY_CONTACT)]
        public async Task<IActionResult> GET_SINGLE_EMP_EMERGENCY_CONTACT([FromQuery] GetSingleEmpEmergencyContact_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_EMERGENCY_CONTACT_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_EMERGENCY_CONTACT_BY_STAFFID([FromQuery] GetSingleEmpEmergencyContactByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_dependent_contact
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_DEPENDENT_CONTACT)]
        public async Task<IActionResult> ADD_UPDATE_EMP_DEPENDENT_CONTACT([FromBody] hrm_emp_dependent_contact_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_DEPENDENT_CONTACT)]
        public async Task<IActionResult> GET_ALL_EMP_DEPENDENT_CONTACT()
        {
            var query = new GetAllEmp_Dependent_Contact_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_DEPENDENT_CONTACT)]
        public async Task<IActionResult> DeleteEmpDependentContact([FromBody] DeleteEmp_DependentContactCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_DEPENDENT_CONTACT)]
        public async Task<IActionResult> GET_SINGLE_EMP_DEPENDENT_CONTACT([FromQuery] GetSingleEmpDependentContact_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_DEPENDENT_CONTACT_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_DEPENDENT_CONTACT_BY_STAFFID([FromQuery] GetSingleEmpDependentContactByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        #endregion

        #region emp_language
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_LANGUAGE)]
        public async Task<IActionResult> ADD_UPDATE_EMP_LANGUAGE([FromBody] hrm_emp_language_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_LANGUAGE)]
        public async Task<IActionResult> GET_ALL_EMP_LANGUAGE()
        {
            var query = new GetAllEmp_Language_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_LANGUAGE)]
        public async Task<IActionResult> DeleteEmpLanguage([FromBody] DeleteEmp_LanguageCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_LANGUAGE)]
        public async Task<IActionResult> GET_SINGLE_EMP_LANGUAGE([FromQuery] GetSingleEmpLanguage_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_LANGUAGE_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_LANGUAGE_BY_STAFFID([FromQuery] GetSingleEmpLanguageByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_career
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_CAREER)]
        public async Task<IActionResult> ADD_UPDATE_EMP_CAREER([FromBody] hrm_emp_career_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_CAREER)]
        public async Task<IActionResult> GET_ALL_EMP_CAREER()
        {
            var query = new GetAllEmp_Career_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_CAREER)]
        public async Task<IActionResult> DELETE_EMP_CAREER([FromBody] DeleteEmp_CareerCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_CAREER)]
        public async Task<IActionResult> GET_SINGLE_EMP_CAREER([FromQuery] GetSingleEmpCareer_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_CAREER_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_CAREER_BY_STAFFID([FromQuery] GetSingleEmpCareerByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_hobby
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_HOBBY)]
        public async Task<IActionResult> ADD_UPDATE_EMP_HOBBY([FromBody] hrm_emp_hobbies_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_HOBBY)]
        public async Task<IActionResult> GET_ALL_EMP_HOBBY()
        {
            var query = new GetAllEmp_Hobbies_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_HOBBY)]
        public async Task<IActionResult> DELETE_EMP_HOBBY([FromBody] DeleteEmp_HobbiesCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_HOBBY)]
        public async Task<IActionResult> GET_SINGLE_EMP_HOBBY([FromQuery] GetSingleEmpHobby_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_HOBBY_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_HOBBY_BY_STAFFID([FromQuery] GetSingleEmpHobbyByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }

        #endregion

        #region emp_referee
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_REFEREE)]
        public async Task<IActionResult> ADD_UPDATE_EMP_REFEREE([FromForm] hrm_emp_referees_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_REFEREES)]
        public async Task<IActionResult> GET_ALL_EMP_REFEREES()
        {
            var query = new GetAllEmp_Referees_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_REFEREE)]
        public async Task<IActionResult> DELETE_EMP_REFEREE([FromBody] DeleteEmp_RefereeCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_REFEREE)]
        public async Task<IActionResult> GET_SINGLE_EMP_REFEREE([FromQuery] GetSingleEmpReferee_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_REFEREE_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_REFEREE_BY_STAFFID([FromQuery] GetSingleEmpRefereeByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_REFEREES_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_REFEREE_BY_ID([FromQuery] Download_hrm_emp_refereeById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_assets
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_ASSET)]
        public async Task<IActionResult> ADD_UPDATE_EMP_ASSET([FromBody] hrm_emp_assets_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_ASSETS)]
        public async Task<IActionResult> GET_ALL_EMP_ASSETS()
        {
            var query = new GetAllEmp_Assets_Query();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_ASSET)]
        public async Task<IActionResult> DELETE_EMP_ASSET([FromBody] DeleteEmp_AssetCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_ASSET)]
        public async Task<IActionResult> GET_SINGLE_EMP_ASSET([FromQuery] GetSingleEmpAsset_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_ASSET_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_ASSET_BY_STAFFID([FromQuery] GetSingleEmpAssetByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region Emp_prof_certification
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_PROF_CERTIFICATION)]
        public async Task<IActionResult> ADD_UPDATE_EMP_PROF_CERTIFICATION([FromForm] hrm_emp_prof_certification_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_PROF_CERTIFICATION)]
        public async Task<IActionResult> GET_ALL_EMP_PROF_CERTIFICATION()
        {
            var query = new GetAllEmp_Prof_Certification_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_PROF_CERTIFICATION)]
        public async Task<IActionResult> GET_SINGLE_EMP_PROF_CERTIFICATION([FromQuery] GetSingleEmpProfCertification_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_PROF_CERTIFICATION)]
        public async Task<IActionResult> DELETE_EMP_PROF_CERTIFICATION([FromBody] DeleteEmp_ProfCertificationCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_PROF_CERTIFICATION_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_PROF_CERTIFICATION_BY_STAFFID([FromQuery] GetSingleEmpProfCertificationByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_PROF_CERTIFICATION_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_PROF_CERTIFICATION_BY_ID([FromQuery] Download_hrm_emp_profCertificationById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_qualification

        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_QUALIFICATION)]
        public async Task<IActionResult> ADD_UPDATE_EMP_QUALIFICATION([FromForm] hrm_emp_qualification_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_QUALIFICATION)]
        public async Task<IActionResult> GET_ALL_EMP_QUALIFICATION()
        {
            var query = new GetAllEmp_Qualification_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_QUALIFICATION)]
        public async Task<IActionResult> GET_SINGLE_EMP_QUALIFICATION([FromQuery] GetSingleEmpQualification_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_QUALIFICATION)]
        public async Task<IActionResult> DELETE_EMP_QUALIFICATION([FromBody] DeleteEmp_QualificationCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_QUALIFICATION_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_QUALIFICATION_BY_STAFFID([FromQuery] GetSingleEmpQualificationByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_QUALIFICATION_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_QUALIFICATION_BY_ID([FromQuery] Download_hrm_emp_qualificationById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_hmo
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_HMO)]
        public async Task<IActionResult> ADD_UPDATE_EMP_HMO([FromBody] hrm_emp_hmo_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_HMO)]
        public async Task<IActionResult> GET_ALL_EMP_HMO()
        {
            var query = new GetAllEmp_Hmo_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_HMO)]
        public async Task<IActionResult> GET_SINGLE_EMP_HMO([FromQuery] GetSingleEmpHmo_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_HMO)]
        public async Task<IActionResult> DELETE_EMP_HMO([FromBody] DeleteEmp_HmoCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_HMO_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_HMO_BY_STAFFID([FromQuery] GetSingleEmpHmoByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_HMO_REQUEST)]
        public async Task<IActionResult> ADD_UPDATE_EMP_HMO_REQUEST([FromForm] hrm_emp_hmo_change_request_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_HMO_REQUEST)]
        public async Task<IActionResult> GET_ALL_EMP_HMO_REQUEST()
        {
            var query = new GetAllEmp_Hmo_Change_Request_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_HMO_REQUEST_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_HMO_REQUEST_BY_ID([FromQuery] Download_hrm_emp_HmoChangeRequestById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_hospital
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_HOSPITAL)]
        public async Task<IActionResult> ADD_UPDATE_EMP_HOSPITAL([FromBody] hrm_emp_hospital_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_HOSPITAL)]
        public async Task<IActionResult> GET_ALL_EMP_HOSPITAL()
        {
            var query = new GetAllEmp_Hospital_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_HOSPITAL)]
        public async Task<IActionResult> GET_SINGLE_EMP_HOSPITAL([FromQuery] GetSingleEmpHospital_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_HOSPITAL)]
        public async Task<IActionResult> DELETE_EMP_HOSPITAL([FromBody] DeleteEmp_HospitalCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_HOSPITAL_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_HOSPITAL_BY_STAFFID([FromQuery] GetSingleEmpHospitalByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_HOSPITAL_REQUEST)]
        public async Task<IActionResult> ADD_UPDATE_EMP_HOSPITAL_REQUEST([FromForm] hrm_emp_hospital_change_request_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_HOSPITAL_REQUEST)]
        public async Task<IActionResult> GET_ALL_EMP_HOSPITAL_REQUEST()
        {
            var query = new GetAllEmp_Hospital_Change_Request_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_HOSPITAL_MEETING)]
        public async Task<IActionResult> ADD_UPDATE_EMP_HOSPITAL_MEETING([FromForm] hrm_emp_hospital_meeting_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_HOSPITAL_MEETING)]
        public async Task<IActionResult> GET_ALL_EMP_HOSPITAL_MEETING()
        {
            var query = new GetAllEmp_Hospital_Meeting_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_HOSPITAL_REQUEST_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_HOSPITAL_REQUEST_BY_ID([FromQuery] Download_hrm_emp_hospitalRequestById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_HOSPITAL_MEETING_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_HOSPITAL_MEETING_BY_ID([FromQuery] Download_hrm_emp_hospitalMeetingById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_gym
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_GYM)]
        public async Task<IActionResult> ADD_UPDATE_EMP_GYM([FromBody] hrm_emp_gym_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_GYM)]
        public async Task<IActionResult> GET_ALL_EMP_GYM()
        {
            var query = new GetAllEmp_Gym_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_GYM)]
        public async Task<IActionResult> GET_SINGLE_EMP_GYM([FromQuery] GetSingleEmpGym_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_GYM_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_GYM_BY_STAFFID([FromQuery] GetSingleEmpGymByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_GYM_REQUEST)]
        public async Task<IActionResult> ADD_UPDATE_EMP_GYM_REQUEST([FromForm] hrm_emp_gym_change_request_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_GYM_REQUEST)]
        public async Task<IActionResult> GET_ALL_EMP_GYM_REQUEST()
        {
            var query = new GetAllEmp_Gym_Change_Request_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_GYM_MEETING)]
        public async Task<IActionResult> ADD_UPDATE_EMP_Gym_MEETING([FromForm] hrm_emp_gym_meeting_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_GYM_MEETING)]
        public async Task<IActionResult> GET_ALL_EMP_GYM_MEETING()
        {
            var query = new GetAllEmp_Gym_Meeting_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_GYM_REQUEST_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_GYM_REQUEST_BY_ID([FromQuery] Download_hrm_emp_gymChangeRequestById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_GYM_MEETING_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_GYM_MEETING_BY_ID([FromQuery] Download_hrm_emp_gymMeetingById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region emp_skills
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_EMP_SKILL)]
        public async Task<IActionResult> ADD_UPDATE_EMP_SKILL([FromForm] hrm_emp_skills_contract command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_EMP_SKILLS)]
        public async Task<IActionResult> GET_ALL_EMP_SKILLS()
        {
            var query = new GetAllEmp_Skills_Query();
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_SKILL)]
        public async Task<IActionResult> GET_SINGLE_EMP_SKILL([FromQuery] GetSingleEmpSkill_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.DELETE_EMP_SKILL)]
        public async Task<IActionResult> DELETE_EMP_SKILL([FromBody] DeleteEmp_skillCommand command)
        {
            var res = await _mediator.Send(command);
            if (res.Status.IsSuccessful)
                return Ok(res);
            return BadRequest(res);
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_EMP_SKILL_BY_STAFFID)]
        public async Task<IActionResult> GET_SINGLE_EMP_SKILL_BY_STAFFID([FromQuery] GetSingleEmpSkillByStaffId_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.DOWNLOAD_EMP_SKILL_BY_ID)]
        public async Task<IActionResult> DOWNLOAD_EMP_SKILL_BY_ID([FromQuery] Download_hrm_emp_skillsById_Query query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

        #region hrm_staff
        [ERPActivity(Action = UserActions.Add, Activity = 3)]
        [HttpPost(ApiRoutes.HrmEmployeeEndpoints.ADD_UPDATE_HRM_STAFF)]
        public async Task<IActionResult> ADD_UPDATE_HRM_STAFF([FromBody] UpdateHrmStaffCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.all_staff);

                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_ALL_HRM_STAFF)]
        public async Task<IActionResult> GetAllStaff()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.all_staff);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<hrm_staff_contract_resp>(cached_response));

            var query = new GetAllHrmStaffQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.all_staff, response);
            return Ok(response);
        }
        [ERPActivity(Action = UserActions.View, Activity = 3)]
        [HttpGet(ApiRoutes.HrmEmployeeEndpoints.GET_SINGLE_HRM_STAFF)]
        public async Task<IActionResult> GET_SINGLE_HRM_STAFF([FromQuery] GetSingleHrmStaffByIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        #endregion

    }
}
