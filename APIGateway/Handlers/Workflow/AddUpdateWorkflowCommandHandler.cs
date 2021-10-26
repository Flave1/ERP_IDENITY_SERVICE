using APIGateway.Contracts.Commands.Workflow;
using APIGateway.Data;
using APIGateway.Repository.Interface.Workflow;
using GODP.APIsContinuation.DomainObjects.UserAccount;
using GODP.APIsContinuation.DomainObjects.Workflow; 
using GOSLibraries.GOS_Error_logger.Service;
using GOSLibraries.GOS_API_Response;
using GODPAPIs.Contracts.RequestResponse.Workflow; 
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GOSLibraries.Enums;

namespace APIGateway.Handlers.Workflow
{


    public class AddUpdateWorkflowCommandHandler : IRequestHandler<AddUpdateWorkflowCommand, WorkflowRespObj>
    {
        private readonly ILoggerService _logger;
        private readonly IWorkflowRepository _repo;
        private readonly UserManager<cor_useraccount> _userManger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;
        public AddUpdateWorkflowCommandHandler(ILoggerService loggerService, IWorkflowRepository repository,
            UserManager<cor_useraccount> userManger, IHttpContextAccessor httpContextAccessor, DataContext dataContext)
        {
            _logger = loggerService;
            _repo = repository;
            _userManger = userManger;
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Delete_existing_workflow_async(int workflowId)
        {
            var access = await _dataContext.cor_workflowaccess.Where(x => x.WorkflowId == workflowId).ToListAsync();
            if (access.Any()) _dataContext.cor_workflowaccess.RemoveRange(access);
             
            var details = await _dataContext.cor_workflowdetails.Where(x => x.WorkflowId == workflowId).ToListAsync();
            if (details.Any())
            {
                var detail_ids = details.Select(w => w.WorkflowDetailId).ToList();
                var detail_access = await _dataContext.cor_workflowdetailsaccess.Where(x => detail_ids.Contains(x.WorkflowDetailId)).ToListAsync();
                if (detail_access.Any()) _dataContext.cor_workflowdetailsaccess.RemoveRange(detail_access);

                _dataContext.cor_workflowdetails.RemoveRange(details);
            }

            var task = await _dataContext.cor_workflowtask.Where(x => x.WorkflowId == workflowId).ToListAsync();
            if (task.Any()) _dataContext.cor_workflowtask.RemoveRange(task);

            //var item = _dataContext.cor_workflow.Find(workflowId);

            //if (item != null)
            //    _dataContext.cor_workflow.Remove(item);
            return _dataContext.SaveChanges() > 0;
        }

       

        public async Task<bool> AddWorkFlowDetailsAccessAsync(int details_id, int[] Office_access_ids)
        {
            try
            {
                if (details_id > 0)
                {
                    if (Office_access_ids.Any())
                    {
                        foreach(var office in Office_access_ids)
                        {
                            var subaccess = new cor_workflowdetailsaccess
                            {
                                WorkflowDetailId = details_id,
                                OfficeAccessId = office,
                                Active = true,
                                Deleted = false,
                                CreatedBy = "",
                                CreatedOn = DateTime.Now,
                                UpdatedBy = "",
                                UpdatedOn = DateTime.Now,
                            }; 
                            await _dataContext.cor_workflowdetailsaccess.AddAsync(subaccess);
                        } 
                    } 
                }
                return await _dataContext.SaveChangesAsync() > 0; 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<WorkflowRespObj> Handle(AddUpdateWorkflowCommand request, CancellationToken cancellationToken)
        {
            try
            {
                

                List<cor_workflowaccess> wkfAccesses = new List<cor_workflowaccess>();
                List<cor_workflowdetailsaccess> wkfDetailsAccesses = new List<cor_workflowdetailsaccess>();
                List<cor_workflowdetails> wkfDetails = new List<cor_workflowdetails>();
                cor_workflow workflow = new cor_workflow();

                var currentUserId = _httpContextAccessor.HttpContext.User?.FindFirst(x => x.Type == "userId").Value;
                var user = await _userManger.FindByIdAsync(currentUserId);

                #region Check if workflow with selected access Ids exist for this company

                //if (await _repo.CheckIfOperationAndAccessExistAsync(request.OperationId, request.WorkflowAccessIds))
                //    return new WorkflowRespObj
                //    {
                //        Status = new APIResponseStatus
                //        {
                //            IsSuccessful = false,
                //            Message = new APIResponseMessage { FriendlyMessage = "Workflow with same operation and access level is already added" }
                //        }
                //    };

                #endregion
                using (var _trans = await _dataContext.Database.BeginTransactionAsync())
                {
                    try
                    {

                        #region Check if office access selected matches the companystructure from repository
                        if (request.WorkflowId > 0)
                        {
                            await Delete_existing_workflow_async(request.WorkflowId);
                        }

                        if (request.Details != null)
                        {
                            foreach (var workflowDetail in request.Details)
                            {
                                if (workflowDetail.AccessOfficeIds.Length > 0)
                                {
                                    var result = (from compStruct in _dataContext.cor_companystructure
                                                  join compStructDef in _dataContext.cor_companystructuredefinition on compStruct.StructureTypeId equals compStructDef.StructureDefinitionId
                                                  where workflowDetail.AccessOfficeIds.Contains(compStruct.CompanyStructureId) || workflowDetail.AccessOfficeIds.Contains((int)compStruct.ParentCompanyID)
                                                  select compStruct.CompanyStructureId).ToArray();

                                    string OfficeAccessIds = string.Join(',', result);

                                    var singleDetail = new cor_workflowdetails
                                    {
                                        WorkflowId = request.WorkflowId,//to be looked into
                                        WorkflowGroupId = workflowDetail.WorkflowGroupId,
                                        WorkflowLevelId = workflowDetail.WorkflowLevelId,
                                        AccessId = workflowDetail.AccessId,
                                        Position = workflowDetail.Position,
                                        OfficeAccessIds = OfficeAccessIds,
                                        Active = false,
                                        Deleted = false,
                                        CreatedBy = user.UserName,
                                        CreatedOn = DateTime.Now,
                                        UpdatedBy = user.UserName,
                                        UpdatedOn = DateTime.Now,
                                        OperationId = request.OperationId
                                    };
                                    wkfDetails.Add(singleDetail);
                                }

                            }
                        }
                        else
                            return new WorkflowRespObj
                            {
                                Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "No Workflow details added for this settup" } }
                            };

                        #endregion

                        #region At this point, we check for the workflow access
                        if (request.WorkflowAccessIds.Length > 0)
                        {
                            var CselectedCompanyStructureIds = (from compStruct in _dataContext.cor_companystructure
                                                                join compStructdef in _dataContext.cor_companystructuredefinition on compStruct.StructureTypeId equals compStructdef.StructureDefinitionId
                                                                where request.WorkflowAccessIds.Contains(compStruct.CompanyStructureId) || request.WorkflowAccessIds.Contains((int)compStruct.ParentCompanyID)
                                                                select compStruct.CompanyStructureId).ToArray();
                            if (CselectedCompanyStructureIds.Length > 0)
                            {
                                foreach (var officeAccessId in CselectedCompanyStructureIds)
                                {
                                    var access = new cor_workflowaccess
                                    {
                                        OfficeAccessId = officeAccessId,
                                        OperationId = request.OperationId,
                                        Active = true,
                                        Deleted = false,
                                        CreatedBy = user.UserName,
                                        CreatedOn = DateTime.Now,
                                        UpdatedBy = user.UserName,
                                        UpdatedOn = DateTime.Now,
                                    };
                                    wkfAccesses.Add(access);
                                }
                            }
                        }
                        else
                            return new WorkflowRespObj
                            {
                                Status = new APIResponseStatus { IsSuccessful = false, Message = new APIResponseMessage { FriendlyMessage = "No Workflow Accesss added for this workflow settup" } }
                            };
                        #endregion

                        #region At this point, there is a check if exist on workflow (ADD||UPDATE)

                        bool output = false;
                        //if (request.WorkflowId > 0)
                        //{
                        //    workflow = _dataContext.cor_workflow.Find(request.WorkflowId);
                        //    if (workflow != null)
                        //    {
                        //        var targetDetails = _dataContext.cor_workflowdetails.Where(x => x.WorkflowId == workflow.WorkflowId).ToList();
                        //        var targetAccesses = _dataContext.cor_workflowaccess.Where(x => x.WorkflowId == workflow.WorkflowId).ToList();

                        //        if (targetDetails.Any())
                        //        {
                        //            foreach (var item in targetDetails)
                        //            {
                        //                _dataContext.cor_workflowdetails.Remove(item);
                        //            }
                        //        }
                        //        if (targetAccesses.Any())
                        //        {
                        //            foreach (var item in targetAccesses)
                        //            {
                        //                _dataContext.cor_workflowaccess.Remove(item);
                        //            }
                        //        }
                        //        workflow.WorkflowName = request.WorkflowName;
                        //        workflow.WorkflowAccessId = request.WorkflowAccessId;
                        //        workflow.OperationId = request.OperationId;
                        //        workflow.ApprovalStatusId = workflow.ApprovalStatusId;//(int)ApprovalStatus.Approved; (question)="why us it initialize with approved"
                        //        workflow.cor_workflowaccess = wkfAccesses;
                        //        workflow.cor_workflowdetails = wkfDetails;
                        //        workflow.Active = true;
                        //        workflow.Deleted = false;
                        //        workflow.UpdatedBy = user.UserName;
                        //        workflow.UpdatedOn = DateTime.Now;
                        //        _dataContext.Entry(workflow).CurrentValues.SetValues(workflow);
                        //    }
                        //}
                        //else
                        //{
                        workflow = _dataContext.cor_workflow.Find(request.WorkflowId);
                        if(workflow == null)
                            workflow = new cor_workflow();


                        workflow.WorkflowName = request.WorkflowName;
                        workflow.WorkflowAccessId = request.WorkflowAccessId;
                        workflow.OperationId = request.OperationId;
                        workflow.ApprovalStatusId = (int)ApprovalStatus.Approved;
                        workflow.Active = true;
                        workflow.Deleted = false;
                        workflow.CreatedBy = workflow.UpdatedBy = user.UserName;
                        workflow.CreatedOn = DateTime.Now;
                        workflow.UpdatedBy = workflow.UpdatedBy = user.UserName;
                        workflow.UpdatedOn = DateTime.Now;
                        workflow.WorkflowId = request.WorkflowId;

                        if (workflow.WorkflowId == 0) _dataContext.cor_workflow.Add(workflow);
                        if (workflow.WorkflowId > 0) _dataContext.Entry(workflow).CurrentValues.SetValues(workflow);


                        if (await _dataContext.SaveChangesAsync() > 0)
                            {
                                foreach (var item in wkfAccesses)
                                {
                                    item.WorkflowId = workflow.WorkflowId;
                                    await _dataContext.cor_workflowaccess.AddAsync(item);
                                }
                                foreach (var item in wkfDetails)
                                {
                                    item.WorkflowId = workflow.WorkflowId;
                                    await _dataContext.cor_workflowdetails.AddAsync(item);
                                    _dataContext.SaveChanges();
                                await AddWorkFlowDetailsAccessAsync(item.WorkflowDetailId, item.OfficeAccessIds.Split(",").Select(int.Parse).ToArray());

                                }
                                await _dataContext.SaveChangesAsync();
                            }
                       // }
                        #endregion

                        //await _repo.AddWorkFlowDetailsAccessAsync();
                        await _trans.CommitAsync();
                        return new WorkflowRespObj
                        {
                            Status = new APIResponseStatus
                            {
                                IsSuccessful = true,
                                Message = new APIResponseMessage
                                {
                                    FriendlyMessage = "Successful"
                                }
                            }
                        };
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        throw new Exception(ex.Message);
                    }
                    finally { await _trans.DisposeAsync(); }
                }
            }
            catch (Exception ex)
            {
                #region Log error to file 
                var errorCode = ErrorID.Generate(4);
                _logger.Error($"ErrorID : {errorCode} Ex : {ex?.Message ?? ex?.InnerException?.Message} ErrorStack : {ex?.StackTrace}");
                return new WorkflowRespObj
                {

                    Status = new APIResponseStatus
                    {
                        IsSuccessful = false,
                        Message = new APIResponseMessage
                        {
                            FriendlyMessage = "Error occured!! Unable to process item",
                            MessageId = errorCode,
                            TechnicalMessage = $"ErrorID : {errorCode} Ex : {ex?.Message ?? ex?.InnerException?.Message} ErrorStack : {ex?.StackTrace}"
                        }
                    }
                };
                #endregion
            }
        }

    }

