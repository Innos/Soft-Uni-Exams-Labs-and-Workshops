
namespace _01Logger.Appenders
{
    using System;
    using _01Logger.Interfaces;

    public abstract class Appender : IAppender
    {
        protected Appender(IFormatter formatter)
        {
            this.Formatter = formatter;
        }

        public IFormatter Formatter { get; set; }

        public abstract void Append(string message, ReportLevel level, DateTime date);
    }
}
