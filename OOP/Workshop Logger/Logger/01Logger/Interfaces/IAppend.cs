
namespace _01Logger.Interfaces
{
    using System;

    public interface IAppender
    {
        void Append(string message, ReportLevel level, DateTime date);
    }
}
