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

namespace APIGateway.Handlers.Hrm.setup.hmo
{
    public class UploadHMOCommand : IRequest<FileUploadRespObj>
    {

        public class UploadHMOCommandHandler : IRequestHandler<UploadHMOCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;
            public UploadHMOCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _context = context;
                _setup = setup;
            }

            public async Task<FileUploadRespObj> Handle(UploadHMOCommand request, CancellationToken cancellationToken)
            {
                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };


                List<hrm_setup_hmo_contract> uploadedRecord = new List<hrm_setup_hmo_contract>();
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
                                if (totalColumns != 8)
                                {
                                    response.Status.Message.FriendlyMessage = $"Eight (8) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_hmo_contract
                                    {
                                        ExcelLineNumber = i,
                                        Hmo_name = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        Hmo_code = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
                                        Contact_phone_number = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : null,
                                        Contact_email = workSheet.Cells[i, 4].Value != null ? workSheet.Cells[i, 4].Value.ToString() : null,
                                        Address = workSheet.Cells[i, 5].Value != null ? workSheet.Cells[i, 5].Value.ToString() : null,
                                        Reg_date = workSheet.Cells[i, 6].Value != null ? Convert.ToDateTime(workSheet.Cells[i, 6].Value.ToString()) : DateTime.Now,
                                        Rating= workSheet.Cells[i, 7].Value != null ? Convert.ToInt32(workSheet.Cells[i, 7].Value.ToString()) : 0,
                                        Other_comments = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
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
                            if (string.IsNullOrEmpty(item.Hmo_name))
                            {
                                response.Status.Message.FriendlyMessage = $"HMO name cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Hmo_code))
                            {
                                response.Status.Message.FriendlyMessage = $"HMO code cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Contact_phone_number))
                            {
                                response.Status.Message.FriendlyMessage = $"Contact phone number cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Contact_phone_number))
                            {
                                response.Status.Message.FriendlyMessage = $"Contact phone number cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Address))
                            {
                                response.Status.Message.FriendlyMessage = $"Address cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (item.Rating < 1)
                            {
                                response.Status.Message.FriendlyMessage = $"Rating cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            var current_item = _context.hrm_setup_hmo.FirstOrDefault(e => e.Hmo_name.ToLower() == item.Hmo_name.ToLower());
                            if (current_item == null)
                            {
                                current_item = new hrm_setup_hmo();
                                current_item.Hmo_name = item.Hmo_name;
                                current_item.Hmo_code = item.Hmo_code;
                                current_item.Contact_phone_number = item.Contact_phone_number;
                                current_item.Contact_email = item.Contact_email;
                                current_item.Address = item.Address;
                                current_item.Reg_date = item.Reg_date;
                                current_item.Rating = item.Rating;
                                current_item.Other_comments = item.Other_comments;
                                await _setup.AddUpdateHMOAsync(current_item);
                            }
                            else
                            {
                                current_item.Hmo_name = item.Hmo_name;
                                current_item.Hmo_code = item.Hmo_code;
                                current_item.Contact_phone_number = item.Contact_phone_number;
                                current_item.Contact_email = item.Contact_email;
                                current_item.Address = item.Address;
                                current_item.Reg_date = item.Reg_date;
                                current_item.Rating = item.Rating;
                                current_item.Other_comments = item.Other_comments;
                                await _setup.AddUpdateHMOAsync(current_item);
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
