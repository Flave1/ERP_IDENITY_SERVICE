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

namespace APIGateway.Handlers.Hrm.setup.jobgrade
{
    public class UploadJobGradeCommand : IRequest<FileUploadRespObj>
    {
        public class UploadJobGradeCommandHandler : IRequestHandler<UploadJobGradeCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly DataContext _context;
            private readonly ISetupRepository _setup;
            public UploadJobGradeCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _context = context;
                _setup = setup;
            }

            public async Task<FileUploadRespObj> Handle(UploadJobGradeCommand request, CancellationToken cancellationToken)
            {

                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };


                List<hrm_setup_jobgrade_contract> uploadedRecord = new List<hrm_setup_jobgrade_contract>();
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
                                if (totalColumns != 5)
                                {
                                    response.Status.Message.FriendlyMessage = $"Five (5) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_jobgrade_contract
                                    {
                                        ExcelLineNumber = i,
                                        Job_grade = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        Description = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
                                        Job_grade_reporting_to = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : null,
                                        Rank = workSheet.Cells[i, 4].Value != null ? Convert.ToInt32(workSheet.Cells[i, 4].Value.ToString()) : 0,
                                        Probation_period_in_months = workSheet.Cells[i, 5].Value != null ? Convert.ToInt32(workSheet.Cells[i, 5].Value.ToString()) : 0,
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
                            if (string.IsNullOrEmpty(item.Job_grade))
                            {
                                response.Status.Message.FriendlyMessage = $"JobGrade cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Job_grade_reporting_to))
                            {
                                response.Status.Message.FriendlyMessage = $"JobGrade_Reporting_to cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (item.Rank < 1)
                            {
                                response.Status.Message.FriendlyMessage = $"Rank cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (item.Probation_period_in_months < 1)
                            {
                                response.Status.Message.FriendlyMessage = $"Probation_period_in_months cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Description))
                            {
                                response.Status.Message.FriendlyMessage = $"Description cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            
                            var current_item = _context.hrm_setup_jobgrade.FirstOrDefault(e => e.Job_grade.ToLower() == item.Job_grade.ToLower());
                           
                            if(current_item == null)
                            {
                                current_item = new hrm_setup_jobgrade();
                                current_item.Job_grade = item.Job_grade;
                                current_item.Job_grade_reporting_to = item.Job_grade_reporting_to;
                                current_item.Rank = item.Rank;
                                current_item.Probation_period_in_months = item.Rank;
                                current_item.Description = item.Description;
                                await _setup.AddUpdateJobGradeAsync(current_item);
                            }
                            else
                            {
                                current_item.Job_grade = item.Job_grade;
                                current_item.Job_grade_reporting_to = item.Job_grade_reporting_to;
                                current_item.Rank = item.Rank;
                                current_item.Probation_period_in_months = item.Rank;
                                current_item.Description = item.Description;
                                await _setup.AddUpdateJobGradeAsync(current_item);
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
