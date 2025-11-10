using MediatR;

namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.CreateSubcategory
{
    public class CreateSubcategoryCommand : IRequest<CreateSubcategorycommandResponse>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

    }
}
