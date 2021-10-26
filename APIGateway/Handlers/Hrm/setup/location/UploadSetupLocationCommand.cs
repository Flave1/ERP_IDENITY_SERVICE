using APIGateway.Contracts.Response.HRM;
using APIGateway.Data;
using APIGateway.DomainObjects.hrm;
using APIGateway.Repository.Interface.Setup;
using GODPAPIs.Contracts.GeneralExtension;
using GOSLibraries.GOS_API_Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Handlers.Hrm.setup.location
{
    public class UploadLocationCommand : IRequest<FileUploadRespObj>
    {
        public class UploadLocationCommandHandler : IRequestHandler<UploadLocationCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;
            public UploadLocationCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _context = context;
                _setup = setup;
            }

            public async Task<FileUploadRespObj> Handle(UploadLocationCommand request, CancellationToken cancellationToken)
            {
                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                List<hrm_setup_location_contract> uploadedRecord = new List<hrm_setup_location_contract>();
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

                try
                {
                    if (byteList.Count() > 0)
                    {
                        foreach (var item in byteList)
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (MemoryStream stream = new MemoryStream(item))
                            using (ExcelPackage excelPackage = new ExcelPackage(stream))
                            {
                                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];
                                int totalRows = workSheet.Dimension.Rows;
                                int totalColumns = workSheet.Dimension.Columns;
                                if (totalColumns != 6)
                                {
                                    response.Status.Message.FriendlyMessage = $"Six (6) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_location_contract
                                    {
                                        ExcelLineNumber = i,
                                        Location = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        Address = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
                                        City = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : null,
                                        StateName = workSheet.Cells[i, 4].Value != null ? workSheet.Cells[i, 4].Value.ToString() : null,
                                        CountryName = workSheet.Cells[i, 5].Value != null ? workSheet.Cells[i, 5].Value.ToString() : null,
                                        AdditionalInformation = workSheet.Cells[i, 6].Value != null ? workSheet.Cells[i, 6].Value.ToString() : null,
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    response.Status.Message.FriendlyMessage = $" {ex?.Message}";
                    return response;
                }

                try
                {
                    if (uploadedRecord.Count > 0)
                    {
                        foreach (var item in uploadedRecord)
                        {
                            if (string.IsNullOrEmpty(item.Location))
                            {
                                response.Status.Message.FriendlyMessage = $"Location cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Address))
                            {
                                response.Status.Message.FriendlyMessage = $"Address cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.City))
                            {
                                response.Status.Message.FriendlyMessage = $"City cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.StateName))
                            {
                                response.Status.Message.FriendlyMessage = $"State Name cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.CountryName))
                            {
                                response.Status.Message.FriendlyMessage = $"Country Name cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.AdditionalInformation))
                            {
                                response.Status.Message.FriendlyMessage = $"Additional Information cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }

                            var current_item = _context.hrm_setup_location.FirstOrDefault(e => e.Location.ToLower() == item.Location.ToLower());
                            
                            var getState = _context.cor_state.FirstOrDefault(m => m.StateName.ToLower() == item.StateName.ToLower());
                            var getCountry = _context.cor_country.FirstOrDefault(m => m.CountryName.ToLower() == item.CountryName.ToLower());

                            if (current_item == null)
                                 current_item = new hrm_setup_location();
                            current_item.Location = item.Location;
                            current_item.Address = item.Address;
                            current_item.City = item.City;
                            current_item.StateId = getState.StateId;
                            current_item.CountryId = getCountry.CountryId;
                            current_item.AdditionalInformation = item.AdditionalInformation;
                            
                            await _setup.AddUpdateLocationAsync(current_item);
                            
                            
                        }
                    }
                    response.Status.IsSuccessful = true;
                    response.Status.Message.FriendlyMessage = "Record saved successfully";
                    return response;
                }
                catch (Exception ex)
                {
                    response.Status.IsSuccessful = true;
                    response.Status.Message.FriendlyMessage = ex?.Message;
                    return response;
                }
            }
        }
    }
}
