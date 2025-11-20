namespace MakFood.Kitchen.Application.Query.GetFoodRequestsByDateRange
{
    public record GetFoodRequestsByDateDto(Guid ProductId,
                                           string ProductName,
                                           long Count
        );
}
