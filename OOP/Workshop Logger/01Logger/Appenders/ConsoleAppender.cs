namespace _01Logger.Appenders
{
    #region

    using System;

    using _01Logger.Interfaces;

    #endregion

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(IFormatter formatter)
            : base(formatter)
        {
        }

        public override void Append(string message, ReportLevel level, DateTime date)
        {
            var output = this.Formatter.Format(message, level, date);
            Console.WriteLine(output);
        }
    }
}