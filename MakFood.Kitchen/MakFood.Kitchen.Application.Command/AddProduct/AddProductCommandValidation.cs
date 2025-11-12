using FluentValidation;

namespace MakFood.Kitchen.Application.Command.AddProduct
{
    public class AddProductCommandValidation : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
           .WithMessage("The Name is Not Empty")
           .MaximumLength(25)
           .WithMessage("The Name is Not Valid");
            RuleFor(x => x.Description).NotEmpty()
                .WithMessage("The Description is Not Empty")
                .MaximumLength(50)
           .WithMessage("The Description is Not Valid");
            RuleFor(x => x.ThumbnailPath).NotEmpty()
          .WithMessage("The ThumbnailPath is Not Empty")
          .MaximumLength(50)
           .WithMessage("The ThumbnailPath is Not Valid");
            RuleFor(x => x.SubCategoryId.ToString()).NotEmpty()
                .WithMessage("The SubCategoryId is Not Empty")
            .Matches(@"^[{(]?[0-9A-Fa-f]{8}(-[0-9A-Fa-f]{4}){3}-[0-9A-Fa-f]{12}[)}]?$")
                .WithMessage("The entered Id is not valid.");
            RuleFor(x => x.SubCategoryName).NotEmpty()
          .WithMessage("The SubCategoryName is Not Empty")
          .MaximumLength(25)
           .WithMessage("The SubCategoryName is Not Valid");
            RuleFor(x => x.Price).NotEmpty()
                .WithMessage("The Price is Not Empty")
                .When(w => w.Price >= 0).WithMessage("The Price is Not Negative");
            RuleFor(x => x.AvailableQuantity).NotEmpty()
                .WithMessage("The AvailableQuantity is Not Empty")
                .When(w => w.AvailableQuantity >= 0).WithMessage("The AvailableQuantity is Not Negative");

        }
    }
}
