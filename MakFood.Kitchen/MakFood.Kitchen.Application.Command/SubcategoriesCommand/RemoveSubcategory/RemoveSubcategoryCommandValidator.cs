using FluentValidation;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.RemoveSubcategory
{
    public partial class RemoveSubcategoryCommandHandler
    {
        public class RemoveSubcategoryCommandValidator : AbstractValidator<RemoveSubcategoryCommand>
        {
            public RemoveSubcategoryCommandValidator()
            {
                RuleFor(x => x.SubCategoryId)
                    .NotEmpty()
                    .WithMessage("Subcategory Id cannot be empty");
            }
        }
    }
}


