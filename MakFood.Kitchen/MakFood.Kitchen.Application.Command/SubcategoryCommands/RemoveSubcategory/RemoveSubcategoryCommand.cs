using MediatR;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.RemoveSubcategory
{
    public class RemoveSubcategoryCommand : IRequest<RemoveSubcategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
    }