        // public class AddUpdateWorkflowCommandHandler : IRequestHandler<AddUpdateWorkflowCommand, WorkflowRespObj>
        // {
        //     private readonly ILoggerService _logger;
        //     private readonly IWorkflowRepository _repo;
        //     private readonly UserManager<cor_useraccount> _userManger;
        //     private readonly IHttpContextAccessor _httpContextAccessor;
        //     private readonly DataContext _dataContext; 
        //     public AddUpdateWorkflowCommandHandler(ILoggerService loggerService, IWorkflowRepository repository,
        //         UserManager<cor_useraccount> userManger, IHttpContextAccessor httpContextAccessor, DataContext dataContext)
        //     {
        //         _logger = loggerService;
        //         _repo = repository;
        //         _userManger = userManger;
        //         _dataContext = dataContext;
        //         _httpContextAccessor = httpContextAccessor;
        //     }
        //     public async Task<WorkflowRespObj> Handle(AddUpdateWorkflowCommand request, CancellationToken cancellationToken)
        //     {
        //         var response = new WorkflowRespObj();

        //         try
        //{ 
        //             List<cor_workflowaccess> wkfAccesses = new List<cor_workflowaccess>();
        //             List<cor_workflowdetailsaccess> wkfDetailsAccesses = new List<cor_workflowdetailsaccess>();
        //             List<cor_workflowdetails> wkfDetails = new List<cor_workflowdetails>();

