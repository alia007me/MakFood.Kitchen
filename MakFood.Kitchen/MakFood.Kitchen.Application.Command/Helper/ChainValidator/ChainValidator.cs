namespace MakFood.Kitchen.Application.Command.Helper.ChainValidator
{
    public class ChainValidator<T>
    {
        public ChainValidator(T source)
        {
            SubValidators = new List<SubChainValidator>();
            Source = source;
        }

        public List<SubChainValidator> SubValidators { get; private set; }
        public T Source { get; set; }

        public ChainValidator<T> Then<TException>(Func<T, bool> validation) where TException : Exception, new()
        {
            var validator = new SubChainValidator(() => validation(Source), () => new TException());

            this.SubValidators.Add(validator);

            return this;
        }

        public ValidationResult Validate(ValidationPolicy policy = ValidationPolicy.PassIfErroreOccured)
        {
            var result = new ValidationResult();

            if (policy == ValidationPolicy.PassIfErroreOccured)
                foreach (var validator in SubValidators) {
                    try {
                        if (validator.Validation()) {
                            result.AddException(validator.Exp);
                        }
                    }
                    catch (Exception ex) {

                        result.AddException(() => ex);
                    }
                }

            else if (policy == ValidationPolicy.ThrowIfErrorOccured)
                foreach (var validator in SubValidators) {
                    try {
                        if (validator.Validation()) {
                            throw validator.Exp();
                        }
                    }
                    catch (Exception ex) {
                        throw ex;
                    }
                }

            return result;
        }



        public class ValidationResult
        {
            private List<Func<Exception>> _exceptions;

            public ValidationResult()
            {
                this._exceptions = new List<Func<Exception>>();
            }

            public void AddException(Func<Exception> exception)
            {
                if (exception is not null)
                    _exceptions.Add(exception);
            }

            public void ThrowFirstIfRequired()
            {
                if (_exceptions.Any()) {
                    throw _exceptions.First()();
                }
            }

            public List<string> Messages => _exceptions.Select(e => e().Message).ToList();
        }
    }
}
