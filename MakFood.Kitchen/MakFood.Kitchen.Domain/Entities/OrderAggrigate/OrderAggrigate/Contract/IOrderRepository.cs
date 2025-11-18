using MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.OrederState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Entities.OrderAggrigate.OrderAggrigate.Contract
{
    public interface IOrderRepository
    {
        /// <summary>
        /// متد برای گرفتن صورت حساب های موفق 
        /// </summary>
        /// <param name="CustomerId">ایدی مشتری</param>
        /// <param name="StartDateTime">تاریخ شروع بازه مورد نظر </param>
        /// <param name="EndDateTime">تاریخ پایان بازه مورد نظر</param>
        /// <returns>لیستی از صورت حساب های موفق در بازه مورد نظر </returns>
        Task<List<Order>> GetOrderByCustomerIdAsync(Guid CustomerId, DateTime StartDateTime, DateTime EndDateTime);
    }
}
