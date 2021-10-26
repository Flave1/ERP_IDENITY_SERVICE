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

namespace APIGateway.Handlers.Hrm.setup.hospital_management
{
    public class UploadHospitalManagementCommand : IRequest<FileUploadRespObj>
    {
        public class UploadHospitalManagementCommandHandler : IRequestHandler<UploadHospitalManagementCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;
            public UploadHospitalManagementCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _context = context;
                _setup = setup;
            }

            public async Task<FileUploadRespObj> Handle(UploadHospitalManagementCommand request, CancellationToken cancellationToken)
            {
                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                List<hrm_setup_hospital_management_contract> uploadedRecord = new List<hrm_setup_hospital_management_contract>();
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
                                if (totalColumns != 7)
                                {
                                    response.Status.Message.FriendlyMessage = $"Seven (7) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_hospital_management_contract
                                    {
                                        ExcelLineNumber = i,
                                        Hospital = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        HmoName = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
                                        ContactPhoneNo = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : null,
                                        Email = workSheet.Cells[i, 4].Value != null ? workSheet.Cells[i, 4].Value.ToString() : null,
                                        Address = workSheet.Cells[i, 5].Value != null ? workSheet.Cells[i, 5].Value.ToString() : null,
                                        Rating = workSheet.Cells[i, 6].Value != null ? Convert.ToInt32(workSheet.Cells[i, 6].Value.ToString()) : 0,
                                        OtherComments = workSheet.Cells[i, 7].Value != null ? workSheet.Cells[i, 7].Value.ToString() : null,
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
                            if (string.IsNullOrEmpty(item.Hospital))
                            {
                                response.Status.Message.FriendlyMessage = $"Hospital cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.HmoName))
                            {
                                response.Status.Message.FriendlyMessage = $"HmoName cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.ContactPhoneNo))
                            {
                                response.Status.Message.FriendlyMessage = $"Contact Phone Number cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Email))
                            {
                                response.Status.Message.FriendlyMessage = $"Email cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Address))
                            {
                                response.Status.Message.FriendlyMessage = $"Address cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (item.Rating < 1)
                            {
                                response.Status.Message.FriendlyMessage = $"Additional Information cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.OtherComments))
                            {
                                response.Status.Message.FriendlyMessage = $"OtherComments cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            var current_item = _context.hrm_setup_hospital_management.FirstOrDefault(e => e.Hospital.ToLower() == item.Hospital.ToLower());

                            var getHmo = _context.hrm_setup_hmo.FirstOrDefault(m => m.Hmo_name.ToLower() == item.HmoName.ToLower());
                            
                            if(getHmo != null)
                            {
                                if (current_item == null)
                                    current_item = new hrm_setup_hospital_management();
                                current_item.Hospital = item.Hospital;
                                current_item.HmoId = getHmo.Id;
                                current_item.ContactPhoneNo = item.ContactPhoneNo;
                                current_item.Email = item.Email;
                                current_item.Address = item.Address;
                                current_item.Rating = item.Rating;
                                current_item.OtherComments = item.OtherComments;

                                await _setup.AddUpdateHospitalManagementAsync(current_item);
                            }
                            else
                            {
                                response.Status.IsSuccessful = false;
                                response.Status.Message.FriendlyMessage = $"{item.HmoName} not a valid Hmo Name detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            


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
