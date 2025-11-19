namespace MakFood.Kitchen.Application.Query.GetFilteredProductsQuery
{
    public record ProductDto(
        Guid ProductId,
        string ProductName,
        decimal Price,
        string SubCategoryName
    );

}

