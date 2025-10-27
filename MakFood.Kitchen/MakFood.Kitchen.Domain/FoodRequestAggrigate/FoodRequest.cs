using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;

namespace MakFood.Kitchen.Domain.FoodRequestAggrigate
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
            DateValidator(targetDate);
            IdValidation(userId,"UserId");
            IdValidation(productId,"ProductId");

            Id = Guid.NewGuid();
            UserId = userId;
            ProductId = productId;
            TargetDate = targetDate;
        }

        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateOnly TargetDate { get; private set; }

        #region Validtion 

        /// <summary>
        /// صحت سنجی تاریخ مورد نظر 
        /// </summary>
        /// <param name="targetDate"></param>
        /// <remarks>این تابع نال یا امپتی بودن تاریخ مورد نظر را برسی می کند</remarks>
        public void DateValidator(DateOnly targetDate)
        {
            
            targetDate.CheckNullOrEmpty("target date");

        }

        /// <summary>
        /// برسی و صحت سنجی آیدی
        /// </summary>
        /// <param name="id"></param>
        public void IdValidation(Guid id,string pName)
        {
             id.CheckNullOrEmpty(pName);
        }
        #endregion

    }
}




