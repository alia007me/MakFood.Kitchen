using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    internal class CategoryMustNotHaveProductsException : Exception
    {
        public CategoryMustNotHaveProductsException() { }
        public CategoryMustNotHaveProductsException(string? message) : base(message)
        {
        }

        public CategoryMustNotHaveProductsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
