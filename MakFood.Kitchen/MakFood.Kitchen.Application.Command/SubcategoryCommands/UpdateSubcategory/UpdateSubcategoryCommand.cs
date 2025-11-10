using MediatR;


namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory
{
    public class UpdateSubcategoryCommand : IRequest<UpdateSubcategoryCommandResponse>
    {
        public Guid Id { get; set; }
        public string NewName { get; set; } = string.Empty;
    }
}