        //             using (var _trans = await _dataContext.Database.BeginTransactionAsync())
        //             {
        //                 try
        //                 {
        //                     #region Check if office access selected matches the companystructure from repository

        //                     if (request.Details.Any())
        //                     {
        //                         var non_selected_details = _dataContext.cor_workflowdetails.Where(e => e.WorkflowId == request.WorkflowId && !request.Details.Select(r => r.WorkflowDetailId).Contains(e.WorkflowDetailId)).ToList();
        //                         if (non_selected_details.Any())
        //                         {
        //                             _dataContext.cor_workflowdetails.RemoveRange(non_selected_details);
        //                             _dataContext.SaveChanges();
        //                         }
        //                         foreach (var workflowDetail in request.Details)
        //                         {
        //                             if (workflowDetail.AccessOfficeIds.Length == 0)
        //                             {
        //                                 await _trans.RollbackAsync();
        //                                 response.Status.Message.FriendlyMessage = $"No office found for workflow detail position {workflowDetail.Position}";
        //                                 return response;
        //                             }
        //                             var result = _dataContext.cor_companystructure.Where(e => request.WorkflowAccessIds.Contains(e.CompanyStructureId)).Select(e => e.CompanyStructureId).ToList();

        //                             //var result = (from compStruct in _dataContext.cor_companystructure
        //                             //              join compStructDef in _dataContext.cor_companystructuredefinition on compStruct.StructureTypeId equals compStructDef.StructureDefinitionId
        //                             //              where workflowDetail.AccessOfficeIds.Contains(compStruct.CompanyStructureId) || workflowDetail.AccessOfficeIds.Contains((int)compStruct.ParentCompanyID)
        //                             //              select compStruct.CompanyStructureId).ToArray();

