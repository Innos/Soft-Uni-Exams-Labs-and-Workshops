
namespace _01Logger.Appenders
{
    using System;
    using System.IO;
    using _01Logger.Interfaces;

    public class FileAppender : Appender
    {
        private readonly StreamWriter writer;

        public FileAppender(IFormatter formatter, string path)
            : base(formatter)
        {
            this.Path = path;
            this.writer = new StreamWriter(this.Path);
        }
        public string Path { get; private set; }

        public override void Append(string message, ReportLevel level, DateTime date)
        {
            var output = this.Formatter.Format(message, level, date);

            this.writer.WriteLine(output);
            this.writer.Flush();
        }

        public void Close()
        {
            this.writer.Close();
        }
    }
}
