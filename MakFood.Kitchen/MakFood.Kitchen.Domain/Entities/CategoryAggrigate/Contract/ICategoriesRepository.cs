namespace MakFood.Kitchen.Domain.Entities.CategoryAggrigate.Contract
{
    public interface ICategoriesRepository
    {
        /// <summary>
        /// متدی که لیستی از ساب کتگوری رو از تیبل کتگوری بر حسب ایدی ساب کتگوری میاره
        /// </summary>
        /// <param name="subCategoryId">ایدی ساب کتگوری</param>
        /// <param name="ct"></param>
        /// <returns>لیستی از ساب کتگوری</returns>
        Task<Subcategory> GetSubCategoryByIdAsync(Guid subCategoryId, CancellationToken ct);
    }
}
