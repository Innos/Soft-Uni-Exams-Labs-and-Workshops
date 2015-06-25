using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using _01Logger;
using _01Logger.Appenders;
using _01Logger.Interfaces;

namespace LogTest
{
    class ListBoxAppender : Appender
    {
        public ListBoxAppender(IFormatter formatter, ListBox listbox) : base(formatter)
        {
            this.Listbox = listbox;
        }

        public ListBox Listbox { get; set; } 

        public override void Append(string message, ReportLevel level, DateTime date)
        {
            var output = this.Formatter.Format(message, level, date);
            this.Listbox.Items.Add(output);
        }
    }
}
