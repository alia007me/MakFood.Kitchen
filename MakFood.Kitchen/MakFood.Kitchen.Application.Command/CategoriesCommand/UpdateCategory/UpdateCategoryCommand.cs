using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory
{

    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string NewName { get; set; } = string.Empty;
    }
}
