using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.FoodRequest
{
    public class FoodRequest : BaseEntity<TId>
    {
        public FoodRequest(Guid userId, Guid productId, DateOnly targetDate)
        {
            this.userId = userId;
            ProductId = productId;
            TargetDate = targetDate;
        }

        public Guid userId { get; set; }
        public Guid ProductId { get; set; }
        public DateOnly TargetDate { get; set; }

        #region CHECK VALIDATOR OF THE REQUEST DATE
        public bool DateValidator(DateOnly dateOnly)
        {
            return dateOnly <= DateOnly.FromDateTime(DateTime.Now.AddDays(7));

        }
        #endregion
    }
}






