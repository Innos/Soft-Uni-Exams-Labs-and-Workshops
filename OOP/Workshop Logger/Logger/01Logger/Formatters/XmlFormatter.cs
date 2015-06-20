namespace _01Logger.Formatters
{
    #region

    using System;
    using System.Text;

    using _01Logger.Interfaces;

    #endregion

    public class XmlFormatter : IFormatter
    {
        private static readonly string Indentation = new string(' ', 4);

        public string Format(string message, ReportLevel level, DateTime date)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("<Log>");
            output.AppendLine(string.Format("{1}<Text>{0}</Text>", message, Indentation));
            output.AppendLine(string.Format("{1}<Level>{0}</Level>", level, Indentation));
            output.AppendLine(string.Format("{1}<Date>{0}</Date>", date, Indentation));
            output.AppendLine("</Log>");

            return output.ToString();
        }
    }
}