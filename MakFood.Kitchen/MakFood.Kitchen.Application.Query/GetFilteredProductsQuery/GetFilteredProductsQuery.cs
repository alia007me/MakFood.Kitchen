using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Application.Query.GetFilteredProductsQuery
{
    public class GetFilteredProductsQuery : IRequest<GetFilteredProductsQueryResponse>
    {
        public string? Name { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SubcategoryId { get; set; }
    }

}

