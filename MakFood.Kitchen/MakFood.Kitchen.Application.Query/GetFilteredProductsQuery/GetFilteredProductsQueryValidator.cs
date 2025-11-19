using FluentValidation;

namespace MakFood.Kitchen.Application.Query.GetFilteredProductsQuery
{
    public class GetFilteredProductsQueryValidator : AbstractValidator<GetFilteredProductsQuery>
    {
        public GetFilteredProductsQueryValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .When(x => x.CategoryId.HasValue)
                .WithMessage("CategoryId cannot be empty Guid.");

            RuleFor(x => x.SubcategoryId)
                .NotEmpty()
                .When(x => x.SubcategoryId.HasValue)
                .WithMessage("SubcategoryId cannot be empty Guid.");
        }
    }

}

