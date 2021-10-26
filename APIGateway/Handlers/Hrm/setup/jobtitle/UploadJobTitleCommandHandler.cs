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

namespace APIGateway.Handlers.Hrm.setup.jobdetail
{
    public class UploadJobTitleCommand : IRequest<FileUploadRespObj>
    {
        public class UploadJobTitleCommandHandler : IRequestHandler<UploadJobTitleCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly ISetupRepository _setup;
            private readonly DataContext _context;
            public UploadJobTitleCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _setup = setup;
                _context = context;
            }

            public async Task<FileUploadRespObj> Handle(UploadJobTitleCommand request, CancellationToken cancellationToken)
            {
                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };

                List<hrm_setup_jobtitle_contract> uploadedRecord = new List<hrm_setup_jobtitle_contract>();
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
                                if (totalColumns != 2)
                                {
                                    response.Status.Message.FriendlyMessage = $"Two (2) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_jobtitle_contract
                                    {
                                        ExcelLineNumber = i,
                                        Job_title = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        Job_description = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
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
                            if (string.IsNullOrEmpty(item.Job_title))
                            {
                                response.Status.Message.FriendlyMessage = $"Job_title cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Job_title))
                            {
                                response.Status.Message.FriendlyMessage = $"Description cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            var current_item = _context.hrm_setup_jobtitle.FirstOrDefault(e => e.Job_title.ToLower() == item.Job_title.ToLower());

                            if (current_item == null)
                            {
                                current_item = new hrm_setup_jobtitle();
                                current_item.Job_title = item.Job_title;
                                current_item.Job_description = item.Job_description;
                                await _setup.AddUpdateJobTitleAsync(current_item);
                            }
                            else
                            {
                                current_item.Job_title = item.Job_title;
                                current_item.Job_description = item.Job_description;
                                await _setup.AddUpdateJobTitleAsync(current_item);
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