        //                             string OfficeAccessIds = string.Empty;
        //                             if (result.Any()) OfficeAccessIds = string.Join(',', result);
        //                             var seleted_detail = _dataContext.cor_workflowdetails.Find(workflowDetail.WorkflowDetailId);
        //                             if(seleted_detail == null) seleted_detail = new cor_workflowdetails();


        //                             seleted_detail.WorkflowId = request.WorkflowId;
        //                             seleted_detail.WorkflowGroupId = workflowDetail.WorkflowGroupId;
        //                             seleted_detail.WorkflowLevelId = workflowDetail.WorkflowLevelId;
        //                             seleted_detail.AccessId = workflowDetail.AccessId;
        //                             seleted_detail.Position = workflowDetail.Position;
        //                             seleted_detail.OfficeAccessIds = OfficeAccessIds;
        //                             seleted_detail.OperationId = request.OperationId;
        //                             seleted_detail.WorkflowDetailId = workflowDetail.WorkflowDetailId;
        //                             if(seleted_detail.WorkflowDetailId == 0) wkfDetails.Add(seleted_detail);

        //                         }
        //                     }
        //                     else
        //                     {
        //                         response.Status.Message.FriendlyMessage = "No Workflow details added for this setup";
        //                         return response;
        //                     }
        //                     #endregion

