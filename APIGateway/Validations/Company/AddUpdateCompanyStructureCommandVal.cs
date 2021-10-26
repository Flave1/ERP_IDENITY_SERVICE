using APIGateway.Contracts.Commands.Company;
using APIGateway.Data;
using FluentValidation;
using GODPAPIs.Contracts.Response.CompanySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Validations.Company
{
    public class AddUpdateCompanyStructureCommandVal : AbstractValidator<AddUpdateCompanyStructureCommand>
    {
        private readonly DataContext _dataContext;
        public AddUpdateCompanyStructureCommandVal(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e).MustAsync(NoDuplicateAsync).WithMessage("Duplicate setup detected");
        }
        private async Task<bool> NoDuplicateAsync(AddUpdateCompanyStructureCommand request, CancellationToken cancellationToken)
        { 
            if (request.CompanyStructureId > 0)
            {
                var item = _dataContext.cor_companystructure.FirstOrDefault(e => e.Name == request.Name && e.CompanyStructureId != request.CompanyStructureId && e.Deleted == false);
                if (item != null)
                {
                    return await Task.Run(() => false);
                }
                return await Task.Run(() => true);
            }
            if (_dataContext.cor_companystructure.Count(e => e.Name == request.Name && e.Deleted == false) >= 1)
            {
                return await Task.Run(() => false);
            }
            return await Task.Run(() => true);
        }
    }

    //public class CompanyStructureDefinitionObjCommandVal : AbstractValidator<CompanyStructureDefinitionObj>
    //{
    //    private readonly DataContext _dataContext;
    //    public CompanyStructureDefinitionObjCommandVal(DataContext dataContext)
    //    {
    //        _dataContext = dataContext;
    //        RuleFor(e => e.Definition).NotEmpty();
    //        RuleFor(e => e).MustAsync(NoDuplicateAsync).WithMessage("Duplicate setup detected");
    //    }
    //    private async Task<bool> NoDuplicateAsync(CompanyStructureDefinitionObj request, CancellationToken cancellationToken)
    //    {
    //        if (request.StructureDefinitionId > 0)
    //        {
    //            var item = _dataContext.cor_companystructuredefinition.FirstOrDefault(e => e.Definition.ToLower() == request.Definition.ToLower() && e.StructureDefinitionId != request.StructureDefinitionId && e.Deleted == false);
    //            if (item != null)
    //            {
    //                return await Task.Run(() => false);
    //            }
    //            return await Task.Run(() => true);
    //        }
    //        if (_dataContext.cor_companystructuredefinition.Count(e => e.Definition.ToLower() == request.Definition.ToLower() && e.Deleted == false) >= 1)
    //        {
    //            return await Task.Run(() => false);
    //        }
    //        return await Task.Run(() => true);
    //    }
    //}
}
