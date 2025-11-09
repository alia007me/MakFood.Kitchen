using FluentValidation;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Category Id cannot be empty");

            RuleFor(x => x.NewName)
                .NotEmpty()
                .WithMessage("NewName cannot be empty");
        }
    }
}
