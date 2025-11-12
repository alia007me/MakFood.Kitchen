using FluentValidation;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory
{
    public class CreateSubcategoryValidator : AbstractValidator<CreateSubcategoryCommand>
    {
        public CreateSubcategoryValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("category Id is required");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Subcategory name cannot be empty");

        }
    }
}
