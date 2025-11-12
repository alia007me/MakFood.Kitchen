using MediatR;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.RemoveCategory
{
    public class RemoveCategoryCommand : IRequest<RemoveCategoryCommandResponse>
    {
        public Guid Id {  get; set; }
    }
}
