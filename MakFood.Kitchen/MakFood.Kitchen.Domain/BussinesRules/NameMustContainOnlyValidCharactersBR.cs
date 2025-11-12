using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;
using System.Text.RegularExpressions;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class NameMustContainOnlyValidCharactersBR : IBaseBusinessRule
    {
        private readonly string _name;

        public NameMustContainOnlyValidCharactersBR(string name)
        {
            _name = name;
        }

        public bool Check()
        {
            var nameRegexPattern = "([a-zA-Z_\\s]{1,60})";
           if (Regex.IsMatch(_name, nameRegexPattern)) return true;

            return false;
           
        }


        public Exception Throws()
        {
            throw new NameMustContainOnlyValidCharactersException();
        }
    }
}
