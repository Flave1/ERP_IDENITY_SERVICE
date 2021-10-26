using APIGateway.Data;
using FluentValidation;
using GODPAPIs.Contracts.Commands.Company;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GODP.APIsContinuation.Validations.Company
{
    public class AddUpdateCompanyCommandVal : AbstractValidator<AddUpdateCompanyCommand>
    {
        private DataContext _dataContext;
        public AddUpdateCompanyCommandVal(DataContext dataContext)
        {
            _dataContext = dataContext;

            RuleFor(x => x.Address1).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.CountryId).NotEmpty();
            RuleFor(x => x.CurrencyId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Telephone).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.Address1).NotEmpty();
        }

       
    }
}
