using FluentValidation.Results;
using MakFood.Kitchen.Infrastructure.Substructure.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.CommandBases.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void ThrowIfNeeded(this ValidationResult validationResult)
        {
            var errors = validationResult.Errors;

            if (errors.Any())
                throw new Infrastructure.Substructure.Exceptions.ApplicationException(string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage)));
        }
    }
}
