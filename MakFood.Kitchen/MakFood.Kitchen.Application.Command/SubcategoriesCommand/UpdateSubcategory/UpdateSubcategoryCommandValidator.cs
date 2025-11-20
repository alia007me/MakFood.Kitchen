using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.UpdateSubcategory
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
