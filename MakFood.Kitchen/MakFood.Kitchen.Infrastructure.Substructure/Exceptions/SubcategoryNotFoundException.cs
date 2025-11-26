using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Infrastructure.Substructure.Exceptions
{
    public class SubcategoryNotFoundException : Exception
    {
        public SubcategoryNotFoundException()
        {
        }

        public SubcategoryNotFoundException(Guid id) : base($"Subcategory with Id '{id}' was not found.")
        {
        }

        public SubcategoryNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
