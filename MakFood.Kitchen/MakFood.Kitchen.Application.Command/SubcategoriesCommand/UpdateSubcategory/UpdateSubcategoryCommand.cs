using MediatR;

namespace MakFood.Kitchen.Application.Command.SubcategoriesCommand.UpdateSubcategory
{
    public class UpdateSubcategoryCommand : IRequest<UpdateSubcategoryCommandResponse>
    {
        public Guid SubCategoryId { get; set; }
        public Guid CategoryId { get; set; }
        public string NewName { get; set; } = string.Empty;
    }
}
