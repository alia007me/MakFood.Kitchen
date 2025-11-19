using FluentValidation;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory
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
