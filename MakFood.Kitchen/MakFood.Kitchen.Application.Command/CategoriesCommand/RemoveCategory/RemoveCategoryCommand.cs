using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory
{
    public class RemoveCategoryCommand : IRequest<RemoveCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
