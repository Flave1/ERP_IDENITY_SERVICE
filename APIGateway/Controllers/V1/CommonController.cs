using APIGateway.ActivityRequirement;
using APIGateway.Contracts.Commands.Common;
using APIGateway.Contracts.Queries.Common;
using APIGateway.Contracts.Response.Common;
using APIGateway.Contracts.V1;
using APIGateway.Handlers.Common;
using APIGateway.Handlers.Common.Uploads_Downloads;
using APIGateway.Repository.Inplimentation.Cache;
using GODPAPIs.Contracts.GeneralExtension;
using GODPAPIs.Contracts.V1;
using GOSLibraries.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers.V1
{ 
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IResponseCacheService _cacheService;
        public CommonController(IMediator mediator, IResponseCacheService cacheService)
        {
            _cacheService = cacheService;
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.CommonEnpoint.BRANCHES)]
        public async Task<IActionResult> Branch()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_branchies);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllBranchesQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_branchies, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.CALL_MEMO_TYPE)]
        public async Task<IActionResult> MemoType()
        {
            var query = new GetAllCallMemoTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.CITY)]
        public async Task<IActionResult> City()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_cities);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllCityQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_cities, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.CITY_BY_STATE)]
        public async Task<IActionResult> CITY_BY_STATE([FromQuery] GetAllCityByStateQuery query)
        { 
            return Ok(await _mediator.Send(query));
        }


        [HttpGet(ApiRoutes.CommonEnpoint.CREDITBUREAU)]
        public async Task<IActionResult> CREDITBUREAU()
        {
            var query = new GetAllCreditBureauQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.CURRENCY_RATE)]
        public async Task<IActionResult> CURRENCY_RATE()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_currency_rate);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllCurrencyRateQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_currency_rate, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.CURRENCY_RATE_BY_CURRENCY)]
        public async Task<IActionResult> CURRENCY_RATE_BY_CURRENCY([FromQuery] GetCurrencyRateByCurrrencyQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.IDENTITY)]
        public async Task<IActionResult> IDENTITY()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_identifications);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllIdentificationQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_identifications, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.CURRENCY)]
        public async Task<IActionResult> Currency()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_currencies);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllCurrencyQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_currencies, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.COUNTRY)]
        public async Task<IActionResult> Country()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_countries);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new Handlers.Common.GetAllCountryQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_countries, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.DEPARTMENT)]
        public async Task<IActionResult> Department()
        {
            var query = new GetAllDepartmentsQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.DIRECTOR_TYPE)]
        public async Task<IActionResult> DirectorType()
        {
            var query = new GetAllDirectorTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.DOCUMENT_TYPE)]
        public async Task<IActionResult> DocumentType()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_document_types);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllDocumentTypeQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_document_types, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.EMPLOYER_TYPE)]
        public async Task<IActionResult> EmployerType()
        {
            var query = new GetAllEmployerTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.GENDER)]
        public async Task<IActionResult> Gender()
        {
            var query = new GetAllGenderQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.GL_ACCOUNT)]
        public async Task<IActionResult> GLAccount()
        {
            var query = new GetAllGLAccountQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.LMO_TYPE)]
        public async Task<IActionResult> LmoType()
        {
            var query = new GetAllLoanManagementOperationTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.MARITAL_STATUS)]
        public async Task<IActionResult> MaritalStatus()
        {
            var query = new GetAllMaritalStatusQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.MODULES)]
        public async Task<IActionResult> Modules()
        {
            var query = new GetAllModulesQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.PRODUCT_TYPE)]
        public async Task<IActionResult> ProdType()
        {
            var query = new GetAllProductTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.STATE)]
        public async Task<IActionResult> State()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_states);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllStateQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_states, response);
            return Ok(response);
        }

        [HttpGet(ApiRoutes.CommonEnpoint.STATE_BY_COUNTRY)]
        public async Task<IActionResult> STATE_BY_COUNTRY([FromQuery] GetAllStateInCountryQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.TITLE)]
        public async Task<IActionResult> Title()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_titles);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllTitleQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_titles, response);
            return Ok(response);
        }

        
        [HttpGet(ApiRoutes.CommonEnpoint.JOB_TITLE)]
        public async Task<IActionResult> JobTitle()
        {
            var cached_response = await _cacheService.GetCacheResponseAsync(CacheKeys.common_job_titles);
            if (cached_response != null)
                return Ok(JsonConvert.DeserializeObject<CommonLookupRespObj>(cached_response));

            var query = new GetAllJobTitleQuery();
            var response = await _mediator.Send(query);
            if (response.Status.IsSuccessful)
                await _cacheService.CatcheResponseAsync(CacheKeys.common_job_titles, response);
            return Ok(response);
        }

         
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_BRANCH)]
        public async Task<IActionResult> ADD_UPDATE_BRANCH([FromBody] AddUpdateBranchCommand command)
        { 
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful) 
                return BadRequest(res); 
            await _cacheService.ResetCacheAsync(CacheKeys.common_branchies); 
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Add, Activity = 22)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_CITY)]
        public async Task<IActionResult> ADD_UPDATE_CITY([FromBody] AddUpdateCityCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_cities);
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Add, Activity = 20)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_COUNTRY)]
        public async Task<IActionResult> ADD_UPDATE_COUNTRY([FromBody] AddUpdateCountryCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_countries);
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Add, Activity = 24)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_JOB_TITLE)]
        public async Task<IActionResult> ADD_UPDATE_JOB_TITLE([FromBody] AddUpdateJobTitleCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_job_titles);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Add, Activity = 21)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_STATE)]
        public async Task<IActionResult> ADD_UPDATE_STATE([FromBody] AddUpdateStateCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_states);
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Add, Activity = 26)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_DOCU_TYPE)]
        public async Task<IActionResult> ADD_UPDATE_DOCU_TYPE([FromBody] AddUpdateDocumenttypeCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_document_types);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Add, Activity = 25)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_CURRENT_RATE)]
        public async Task<IActionResult> ADD_UPDATE_CURRENT_RATE([FromBody] AddUpdateCurrencyRateCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_currency_rate);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Add, Activity = 27)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_IDENTITY)]
        public async Task<IActionResult> ADD_UPDATE_IDENTITY([FromBody] AddUpdateIdentificationCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_identifications);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Add, Activity = 23)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_CURRENCY)]
        public async Task<IActionResult> ADD_UPDATE_CURRENCY([FromBody] AddUpdateCurrencyCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_currencies);
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Add, Activity = 28)]
        [HttpPost(ApiRoutes.CommonEnpoint.ADD_UPDATE_CREDITBUREAU)]
        public async Task<IActionResult> ADD_UPDATE_CREDITBUREAU([FromBody] DeleteCreditBureauCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Delete, Activity = 20)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_COUNTRY)]
        public async Task<IActionResult> DELETE_COUNTRY([FromBody] DeleteCountryCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_countries);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Delete, Activity = 24)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_JOB_TITLE)]
        public async Task<IActionResult> DELETE_JOB_TITLE([FromBody] DeleteJobTitleCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_job_titles);
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Delete, Activity = 22)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_CITY)]
        public async Task<IActionResult> DELETE_CITY([FromBody] DeleteCityCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_cities);
            return Ok(res);
        }
        [ERPActivity(Action = UserActions.Delete, Activity = 20)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_CURRENCY_RATE)]
        public async Task<IActionResult> DELETE_CURRENCY_RATE([FromBody] DeleteCurrencyRateCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_currency_rate);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Delete, Activity = 27)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_IDENTIFICATION)]
        public async Task<IActionResult> DELETE_IDENTIFICATION([FromBody] DeleteIdentificationCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_identifications);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Delete, Activity = 26)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_DOCUMENT_TYPE)]
        public async Task<IActionResult> DELETE_DOCUMENT_TYPE([FromBody] DeleteDocumentTypeCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_document_types);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Delete, Activity = 23)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_CURRENCY)]
        public async Task<IActionResult> DELETE_CURRENCY([FromBody] DeleteCurrencyCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_currencies);
            return Ok(res);
        }


        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_BRANCH)]
        public async Task<IActionResult> DELETE_BRANCH([FromBody] DeleteBranchCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_branchies);
            return Ok(res);
        }

        [ERPActivity(Action = UserActions.Delete, Activity = 21)]
        [HttpPost(ApiRoutes.CommonEnpoint.DELETE_STATE)]
        public async Task<IActionResult> DELETE_STATE([FromBody] DeleteStateCommand command)
        {
            var res = await _mediator.Send(command);
            if (!res.Status.IsSuccessful)
                return BadRequest(res);
            await _cacheService.ResetCacheAsync(CacheKeys.common_states);
            return Ok(res);
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_COUNTRY)]
        public async Task<IActionResult> GET_COUNTRY([FromQuery] GetCountryQuery query)
        { 
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_STATE)]
        public async Task<IActionResult> GET_STATE([FromQuery] GetStateQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_BRANCH)]
        public async Task<IActionResult> GET_BRANCH([FromQuery] GetBranchQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_DOCUMENT_TYPE)]
        public async Task<IActionResult> GET_DOCUMENT_TYPE([FromQuery] GetDocumentTypeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_CURRENCY_RATE)]
        public async Task<IActionResult> GET_CURRENCY_RATE([FromQuery] GetCurrencyRateQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_IDENTIFICATION)]
        public async Task<IActionResult> GET_IDENTIFICATION([FromQuery] GetIdentificationQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_CURRENCY)]
        public async Task<IActionResult> GET_CURRENCY([FromQuery] GetCurrencyQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_CREDITBUREAU)]
        public async Task<IActionResult> GET_CREDITBUREAU([FromQuery] GetCreditBureauQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet(ApiRoutes.CommonEnpoint.GET_CITY)]
        public async Task<IActionResult> GET_CITY([FromQuery] GetCityQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
         
        [HttpGet(ApiRoutes.CommonEnpoint.GET_JOB_TITLE)]
        public async Task<IActionResult> GET_JOB_TITLE([FromQuery] GetJobTitleQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.Add, Activity = 20)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_COUNTRY)]
        public async Task<IActionResult> UPLOAD_COUNTRY()
        {
            var command = new UploadCountryCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_countries);
                return Ok(response);
            }
            return BadRequest(response);
        }

        
        [ERPActivity(Action = UserActions.Add, Activity = 21)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_STATE)]
        public async Task<IActionResult> UPLOAD_STATE()
        {
            var command = new UploadStateCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_states);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [ERPActivity(Action = UserActions.Add, Activity = 22)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_CITY)]
        public async Task<IActionResult> UPLOAD_CITY()
        {
            var command = new UploadCityCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_cities);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [ERPActivity(Action = UserActions.View, Activity = 20)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_COUNTRY)]
        public async Task<IActionResult> DOWNLOAD_COUNTRY()
        {
            var query = new DownloadCountryQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.View, Activity = 21)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_STATE)]
        public async Task<IActionResult> DOWNLOAD_STATE()
        {
            var query = new DownloadStateQuery();
            return Ok(await _mediator.Send(query));
        }
        [ERPActivity(Action = UserActions.View, Activity = 22)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_CITY)]
        public async Task<IActionResult> DOWNLOAD_CITY()
        {
            var query = new DownloadCityQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.View, Activity = 23)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_CURRENCY)]
        public async Task<IActionResult> DOWNLOAD_CURRENCY()
        {
            var query = new DownloadCurrencyQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.Add, Activity = 23)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_CURRENCY)]
        public async Task<IActionResult> UPLOAD_CURRENCY()
        {
            var command = new UploadCurrencyCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [ERPActivity(Action = UserActions.View, Activity = 24)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_JOB_TITLE)]
        public async Task<IActionResult> DOWNLOAD_JOB_TITLE()
        {
            var query = new DownloadJobTitleQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.Add, Activity = 24)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_JOB_TITLE)]
        public async Task<IActionResult> UPLOAD_JOB_TITLE()
        {
            var command = new UploadJobTitleCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_job_titles);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [ERPActivity(Action = UserActions.View, Activity = 25)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_CURRENCYRATE)]
        public async Task<IActionResult> DOWNLOAD_CURRENCYRATE()
        {
            var query = new DownloadCurrencyRateQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.Add, Activity = 25)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_CURRENCYRATE)]
        public async Task<IActionResult> UPLOAD_CURRENCYRATE()
        {
            var command = new UploadCurrencyRateCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_currency_rate);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [ERPActivity(Action = UserActions.View, Activity = 26)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_DOCUMENTTYPE)]
        public async Task<IActionResult> DOWNLOAD_DOCUMENTTYPE()
        {
            var query = new DownloadDocumentTypeQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.Add, Activity = 26)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_DOCUMENTTYPE)]
        public async Task<IActionResult> UPLOAD_DOCUMENTTYPE()
        {
            var command = new UploadDocumentTypeCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_document_types);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [ERPActivity(Action = UserActions.View, Activity = 27)]
        [HttpGet(ApiRoutes.CommonEnpoint.DOWNLOAD_IDENTIFICATION)]
        public async Task<IActionResult> DOWNLOAD_IDENTIFICATION()
        {
            var query = new DownloadIdentificationQuery();
            return Ok(await _mediator.Send(query));
        }

        [ERPActivity(Action = UserActions.Add, Activity = 27)]
        [HttpPost(ApiRoutes.CommonEnpoint.UPLOAD_IDENTIFICATION)]
        public async Task<IActionResult> UPLOAD_IDENTIFICATION()
        {
            var command = new UploadIdentificationCommand();
            var response = await _mediator.Send(command);
            if (response.Status.IsSuccessful)
            {
                await _cacheService.ResetCacheAsync(CacheKeys.common_identifications);
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
