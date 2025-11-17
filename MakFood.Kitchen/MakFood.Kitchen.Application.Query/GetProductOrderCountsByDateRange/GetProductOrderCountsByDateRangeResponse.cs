using static MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract.IProductRepository;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public record GetProductOrderCountsByDateRangeResponse(IEnumerable<GetProductOrderCountsReadModel> GetProductOrderCountsByDateRange);
}
