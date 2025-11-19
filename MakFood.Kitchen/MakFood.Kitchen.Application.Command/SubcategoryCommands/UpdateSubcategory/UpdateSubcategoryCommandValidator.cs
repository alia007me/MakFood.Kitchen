using FluentValidation;


namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory
{
    public partial class UpdateSubcategoryCommandValidator : AbstractValidator<UpdateSubcategoryCommand>
    {
        public UpdateSubcategoryCommandValidator()
        {
            RuleFor(x => x.SubCategoryId)
                .NotEmpty()
                .WithMessage("Subcategory Id cannot be empty");

            RuleFor(x => x.NewName)
                .NotEmpty()
                .WithMessage("New name cannot be empty");
        }

    }
}
