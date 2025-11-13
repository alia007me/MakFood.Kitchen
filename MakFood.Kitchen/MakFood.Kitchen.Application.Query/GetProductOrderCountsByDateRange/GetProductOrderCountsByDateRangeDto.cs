using MakFood.Kitchen.Domain.Entities.ProductAggrigate.Contract;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace MakFood.Kitchen.Application.Query.GetProductOrderCountsByDateRange
{
    public record GetProductOrderCountsByDateRangeDto(Guid ProductId,
                                                      string ProductName,
                                                      long Count
                                                      );

}
