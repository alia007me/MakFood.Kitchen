using MakFood.Kitchen.Application.Query.GetCategories;
using MakFood.Kitchen.Application.Query.GetSubcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Query.GetCategories
{
    public record CategoryDto(Guid Id,
        string Name,
        List<SubcategoryDto> Subcategories
        );





}
