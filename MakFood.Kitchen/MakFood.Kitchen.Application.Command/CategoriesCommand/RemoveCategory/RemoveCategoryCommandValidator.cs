using FluentValidation;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory
{
    public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
    {
        public RemoveCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Category Id cannot be empty");
        }
    }
}
