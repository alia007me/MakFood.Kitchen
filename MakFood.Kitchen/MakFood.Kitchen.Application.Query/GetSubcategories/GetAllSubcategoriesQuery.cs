using MediatR;

namespace MakFood.Kitchen.Application.Query.GetSubcategories
{
    public class GetAllSubcategoriesQuery : IRequest<List<SubcategoryDto>> { }
}
