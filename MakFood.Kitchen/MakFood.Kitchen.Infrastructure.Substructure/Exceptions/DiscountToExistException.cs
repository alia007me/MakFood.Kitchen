using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    [Serializable]
    public class DiscountToExistException : Exception
    {
        public DiscountToExistException()
        {
        }

        public DiscountToExistException(string? message) : base(message)
        {
        }

        public DiscountToExistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
