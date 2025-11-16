using MediatR;

namespace MakFood.Kitchen.Application.Query.GetSubcategories
{
    public class GetSubcategoryByIdOrNameQuery : IRequest<SubcategoryDto>
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
