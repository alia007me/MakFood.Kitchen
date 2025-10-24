using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.NewFolder
{
    public class DiscoutCode : BaseEntity<Guid>
    {

        public DiscoutCode(string discoutCoteName, List<CustomerId> eligibleCustomers, DateOnly expiryDate, decimal maximumBalance, decimal minimumBalance)
        {
            DiscoutCodeName = discoutCoteName;
            EligibleCustomers = eligibleCustomers;
            ExpiryDate = expiryDate;
            MaximumBalance = maximumBalance;
            MinimumBalance = minimumBalance;
        }

        public string DiscoutCodeName { get; set; }
        public List<CustomerId> EligibleCustomers { get; set; }
        public DateOnly ExpiryDate { get; set; }
        public Decimal MaximumBalance { get; set; }
        public Decimal MinimumBalance { get; set; }

        #region GenerateDiscountCodeName
        public void GenerateDiscountCodeName()
        {
            DiscoutCodeName = $"{Guid.NewGuid().ToString().Substring(0, 12).ToUpper()}";
        }
        #endregion

        #region DiscountCodeValidation

        public bool DiscountCodeValidation(decimal amoun)
        {
            if (DateOnly.FromDateTime(DateTime.Now) > ExpiryDate)
                return false;
            if (amoun > MaximumBalance)
                return false;
            if (amoun < MinimumBalance)
                return false;
            return true;
        }
        #endregion

        #region AddUserToEligibleList
        public void AddUserToEligibleList(Guid CustomerId)
        {
            EligibleCustomers.Add(CustomerId);
        }
        #endregion

        #region RemoveUserToEligibleList 
        public void RemoveUserToEligibleList(Guid CustomerId)
        {
            EligibleCustomers.Remove(CustomerId);
        }
        #endregion

        #region AddAllUserToEligibleList 
        public void AddAllUserToEligibleList(IEnumerable<Guid> users)
        {
            foreach (var user in users)

            EligibleCustomers.Add(user);
        }
        #endregion
    }
}
