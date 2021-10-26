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

namespace APIGateway.Handlers.Hrm.setup.sub_skill
{
    public class UploadSubSkillCommand : IRequest<FileUploadRespObj>
    {
        public class UploadSubSkillCommandHandler : IRequestHandler<UploadSubSkillCommand, FileUploadRespObj>
        {
            private readonly IHttpContextAccessor _accessor;
            private readonly ISetupRepository _setup;
            private readonly DataContext _context;
            public UploadSubSkillCommandHandler(ISetupRepository setup, IHttpContextAccessor accessor, DataContext context)
            {
                _accessor = accessor;
                _setup = setup;
                _context = context;
            }

            public async Task<FileUploadRespObj> Handle(UploadSubSkillCommand request, CancellationToken cancellationToken)
            {
                var response = new FileUploadRespObj { Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage() } };


                List<hrm_setup_sub_skill_contract> uploadedRecord = new List<hrm_setup_sub_skill_contract>();
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
                                if (totalColumns != 4)
                                {
                                    response.Status.Message.FriendlyMessage = $"Four (4) Columns Expected";
                                    return response;
                                }
                                for (int i = 2; i <= totalRows; i++)
                                {
                                    uploadedRecord.Add(new hrm_setup_sub_skill_contract
                                    {
                                        ExcelLineNumber = i,
                                        Job_title = workSheet.Cells[i, 1].Value != null ? workSheet.Cells[i, 1].Value.ToString() : null,
                                        Skill = workSheet.Cells[i, 2].Value != null ? workSheet.Cells[i, 2].Value.ToString() : null,
                                        Description = workSheet.Cells[i, 3].Value != null ? workSheet.Cells[i, 3].Value.ToString() : null,
                                        Weight = workSheet.Cells[i, 4].Value != null ? Convert.ToInt32(workSheet.Cells[i, 4].Value.ToString()) : 0,
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

                List<hrm_setup_sub_skill_contract> JobSkillsDefinitions = new List<hrm_setup_sub_skill_contract>();

                var _jobSkillsDefinition = await _setup.GetAllJobSkillsAsync();

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
                            if (string.IsNullOrEmpty(item.Skill))
                            {
                                response.Status.Message.FriendlyMessage = $"Skill cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (string.IsNullOrEmpty(item.Description))
                            {
                                response.Status.Message.FriendlyMessage = $"Description cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            if (item.Weight < 1)
                            {
                                response.Status.Message.FriendlyMessage = $"Weight cannot be empty detected on line {item.ExcelLineNumber}";
                                return response;
                            }
                            var setup = _context.hrm_setup_jobtitle.FirstOrDefault(m => m.Job_title.ToLower() == item.Job_title.ToLower());
                            var current_item = _context.hrm_setup_sub_skill.FirstOrDefault(e => e.Skill.ToLower() == item.Skill.ToLower());
                            if (setup != null)
                            {
                                if(current_item == null)
                                     current_item = new hrm_setup_sub_skill();
                                current_item.Job_details_Id = setup.Id;
                                current_item.Skill = item.Skill;
                                current_item.Description = item.Description;
                                current_item.Weight = item.Weight;
                                await _setup.AddUpdateJobSkillsAsync(current_item);
                               
                            }
                            else
                            {
                                response.Status.IsSuccessful = false;
                                response.Status.Message.FriendlyMessage = $"{item.Job_title} not a valid Job title detected on line {item.ExcelLineNumber}";
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
