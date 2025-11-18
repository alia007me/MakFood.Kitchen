using FluentValidation;

namespace MakFood.Kitchen.Application.Command.UpdateProduct
{
    public class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidation()
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
                .WithMessage("The SubCategoryId is Not Empty");
            
            RuleFor(x => x.SubCategoryName).NotEmpty()
          .WithMessage("The SubCategoryName is Not Empty")
          .MaximumLength(25)
           .WithMessage("The SubCategoryName is Not Valid");

            RuleFor(x => x.Price).NotEmpty()
                .WithMessage("The Price is Not Empty")
                .When(w => w.Price >= 0).WithMessage("The Price is Not Negative");

            RuleFor(x => x.QuantityToIncrease).NotEmpty()
                .WithMessage("The QuantityToIncrease is Not Empty")
                .When(w => w.QuantityToIncrease >= 0).WithMessage("The AvailableQuantity is Not Negative");

            RuleFor(x => x.QuantityToDecrease).NotEmpty()
                .WithMessage("The QuantityToDecrease is Not Empty")
                .When(w => w.QuantityToDecrease >= 0).WithMessage("The AvailableQuantity is Not Negative");
        }
    }
    }


