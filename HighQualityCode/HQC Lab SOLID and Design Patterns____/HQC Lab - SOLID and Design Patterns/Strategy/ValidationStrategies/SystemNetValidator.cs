namespace Strategy.ValidationStrategies
{
    using System;

    using SharpCompiler.Exceptions;

    public class SystemNetValidator : IValidationStrategy
    {
        public void Validate(string code)
        {
            if (!code.Contains("using System.Net;"))
            {
                throw new CompilationException("Code does not contain 'using System.Net'");
            }
        }
    }
}
