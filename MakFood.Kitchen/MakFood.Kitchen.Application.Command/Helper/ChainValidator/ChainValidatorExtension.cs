namespace MakFood.Kitchen.Application.Command.Helper.ChainValidator
{
    public static class ChainValidatorExtension
    {
        public static ChainValidator<T> ToValidate<T>(this T t)
            => new ChainValidator<T>(t);
    }
}
