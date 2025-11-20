using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.CreateSubcategory
{
    public class CreateSubcategoryCommand : IRequest<CreateSubcategorycommandResponse>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
