using MakFood.Kitchen.Domain.Base;
using MakFood.Kitchen.Infrastructure.Substructure.Extensions;
using System;

namespace MakFood.Kitchen.Domain.NewFolder
{
    public class DiscountCode : BaseEntity<Guid>
    {
        /// <summary>
        /// کانستراکتور کلاس دیسکانت کود
        /// </summary>
        /// <param name="discoutCoteName">اسم کد تخفیف</param>
        /// <param name="eligibleCustomers">کاستومر های واجد شرایط</param>
        /// <param name="expiryDate">تاریخ انقضا کد تخفیف</param>
        /// <param name="maximumBalance">ماکسیموم حق کد تخفیف</param>
        /// <param name="minimumBalance">مینیموم حق کد تخفیف</param>
        public DiscountCode(string discoutCoteName, List<Guid> eligibleCustomers, DateOnly expiryDate, decimal maximumBalance, decimal minimumBalance)
        {
            DiscountCodeNameValidation(discoutCoteName);
            DiscountCodeEligibleCustomersValidation(eligibleCustomers);
            DiscountCodeDateTimeValidation(expiryDate);
            MaximumMinimumValibation(maximumBalance, minimumBalance);
            CheckDesimalMaximumMinimum(minimumBalance);
            CheckDesimalMaximumMinimum(maximumBalance);
            Id = Guid.NewGuid();
            DiscoutCodeName = discoutCoteName;
            EligibleCustomers = eligibleCustomers;
            ExpiryDate = expiryDate;
            MaximumBalance = maximumBalance;
            MinimumBalance = minimumBalance;
        }

        public string DiscoutCodeName { get; private set; }
        public List<Guid> EligibleCustomers { get; private set; }
        public DateOnly ExpiryDate { get; private set; }
        public decimal MaximumBalance { get; private set; }
        public decimal MinimumBalance { get; private set; }

        #region Validation
        private void MaximumMinimumValibation(decimal maximum, decimal minimum)
        {
            checkForCorrectMaximumAndMinimum(maximum, minimum);
            DiscountCodeDesimalMaximumValidation(maximum);
            DiscountCodeDesimalMinimumValidation(minimum);
        }
        /// <summary>
        /// چک کردن نال نبودن اسم کد تخفیف
        /// </summary>
        /// <param name="discoutCodeName"></param> 
        private void DiscountCodeNameValidation(string discoutCodeName)
        {
            discoutCodeName.CheckNullOrEmpty("discoutCodeName");
        }
        /// <summary>
        /// چک کردن نال نبودن لیستی از کاستومر ایدی واجدین شرایط کد تخفیف
        /// </summary>
        /// <param name="discoutCodeName"></param>
        private void DiscountCodeEligibleCustomersValidation(List<Guid> eligibleCustomers)
        {
            eligibleCustomers.CheckNullOrEmpty("eligibleCustomers");
        }
        /// <summary>
        /// چک کردن نال نبودن تاریخ انقضا 
        /// </summary>
        /// <param name="DateOnly"></param>
        private void DiscountCodeDateTimeValidation(DateOnly ExpiryDate)
        {
            ExpiryDate.CheckNullOrEmpty("ExpiryDate");
        }
        /// <summary>
        /// چک کردن نال نبودن دسیمال ماکسیموم
        /// </summary>
        /// <param name="maximumBalance"></param>
        private void DiscountCodeDesimalMaximumValidation(decimal maximumBalance)
        {
           maximumBalance.CheckNullOrEmpty("maximumBalance");
        }
        /// <summary>
        /// چک کردن نال نبودن دسیمال مینیموم
        /// </summary>
        /// <param name="minimumBalance"></param>
        private void DiscountCodeDesimalMinimumValidation(decimal minimumBalance)
        {
            minimumBalance.CheckNullOrEmpty("minimumBalance");

        }
        /// <summary>
        /// چک کردن بیشتر نبودن مینیموم از ماکسیموم
        /// 
        /// </summary>
        /// <returns></returns>
        private void checkForCorrectMaximumAndMinimum(decimal maximum, decimal minimum)
        {
            if (maximum <= minimum)
                throw new ArgumentException("The maximum must not be less than equal minimum");

        }
        private void CheckDesimalMaximumMinimum(decimal @decimal)
        {
            if (@decimal <= 0)
                throw new ArgumentException("decimal not Zero And Negative");
        }
        #endregion  

        #region behavior
        /// <summary>
        /// اضافه کردن یوزر به لیست واجدین شرایط کد تخفیف
        /// </summary>
        /// <param name="CustomerId"></param>
        public void AddUserToEligibleList(Guid CustomerId)
        {
            EligibleCustomers.Add(CustomerId);
        }
        /// <summary>
        /// حذف کردن یوزر از لیست واجدین شرایط کد تخفیف
        /// </summary>
        /// <param name="CustomerId"></param>
        public void RemoveUserToEligibleList(Guid CustomerId)
        {
            EligibleCustomers.Remove(CustomerId);
        }
        /// <summary>
        /// اضافه کردن همه به لیست واجدین شرایط کد تخفیف
        /// </summary>
        /// <param name="users"></param>
        public void AddAllUserToEligibleList(IEnumerable<Guid> users)
        {
            foreach (var user in users)

                EligibleCustomers.Add(user);
        }
       
        #endregion
    }
}
