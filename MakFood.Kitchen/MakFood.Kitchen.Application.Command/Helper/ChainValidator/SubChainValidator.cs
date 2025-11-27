namespace MakFood.Kitchen.Application.Command.Helper.ChainValidator
{
    public class SubChainValidator
    {
        public SubChainValidator(Func<bool> validation, Func<Exception> exp)
        {
            Validation = validation;
            Exp = exp;
        }

        public Func<bool> Validation { get; private set; }
        public Func<Exception> Exp { get; private set; }
    }
}
