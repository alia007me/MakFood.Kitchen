using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;

namespace MakFood.Kitchen.Domain.Entities.FoodRequestAggrigate
{
    /// <summary>
    /// پیشنهاد غذا برای یک روز خاص
    /// </summary>
    public class FoodRequest : BaseEntity<Guid>
    {
        /// <summary>
        /// کانستراکتور کلاس فود ریکویست
        /// </summary>
        /// <param name="userId">ایدی یوزر</param>
        /// <param name="productId">ایدی محصول</param>
        /// <param name="targetDate">تاریخ مورد نظر</param>
        public FoodRequest(Guid userId, Guid productId, DateOnly targetDate)
        {
            Check(new FoodRequestDateMustBeInFutureBR(targetDate));

            Id = Guid.NewGuid();
            UserId = userId;
            ProductId = productId;
            TargetDate = targetDate;
        }

        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateOnly TargetDate { get; private set; }


    }
}




