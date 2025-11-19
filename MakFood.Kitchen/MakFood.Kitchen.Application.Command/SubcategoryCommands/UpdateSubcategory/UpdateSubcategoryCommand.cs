using MediatR;


namespace MakFood.Kitchen.Application.Command.SubcategoryCommands.UpdateSubcategory
{
    public class UpdateSubcategoryCommand : IRequest<UpdateSubcategoryCommandResponse>
    {
        public Guid SubCategoryId { get; set; }
        public Guid CategoryId { get; set; }  
        public string NewName { get; set; } = string.Empty;
    }
}
