using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;
using System.Text.RegularExpressions;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR : IBaseBusinessRule
    {
        private readonly string _discountTitle;

        public DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR(string discountTitle)
        {
            _discountTitle = discountTitle;
        }

        public bool Check()
        {
            var discountTitleRegex = "([A-Za-z0-9_]{4,24})";
            if(Regex.IsMatch(discountTitleRegex, _discountTitle)) return true;
            return false;
        }

        public Exception Throws()
        {
            throw new Exceptions.DiscountTitleMustHaveBetweenFourAndTwentyFourValidCharactersBR();
        }
    }
}
