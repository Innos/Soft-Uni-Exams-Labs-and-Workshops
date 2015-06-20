using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _01Logger;
using _01Logger.Appenders;
using _01Logger.Formatters;


namespace LogTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Logger logger;
        public MainWindow()
        {
            InitializeComponent();

            ListBox listbox = (ListBox)this.FindName("ListBox");

            var simpleFormatter = new SimpleFormatter();
            var fileAppender = new FileAppender(simpleFormatter, "test.txt");
            var listBoxAppender = new ListBoxAppender(simpleFormatter,listbox);


            logger = new Logger(listBoxAppender);
            
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            this.logger.Info(e.Key.ToString());
        }
    }
}
