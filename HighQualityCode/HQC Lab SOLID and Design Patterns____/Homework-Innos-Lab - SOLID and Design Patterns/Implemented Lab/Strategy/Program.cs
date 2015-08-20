namespace SharpCompiler
{
    using System.IO;

    using Strategy.ValidationStrategies;

    public class Program
    {
        private const string ProgramPath = "../../CSharpProgram.cs";
        private const string EntryClassName = "Strategy.Program";

        public static void Main()
        {
            string code = File.ReadAllText(ProgramPath);

            IValidationStrategy strategy = new CodeLengthValidator();
            var compiler = new CSharpCompiler(strategy);
            compiler.Compile(code);
            compiler.Execute(EntryClassName);
        }
    }
}
