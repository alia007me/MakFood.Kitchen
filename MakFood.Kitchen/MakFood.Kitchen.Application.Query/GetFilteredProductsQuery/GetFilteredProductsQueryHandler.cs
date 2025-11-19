using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using MediatR;

namespace MakFood.Kitchen.Application.Query.GetFilteredProductsQuery
{
    public class GetFilteredProductsQueryHandler : IRequestHandler<GetFilteredProductsQuery, GetFilteredProductsQueryResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetFilteredProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetFilteredProductsQueryResponse> Handle(GetFilteredProductsQuery request, CancellationToken ct)
        {

            // اگر همه پارامترهای فیلتر null باشند، هیچ محصولی برگردانده نمی‌شود
            if (string.IsNullOrWhiteSpace(request.Name) && !request.CategoryId.HasValue && !request.SubcategoryId.HasValue)
            {
                return new GetFilteredProductsQueryResponse
                {
                    Products = new List<ProductDto>()
                };
            }
            var products = await _productRepository.FilterAsync(
                request.Name,
                request.CategoryId,
                request.SubcategoryId,
                ct);

            var productDtos = products
                .Select(p => new ProductDto(
                    p.ProductId,
                    p.ProductName,
                    p.Price,
                    p.SubCategoryName
                ))
                .ToList();

            return new GetFilteredProductsQueryResponse
            {
                Products = productDtos
            };
        }
    }

}

