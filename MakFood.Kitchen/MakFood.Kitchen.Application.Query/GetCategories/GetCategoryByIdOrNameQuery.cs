using MediatR;

namespace MakFood.Kitchen.Application.Query.GetCategories
{
    public class GetCategoryByIdOrNameQuery : IRequest<CategoryDto>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }





}
