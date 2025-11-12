using MediatR;

namespace MakFood.Kitchen.Application.Command.CategoriesCommand.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid Id {  get; set; }
        public string NewName { get; set; } = string.Empty;
    }
}
