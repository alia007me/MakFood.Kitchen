using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Query.QueryBases.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void ThrowIfNeeded(this ValidationResult validationResult)
        {
            var errors = validationResult.Errors;

            if (errors.Any())
                throw new ApplicationException(string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage)));
        }
    }
}
