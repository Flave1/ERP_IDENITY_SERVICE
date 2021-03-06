using APIGateway.Contracts.Commands.Common;
using APIGateway.Contracts.Response.Common;
using APIGateway.Repository.Interface.Common;
using GODP.APIsContinuation.DomainObjects.Company;
using GODP.APIsContinuation.DomainObjects.Currency;
using GODP.APIsContinuation.DomainObjects.UserAccount;
using GODPAPIs.Contracts.GeneralExtension;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Common.Uploads_Downloads
{
    public class UploadCurrencyCommand : IRequest<FileUploadRespObj>
    {
        public byte[] File { get; set; }
        public class UploadCurrencyCommandHandler : IRequestHandler<UploadCurrencyCommand, FileUploadRespObj>
        {
            private readonly ICommonRepository _repo;
            private readonly UserManager<cor_useraccount> _userManager;
            private readonly IHttpContextAccessor _accessor;
            public UploadCurrencyCommandHandler(
                ICommonRepository commonRepository,
                UserManager<cor_useraccount> userManager,
                IHttpContextAccessor httpContextAccessor)
            {
                _repo = commonRepository;
                _accessor = httpContextAccessor;
                _userManager = userManager;
            }
            public async Task<FileUploadRespObj> Handle(UploadCurrencyCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var apiResponse = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                    var files = _accessor.HttpContext.Request.Form.Files;

                    var byteList = new List<byte[]>();
                    foreach (var fileBit in files)
                    {
                        if (fileBit.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                await fileBit.CopyToAsync(ms);
                                byteList.Add(ms.ToArray());
                            }
                        } 
                    }  
                    var uploadedRecord = new List<CommonLookupsObj>();
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    if (byteList.Count() > 0)
                    {
                        foreach (var byteItem in byteList)
                        {
                            using (MemoryStream stream = new MemoryStream(byteItem))
                            using (ExcelPackage excelPackage = new ExcelPackage(stream))
                            {
                                //Use first sheet by default
                                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];
                                int totalRows = workSheet.Dimension.Rows;
                                int totalColumns = workSheet.Dimension.Columns;
                                if(totalColumns != 4)
                                {
                                    apiResponse.Status.Message.FriendlyMessage = $"Four (4) Columns Expected";
                                    return apiResponse;
                                }
                                //First row is considered as the header
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    var lkp = new CommonLookupsObj
                                    {
                                        ExcelLineNumber = i,
                                        Code = workSheet.Cells[i, 1]?.Value != null ? workSheet.Cells[i, 1]?.Value.ToString() : string.Empty,
                                        LookupName = workSheet.Cells[i, 2]?.Value != null ? workSheet.Cells[i, 2]?.Value.ToString() : string.Empty,
                                        ParentName = workSheet.Cells[i, 3]?.Value != null ? workSheet.Cells[i, 3]?.Value.ToString() : string.Empty,
                                        Description = workSheet.Cells[i, 4]?.Value != null ? workSheet.Cells[i, 4]?.Value.ToString() : string.Empty,
                                    };
                                    uploadedRecord.Add(lkp);
                                }
                            }
                        } 
                    }

                    var _CurrencyList = await _repo.GetAllCurrencyAsync();
                    if (uploadedRecord.Count > 0)
                    {
                        foreach (var item in uploadedRecord)
                        {
                            if (string.IsNullOrEmpty(item.Code))
                            {
                                apiResponse.Status.Message.FriendlyMessage = $"Currency Code can not be empty on line {item.ExcelLineNumber}";
                                return apiResponse;
                            }
                            if (string.IsNullOrEmpty(item.LookupName))
                            {
                                apiResponse.Status.Message.FriendlyMessage = $"Currency Name can not be empty on line {item.ExcelLineNumber}";
                                return apiResponse;
                            }
                            if (string.IsNullOrEmpty(item.ParentName))
                            {
                                apiResponse.Status.Message.FriendlyMessage = $"Base currency Cannot be empty detected on line {item.ExcelLineNumber}";
                                return apiResponse;
                            }
                            else
                            {
                                if(!Convert.ToBoolean(item.ParentName) && Convert.ToBoolean(item.ParentName))
                                {
                                    apiResponse.Status.Message.FriendlyMessage = $"Invalid Base currency detected on line {item.ExcelLineNumber}";
                                    return apiResponse; 
                                }
                                item.BaseCurrency = Convert.ToBoolean(item.ParentName);
                            }
                            if (string.IsNullOrEmpty(item.Description))
                            {
                                apiResponse.Status.Message.FriendlyMessage = $"In Use Cannot be empty detected on line {item.ExcelLineNumber}";
                                return apiResponse;
                            }
                            else
                            {
                                if (!Convert.ToBoolean(item.Description) && Convert.ToBoolean(item.Description))
                                {
                                    apiResponse.Status.Message.FriendlyMessage = $"Invalid In Use value detected on line {item.ExcelLineNumber}";
                                    return apiResponse;
                                }
                                item.Active = Convert.ToBoolean(item.Description);
                            }

                            var currentCurrency = _CurrencyList.FirstOrDefault(c => c.CurrencyCode.ToLower() == item.Code.ToLower() && c.Deleted == false); 
                            if (currentCurrency == null)
                            {  
                                var Currency = new cor_currency();
                                Currency.CurrencyName = item.LookupName; 
                                Currency.CurrencyCode = item.Code;
                                Currency.INUSE = item.Active;
                                Currency.BaseCurrency = item.BaseCurrency;
                                await _repo.AddUpdateCurrencyAsync(Currency);
                            }
                            else
                            {
                                currentCurrency.CurrencyName = item.LookupName;
                                currentCurrency.CurrencyCode = item.Code;
                                currentCurrency.INUSE = item.Active;
                                currentCurrency.BaseCurrency = item.BaseCurrency;
                                await _repo.AddUpdateCurrencyAsync(currentCurrency);
                            }
                        }
                    }
                    apiResponse.Status.IsSuccessful = true;
                    apiResponse.Status.Message.FriendlyMessage = "Successful";
                    return apiResponse;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
    
}
