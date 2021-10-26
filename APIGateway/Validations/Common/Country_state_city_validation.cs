using APIGateway.Contracts.Commands.Common;
using APIGateway.Data;
using APIGateway.Handlers.Common;
using FluentValidation;
using GODP.APIsContinuation.DomainObjects.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APIGateway.Validations.Common
{
    public class Country_state_city_validation : AbstractValidator<AddUpdateStateCommand>
    {
        private readonly DataContext _dataContext;
        public Country_state_city_validation(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.CountryId).NotEmpty().WithMessage("Country required");
            RuleFor(e => e.Code).NotEmpty().WithMessage("State code required");
            RuleFor(e => e).MustAsync(NoDuplicateAsync).WithMessage("Dupliacte setup detected");
        }
        private async Task<bool> NoDuplicateAsync(AddUpdateStateCommand request, CancellationToken cancellationToken)
        {
            if (request.StateId > 0)
            {
                var item = _dataContext.cor_state.FirstOrDefault(e => e.StateName.ToLower() == request.Name.ToLower() && e.StateId != request.StateId && e.Deleted == false);
                if (item != null)
                {
                    return await Task.Run(() => false);
                }
                return await Task.Run(() => true);
            }
            if (_dataContext.cor_state.Count(e => e.StateName.ToLower() == request.Name.ToLower() && e.Deleted == false) >= 1)
            {
                return await Task.Run(() => false);
            }
            return await Task.Run(() => true);
        }
    }

    public class Country_city_validation : AbstractValidator<AddUpdateCityCommand>
    {
        private readonly DataContext _dataContext;
        public Country_city_validation(DataContext dataContext)
        {
            _dataContext = dataContext;
            RuleFor(e => e.StateId).NotEmpty();
            RuleFor(e => e.CityCode);
            RuleFor(e => e.CityName).NotEmpty().WithMessage("name required");
            RuleFor(e => e).MustAsync(NoDuplicateAsync).WithMessage("Dupliacte setup detected");
        }
        private async Task<bool> NoDuplicateAsync(AddUpdateCityCommand request, CancellationToken cancellationToken)
        {
            if (request.CityId > 0)
            {
                var item = _dataContext.cor_city.FirstOrDefault(e => e.CityName.ToLower() == request.CityName.ToLower() && e.CityId != request.CityId && e.Deleted == false);
                if (item != null)
                {
                    return await Task.Run(() => false);
                }
                return await Task.Run(() => true);
            }
            if (_dataContext.cor_city.Count(e => e.CityName.ToLower() == request.CityName.ToLower() && e.Deleted == false) >= 1)
            {
                return await Task.Run(() => false);
            }
            return await Task.Run(() => true);
        }
    }
}
