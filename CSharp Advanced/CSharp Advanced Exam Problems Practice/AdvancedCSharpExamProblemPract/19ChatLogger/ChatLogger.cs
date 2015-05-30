using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Threading;
using System.Globalization;


class ChatLogger
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        SortedDictionary<DateTime, string> messages = new SortedDictionary<DateTime, string>();
        DateTime current = DateTime.Parse(Console.ReadLine());
        string input;
        while((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(new string[] { " / " }, StringSplitOptions.None);
            string message = tokens[0];
            DateTime date = DateTime.Parse(tokens[1]);
            messages.Add(date, message);
        }
        StringBuilder sb = new StringBuilder();
        foreach (var message in messages)
        {
            sb.Append("<div>").Append(SecurityElement.Escape(message.Value)).AppendLine("</div>");
        }
        Console.Write(sb.ToString());

        sb.Clear();
        //TimeSpan difference = current.Subtract(messages.Last().Key);
        //if(current.Day - messages.Last().Key.Day > 1)
        //{
        //    sb.Append(messages.Last().Key.ToString("dd-MM-yyyy"));
        //}
        //else if(current.Day - messages.Last().Key.Day == 1)
        //{
        //    sb.Append("yesterday");
        //}
        //else if(difference.TotalSeconds < 60)
        //{
        //    sb.Append("a few moments ago");
        //}
        //else if(difference.TotalMinutes < 60)
        //{
        //    //timespan.TotalMinutes/Days returns a double
        //    //really pay attention to syntaxis
        //    sb.Append((int)difference.TotalMinutes).Append(" minute(s) ago");
        //}
        //else if(difference.TotalHours < 24 && current.Day - messages.Last().Key.Day == 0)
        //{
        //    sb.Append((int)difference.TotalHours).Append(" hour(s) ago");
        //}
        //Console.WriteLine("<p>Last active: <time>{0}</time></p>",SecurityElement.Escape(sb.ToString()));

        TimeSpan difference = current.Subtract(messages.Last().Key);
        if (current.Day - messages.Last().Key.Day > 1)
        {
            Console.WriteLine("<p>Last active: <time>{0}</time></p>",messages.Last().Key.ToString("dd-MM-yyyy"));
        }
        else if (current.Day - messages.Last().Key.Day == 1)
        {
            Console.WriteLine("<p>Last active: <time>{0}</time></p>", "yesterday");
        }
        else if (difference.TotalSeconds < 60)
        {
            Console.WriteLine("<p>Last active: <time>{0}</time></p>", "a few moments ago");
        }
        else if (difference.TotalMinutes < 60)
        {
            Console.WriteLine("<p>Last active: <time>{0}</time></p>", (int)difference.TotalMinutes + " minute(s) ago");
        }
        else if (difference.TotalHours < 24 && current.Day - messages.Last().Key.Day == 0)
        {
            Console.WriteLine("<p>Last active: <time>{0}</time></p>", (int)difference.TotalHours + " hour(s) ago");
        }
    }
}

