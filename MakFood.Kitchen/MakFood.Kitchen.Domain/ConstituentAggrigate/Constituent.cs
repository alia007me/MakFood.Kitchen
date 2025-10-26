using MakFood.Kitchen.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.Constituent
{
    public class Constituent : BaseEntity<Guid>
    {
        public Constituent(string name, decimal price, Guid productId)
        {

            validateName(name);
            validatePrice(price);
            Name = name;
            Price = price;
            this.productId = productId;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid productId { get; set; }

        #region
        private static void validateName(String name)
        {
            var regex = new Regex(@"^[a-zA-Z\s\-_]{1,50}$");
            if (!regex.IsMatch(name)) { throw new Exception("your string is not in valid form only a-z , A-Z, Space and _ or - is valid"); }
        }
        #endregion
        #region
        private static void validatePrice(decimal price) {
            if (price < 0) { throw new Exception("the price shoud be a posetive number"); };
        #endregion
        }
    }
}