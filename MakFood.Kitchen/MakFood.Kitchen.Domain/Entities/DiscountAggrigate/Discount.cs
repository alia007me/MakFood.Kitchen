using MakFood.Kitchen.Domain.BussinesRules;
using MakFood.Kitchen.Domain.Entities.Base;
using MakFood.Kitchen.Domain.Entities.DiscountAggrigate.DiscountPolicyAggrigate;
using System.Text.RegularExpressions;


namespace MakFood.Kitchen.Domain.Entities.DiscountAggrigate
{
    /// <summary>
    /// مدل کد تخفیف که کد تخفیف مربوط به سفارش می باشد
    /// </summary>
    public class Discount : BaseEntity<Guid>
    {
        /// <summary>
        /// کانستراکتور کلاس دیسکانت کد با ورودی نام کد تخفیف برای 
        /// </summary>
        /// <param name="title">اسم کد تخفیف</param>
        /// <param name="expiryDate">تاریخ انقضا کد تخفیف</param>
        /// <param name="maximumBalance">ماکسیموم حق کد تخفیف</param>
        /// <param name="minimumBalance">مینیموم حق کد تخفیف</param>
        public Discount(string title,uint discountPercentage, DiscountPolicy policy,
                            DateOnly expiryDate, decimal maximumBalance,
                            decimal minimumBalance)
        {
            Check(new DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR(title));
            Check(new DiscountPercentageMustBeBetweenZeroAndOnehundredBR(discountPercentage));
            Check(new DiscountExpiryDateMustBeInFutureBR(expiryDate));
            LimitBalanceValibation(maximumBalance, minimumBalance);

            Id = Guid.NewGuid();
            this.Title = title;         
            DiscountPolicy = policy;
            ExpiryDate = expiryDate;
            MaximumBalance = maximumBalance;
            MinimumBalance = minimumBalance;
            Percent = discountPercentage;

        }

        public string Title { get; private set; }
        public decimal Percent { get;private set; }
        public DateOnly ExpiryDate { get; private set; }
        public decimal MaximumBalance { get; private set; }
        public decimal MinimumBalance { get; private set; }
        public DiscountPolicy DiscountPolicy { get; private set; }

        #region Validation


        /// <summary>
        /// صحت سنجی کلی سقف و کف قیمت تخفیف
        /// </summary>
        /// <param name="maximum"></param>
        /// <param name="minimum"></param>
        /// <remarks>برای هر پارامتر برسی می کند که نال، امپتی یا کوچکتر و یا برابر با صفر نباشد و پس از آن برسی می کند که
        /// کف قیمت از سقف قیمت بیشتر نباشد</remarks>
        private void LimitBalanceValibation(decimal maximum, decimal minimum)
        {
            Check(new LimitBalanceMustBePositiveBR(maximum));
            Check(new LimitBalanceMustBePositiveBR(minimum));
            Check(new TheMaximumBalanceMustBeGreaterThanTheMinimumBalanceBR(minimum, maximum));
        }

        #endregion

        #region Behavior

        /// <summary>
        /// برسی می کند که یوزر با این آیدی میتواند از تخفیف استفاده کند
        /// </summary>
        /// <param name="CustomerId">آیدی کاستومر</param>
        /// <returns>اگر بتواند درست و اگر مجاز به استفاده نباشد غلط را بر میگرداند</returns>
        /// <remarks>این متد آیدی کاربر مورد نظر را گرفته و برسی می کند که کاربر حق استفاده از این کد تخفیف را دارد یا نه</remarks>
        public bool AvailableForCustomer(Guid CustomerId)
        {
            return DiscountPolicy.IsPermitted(CustomerId);
        }

        #endregion


    }
}
