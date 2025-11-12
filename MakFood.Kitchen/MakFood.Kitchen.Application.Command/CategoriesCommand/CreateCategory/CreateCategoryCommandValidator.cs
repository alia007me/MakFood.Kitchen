using FluentValidation;


namespace MakFood.Kitchen.Application.Command.CategoriesCommand.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .NotNull().WithMessage("name canot be null");
        }
    }


}


