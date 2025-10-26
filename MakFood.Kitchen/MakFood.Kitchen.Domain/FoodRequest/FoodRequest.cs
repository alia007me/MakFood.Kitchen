using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;

namespace MakFood.Kitchen.Domain.FoodRequest
{
    /// <summary>
    /// پیشنهاد غذا برای خاله
    /// </summary>
    public class FoodRequest : BaseEntity<Guid>
    {
        /// <summary>
        /// کانستراکتور کلاس فود ریکویست
        /// </summary>
        /// <param name="userId">ایدی یوزر</param>
        /// <param name="productId">ایدی محصول</param>
        /// <param name="targetDate">زمان مورد نظر</param>
        public FoodRequest(Guid userId, Guid productId, DateOnly targetDate)
        {
            DateValidator(targetDate);
            IdValidation(userId);
            IdValidation(productId);

            Id = Guid.NewGuid();
            UserId = userId;
            ProductId = productId;
            TargetDate = targetDate;
        }

        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateOnly TargetDate { get; private set; }

        #region validtion 
        /// <summary>
        /// چک کردن نال نبودن زمان 
        /// </summary>
        /// <param name="dateOnly"></param>
        /// <returns></returns>

        public void DateValidator(DateOnly dateOnly)
        {
            dateOnly.CheckNullOrEmpty("target date");

        }
        /// <summary>
        /// چک کردن نال نبودن ایدی پروداکت
        /// </summary>
        /// <param name="id"></param>
        public void IdValidation(Guid id)
        {
             id.CheckNullOrEmpty("ProductId");
        }
        #endregion

    }
}






