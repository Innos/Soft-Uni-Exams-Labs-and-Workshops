namespace Strategy.ValidationStrategies
{
    using System;

    using SharpCompiler.Exceptions;

    public class CodeLengthValidator : IValidationStrategy
    {
        public void Validate(string code)
        {
            if (code.Length < 20)
            {
                throw new CompilationException("Code length must be atleast 20 characters.");
            }
        }
    }
}
