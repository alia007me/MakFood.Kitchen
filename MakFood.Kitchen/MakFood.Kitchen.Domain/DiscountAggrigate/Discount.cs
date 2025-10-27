using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Domain.DiscountCodeAggrigate.DiscountPolicyAggrigate;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System.Text.RegularExpressions;


namespace MakFood.Kitchen.Domain.DiscountCodeAggrigate
{
    /// <summary>
    /// مدل کد تخفیف که کد تخفیف مربوط به سفارش می باشد
    /// </summary>
    public class Discount : BaseEntity<Guid>
    {
        /// <summary>
        /// کانستراکتور کلاس دیسکانت کد با ورودی نام کد تخفیف برای 
        /// </summary>
        /// <param name="discoutCoteName">اسم کد تخفیف</param>
        /// <param name="expiryDate">تاریخ انقضا کد تخفیف</param>
        /// <param name="maximumBalance">ماکسیموم حق کد تخفیف</param>
        /// <param name="minimumBalance">مینیموم حق کد تخفیف</param>
        public Discount(string discoutCoteName,uint discountPercentage, DiscountPolicy policy,
                            DateOnly expiryDate, decimal maximumBalance,
                            decimal minimumBalance)
        {
            DiscountTitleValidation(discoutCoteName);
            DiscountPercentageValidation(discountPercentage);
            DiscountDateTimeValidation(expiryDate);
            MaximumMinimumBalanceValibation(maximumBalance, minimumBalance);

            Id = Guid.NewGuid();
            Title = discoutCoteName;
            DiscountPolicy = policy;
            ExpiryDate = expiryDate;
            MaximumBalance = maximumBalance;
            MinimumBalance = minimumBalance;
            Percent = discountPercentage;

        }

        public string Title { get; private set; }
        public Decimal Percent { get;private set; }
        public DateOnly ExpiryDate { get; private set; }
        public decimal MaximumBalance { get; private set; }
        public decimal MinimumBalance { get; private set; }
        public DiscountPolicy DiscountPolicy { get; private set; }

        #region Validation
        /// <summary>
        /// صحت سنجی مقدار درصد تخفیف
        /// </summary>
        /// <param name="percentage"></param>
        private void DiscountPercentageValidation(decimal percentage)
        {
            percentage.CheckNullOrEmpty("Discount percentage");
            const int minLimitValue = 0;
            const int maxLimitValue = 100;

            if (percentage > maxLimitValue || percentage < minLimitValue) throw new ArgumentOutOfRangeException("Discount percentage");



        }

        /// <summary>
        /// صحت سنجی کلی سقف و کف قیمت تخفیف
        /// </summary>
        /// <param name="maximum"></param>
        /// <param name="minimum"></param>
        /// <remarks>برای هر پارامتر برسی می کند که نال، امپتی یا کوچکتر و یا برابر با صفر نباشد و پس از آن برسی می کند که
        /// کف قیمت از سقف قیمت بیشتر نباشد</remarks>
        private void MaximumMinimumBalanceValibation(decimal maximum, decimal minimum)
        {
            DiscountDesimalMaximumValidation(maximum);
            DiscountDesimalMinimumValidation(minimum);
            CheckForCorrectMaximumAndMinimum(maximum, minimum);
        }

        /// <summary>
        /// صحت سنجی نام
        /// </summary>
        /// <param name="discoutCodeName"></param> 
        private void DiscountTitleValidation(string discoutCodeName)
        {
            discoutCodeName.CheckNullOrEmpty("discoutCodeName");
            var discountCodeRegexPattern = "([A-Za-z0-9])\\w";
            if (!Regex.IsMatch(discountCodeRegexPattern, discoutCodeName)) throw new Exception("The name should only have A-Za-z0-9");
        }

        /// <summary>
        /// صحت سنجی تاریخ انقضای کد تخفیف
        /// </summary>
        /// <param name="ExpiryDate"></param>
        private void DiscountDateTimeValidation(DateOnly ExpiryDate)
        {
            ExpiryDate.CheckNullOrEmpty("Expiry Date");
        }

        /// <summary>
        /// صحت سنجی مقدار پایه تخفیف
        /// </summary>
        /// <param name="maximumBalance"></param>
        private void DiscountDesimalMaximumValidation(decimal maximumBalance)
        {
            maximumBalance.CheckNullOrEmpty("maximumBalance");
            CheckDesimalMaximumMinimum(maximumBalance, "maximum");
        }
        /// <summary>
        /// صحت سنجی سقف تخفیف
        /// </summary>
        /// <param name="minimumBalance"></param>
        private void DiscountDesimalMinimumValidation(decimal minimumBalance)
        {
            minimumBalance.CheckNullOrEmpty("minimumBalance");
            CheckDesimalMaximumMinimum(minimumBalance, "Minimum");

        }

        /// <summary>
        /// صحت سنجی بیشتر بودن سقف قیمت تخفیف از کف قیمت آن
        /// </summary>
        private void CheckForCorrectMaximumAndMinimum(decimal maximum, decimal minimum)
        {
            if (maximum <= minimum)
                throw new ArgumentException("The maximum must not be less than equal minimum");

        }

        /// <summary>
        /// برسی می کند مقدار قیمت ورودی منفی نباشد
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="mOM">این که ورودی ماکزیمم یا مینیمم (برای هندل کردن اکسپشن به نحو بهتر) می باشد</param>
        /// <exception cref="ArgumentException"></exception>
        private void CheckDesimalMaximumMinimum(decimal balance, string mOM) //Maximum or minimum : mOM
        {
            if (balance <= 0)
                throw new ArgumentException($"{mOM} Balance can not to be Zero And Negative");
        }
        private void DiscountPolicyValidator(DiscountPolicy policy)
        {
            policy.CheckNullOrEmpty("Policy");
        }

        #endregion

        #region Behavior

        /// <summary>
        /// برسی می کند که یوزر با این آیدی میتواند از تخفیف استفاده کند
        /// </summary>
        /// <param name="CustomerId">آیدی کاستومر</param>
        /// <returns>اگر بتواند درست و اگر مجاز به استفاده نباشد غلط را بر میگرداند</returns>
        /// <remarks>این متد آیدی کاربر مورد نظر را گرفته و برسی می کند که کاربر حق استفاده از این کد تخفیف را دارد یا نه</remarks>
        public bool CustomerCanUseIt(Guid CustomerId)
        {
            return DiscountPolicy.IsPermitted(CustomerId);
        }

        #endregion


    }
}
