using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Kitchen.Domain.BussinesRules.Exceptions
{
    public class NameAlreadyInUseException : Exception
    {
        public NameAlreadyInUseException()
        {
        }

        public NameAlreadyInUseException(string? message) : base(message) 
        {
        }

        public NameAlreadyInUseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
