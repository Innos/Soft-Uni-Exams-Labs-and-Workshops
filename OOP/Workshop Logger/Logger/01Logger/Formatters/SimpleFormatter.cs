
namespace _01Logger.Formatters
{
    using System;
    using _01Logger.Interfaces;

    public class SimpleFormatter : IFormatter
    {
        public string Format(string message, ReportLevel level, DateTime date)
        {
            return string.Format("{0} - {1} - {2}", message, level, date);
        }
    }
}
