using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate.Contract
{
    public interface IDiscountRepository
    {
        /// <summary>
        /// متدی که لیستی از کد تخفیف را بر حسب عنوان متد میاره 
        /// </summary>
        /// <param name="Title">عنوان متد</param>
        /// <param name="cancellationToken"></param>
        /// <returns>لیستی از کد تخفیف</returns>
        public Task<List<Discount>> GetDiscountAccordingToTitle(string Title,CancellationToken cancellationToken);
        /// <summary>
        /// متدی برای اد کردن کد تخفیف
        /// </summary>
        /// <param name="discount">کد تخفیف</param>
        public void Add(Discount discount);
    }
}
