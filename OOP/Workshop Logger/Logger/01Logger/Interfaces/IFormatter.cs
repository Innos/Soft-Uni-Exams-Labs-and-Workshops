
namespace _01Logger.Interfaces
{
    using System;

    public interface IFormatter
    {
        string Format(string message, ReportLevel level, DateTime date);
    }
}
