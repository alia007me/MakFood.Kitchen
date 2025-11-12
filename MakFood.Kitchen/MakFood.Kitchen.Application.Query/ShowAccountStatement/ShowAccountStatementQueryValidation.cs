using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MakFood.Kitchen.Application.Query.ShowAccountStatement
{
    public class ShowAccountStatementQueryValidation : AbstractValidator<ShowAccountStatementQuery>
    {
        public ShowAccountStatementQueryValidation()
        {
            RuleFor(x => x.CustomerId.ToString()).NotEmpty()
                .WithMessage($"The CustomerId is Not Empty").Matches(@"^[{(]?[0-9A-Fa-f]{8}(-[0-9A-Fa-f]{4}){3}-[0-9A-Fa-f]{12}[)}]?$")
                .WithMessage("The entered ID is not valid.");
            RuleFor(x => x.StartDateTime).NotEmpty().WithMessage("The DateTime is Not Empty")
                .When(x => x.StartDateTime < DateTime.Now && x.StartDateTime <= x.EndDateTime).WithMessage("The entered Date is not valid.");
            RuleFor(x => x.EndDateTime).NotEmpty().WithMessage("The DateTime is Not Empty")
              .When(x => x.EndDateTime <= DateTime.Now && x.EndDateTime >= x.StartDateTime).WithMessage("The entered Date is not valid.");
        }
    }
}
