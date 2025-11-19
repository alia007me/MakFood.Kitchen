using FluentValidation;

namespace MakFood.Kitchen.Application.Command.AddDiscount
{
    public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
    {
        public CreateDiscountCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .WithMessage("Please Enter The Title !");

            RuleFor(x => x.Percent).NotEmpty()
                .WithMessage("Please Enter The Percent !");

            RuleFor(x => x.MaximumBalance).NotEmpty()
               .WithMessage("Please Enter The MaximumBalance !")
               .When(W => W.MaximumBalance >= W.MinimumBalance)
               .WithMessage("This is not Valid");

            RuleFor(x => x.MinimumBalance).NotEmpty()
               .WithMessage("Please Enter The MinimumBalance !")
               .When(W => W.MaximumBalance >= W.MinimumBalance)
               .WithMessage("This is not Valid"); ;

            RuleFor(x => x.ExpiryDate).NotEmpty()
               .WithMessage("Please Enter The ExpiryDate !");


            RuleFor(x => x.DiscountPolicy).NotEmpty()
               .WithMessage("Please Enter The DiscountPolicy !");

        }
    }
