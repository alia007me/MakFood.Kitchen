namespace MakFood.Kitchen.Infrastructure.Substructure
{
    public static class CheckNullOrEmptyValidatorExtension
    {
        public static void CheckNullOrEmpty<T>(this T input, string pName)
        {
            if (input == null)
            {
                throw new ArgumentNullException(pName); 
            }

            if (input is string s && string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("String argument is empty", pName);
            }

            if (input is DateOnly dt && dt == default)
            {
                throw new ArgumentException("Date argument is empty",pName);
            }

            if (input is uint uin && uin == 0)
            {
                throw new ArgumentException("Uint argument is empty", pName);
            }
            
        }
    }
}