        //                     #region At this point, we check for the workflow access
        //                     if (request.WorkflowAccessIds.Length > 0)
        //                     {
        //                         //var selectedCompanyStructureIds = (from compStruct in _dataContext.cor_companystructure
        //                         //                                   join compStructdef in _dataContext.cor_companystructuredefinition on compStruct.StructureTypeId equals compStructdef.StructureDefinitionId
        //                         //                                   where request.WorkflowAccessIds.Contains(compStruct.CompanyStructureId) || request.WorkflowAccessIds.Contains((int)compStruct.ParentCompanyID)
        //                         //                                   select compStruct.CompanyStructureId).ToArray();

        //                         var selectedCompanyStructureIds = _dataContext.cor_companystructure.Where(e => request.WorkflowAccessIds.Contains(e.CompanyStructureId)).Select(e => e.CompanyStructureId).ToList();



        //                         if (selectedCompanyStructureIds.Any())
        //                         {
        //                             var accesses = _dataContext.cor_workflowaccess.Where(e => selectedCompanyStructureIds.Contains(e.OfficeAccessId)).ToList();
        //                             if (accesses.Any())
        //                             {
        //                                  _dataContext.cor_workflowaccess.RemoveRange(accesses);
        //                                 _dataContext.SaveChanges();
        //                             }


        //                             foreach (var officeAccessId in selectedCompanyStructureIds)
        //                             { 
        //                                 var access = new cor_workflowaccess();
        //                                 access.OfficeAccessId = officeAccessId;
        //                                 access.OperationId = request.OperationId;
        //                                 wkfAccesses.Add(access);
        //                             }
        //                         }
        //                     }
        //                     else
        //                     {
        //                         await _trans.RollbackAsync();
        //                         response.Status.Message.FriendlyMessage = "No Workflow Accesss added for this workflow setup";
        //                         return response;
        //                     }
        //                     #endregion

        //                     #region At this point, there is a check if exist on workflow (ADD||UPDATE)


        //                     var workflow = _dataContext.cor_workflow.Find(request.WorkflowId);
        //                     if (workflow == null)
        //                         workflow = new cor_workflow();

        //                     workflow.WorkflowName = request.WorkflowName;
        //                     workflow.WorkflowAccessId = request.WorkflowAccessId;
        //                     workflow.OperationId = request.OperationId;
        //                     workflow.ApprovalStatusId = workflow.ApprovalStatusId;
        //                     workflow.cor_workflowaccess = wkfAccesses;
        //                     workflow.cor_workflowdetails = wkfDetails;
        //                     if (workflow.WorkflowId == 0) _dataContext.cor_workflow.Add(workflow);

        //                     if (await _dataContext.SaveChangesAsync() > 0)
        //                     {
        //                         foreach (var item in wkfAccesses)
        //                         {
        //                             item.WorkflowId = workflow.WorkflowId; 
        //                         }
        //                         foreach (var item in wkfDetails)
        //                         {
        //                             item.WorkflowId = workflow.WorkflowId;   
        //                         }
        //                         await _dataContext.SaveChangesAsync();
        //                     }
        //                     #endregion

        //                     await _repo.AddWorkFlowDetailsAccessAsync();
        //                     await _trans.CommitAsync();
        //                     response.Status.IsSuccessful = true;
        //                     response.Status.Message.TechnicalMessage = "Successful";
        //                     return response; 
        //                 }
        //                 catch (Exception ex)
        //                 {
        //                    await _trans.RollbackAsync();
        //                     response.Status.Message.FriendlyMessage = ex.Message;
        //                     response.Status.Message.TechnicalMessage = ex.ToString();
        //                     return response;
        //                 }
        //                 finally { await _trans.DisposeAsync(); }
        //             }
        //         }
        //catch (Exception ex)
        //{
        //             #region Log error to file 
        //             var errorCode = ErrorID.Generate(4);
        //             _logger.Error($"ErrorID : AddUpdateWorkflowCommandHandler{errorCode} Ex : {ex?.Message ?? ex?.InnerException?.Message} ErrorStack : {ex?.StackTrace}");
        //             response.Status.Message.FriendlyMessage = ex.Message;
        //             response.Status.Message.TechnicalMessage = ex.ToString();
        //             return response;
        //             #endregion
        //         }
        //     }
        // }
}
