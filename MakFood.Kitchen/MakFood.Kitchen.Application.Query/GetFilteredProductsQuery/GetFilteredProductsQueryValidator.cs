using FluentValidation;

namespace MakFood.Kitchen.Application.Query.GetFilteredProductsQuery
{
    public class GetFilteredProductsQueryValidator : AbstractValidator<GetFilteredProductsQuery>
    {
        public GetFilteredProductsQueryValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                  .When(x => !string.IsNullOrWhiteSpace(x.Name))
                .WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.CategoryId)
                .Must(id => !id.HasValue || id.Value != Guid.Empty)
                .WithMessage("CategoryId cannot be an empty Guid.");

            RuleFor(x => x.SubcategoryId)
                .Must(id => !id.HasValue || id.Value != Guid.Empty)
                .WithMessage("SubcategoryId cannot be an empty Guid.");
        }
    }

}

