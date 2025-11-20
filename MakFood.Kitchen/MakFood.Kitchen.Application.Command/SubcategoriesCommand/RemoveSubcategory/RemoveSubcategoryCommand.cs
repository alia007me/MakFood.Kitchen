using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MakFood.Kitchen.Application.Command.SubcategoriesCommand.RemoveSubcategory.RemoveSubcategoryCommandHandler;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.RemoveSubcategory
{
    public class RemoveSubcategoryCommand : IRequest<RemoveSubcategoryCommandResponse>
    {
        public Guid SubCategoryId { get; set; }
    }
}


