namespace TheatreManager
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Exceptions;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        private static CultureInfo culture = new CultureInfo("bg-BG");

        private readonly IPerformanceDatabase database;

        private readonly IAppender appender;

        public CommandManager(IPerformanceDatabase database, IAppender appender)
        {
            this.database = database;
            this.appender = appender;
        }

        public bool IsRunning { get; set; }

        public IPerformanceDatabase Database
        {
            get
            {
                return this.database;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value","Database cannot be null.");
                }
            }
        }

        public IAppender Appender {
            get
            {
                return this.appender;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value","Appender cannot be null.");
                }
            } 
        }

        public void Run()
        {
            this.IsRunning = true;

            while (this.IsRunning)
            {
                string command = Console.ReadLine();
                if (command == null)
                {
                    this.IsRunning = false;
                }
                else if(command.Trim() != string.Empty)
                {
                    var result = this.ProcessCommand(command);
                    this.appender.Write(result);
                }      
            }
        }

        private string ProcessCommand(string command)
        {
            string[] commandArgs = command.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];
            commandArgs = commandArgs.Select(p => p.Trim()).ToArray();
            string result;
            switch (commandName)
            {
                case "AddTheatre":
                    {
                        result = this.ExecuteAddTheatreCommand(commandArgs);
                        break;
                    }

                case "PrintAllTheatres":
                    {
                        result = this.ExecutePrintAllTheatresCommand();
                        break;
                    }
                case "AddPerformance":
                    {
                        result = this.ExecuteAddPerformanceCommand(commandArgs);
                        break;
                    }
                case "PrintAllPerformances":
                    {
                        result = this.ExecutePrintAllPerformancesCommand();
                        break;
                    }
                case "PrintPerformances":
                    {
                        result = this.ExecutePrintPerformancesCommand(commandArgs);
                        break;
                    }
                default:
                    {
                        result = "Invalid Command";
                        break;
                    }
            }
            return result;
        }

        private string ExecuteAddTheatreCommand(string[] commandArgs)
        {
            string theatreName = commandArgs[1];
            try
            {
                this.database.AddTheatre(theatreName);
                return "Theatre added";
            }
            catch (DuplicateTheatreException ex)
            {
                return ex.Message;
            }
        }

        private string ExecutePrintAllTheatresCommand()
        {
            var theatres = this.database.ListTheatres();
            if (theatres.Any())
            {
                return string.Join(", ", theatres);
            }
            return "No theatres";
        }

        private string ExecuteAddPerformanceCommand(string[] commandArgs)
        {
            string theatreName = commandArgs[1];
            string performanceName = commandArgs[2];
            DateTime date = DateTime.ParseExact(commandArgs[3], "dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commandArgs[4]);
            decimal price = decimal.Parse(commandArgs[5]);
            try
            {
                this.database.AddPerformance(theatreName, performanceName, date, duration, price);
                return "Performance added";
            }
            catch (TheatreNotFoundException ex)
            {
                return ex.Message;
            }
            catch (TimeDurationOverlapException ex)
            {
                return ex.Message;
            }
        }

        private string ExecutePrintAllPerformancesCommand()
        {
            var allPerformances = this.database.ListAllPerformances();
            allPerformances =
                allPerformances.OrderBy(performance => performance.Theater).ThenBy(performance => performance.Date);
            if (allPerformances.Count() > 0)
            {
                StringBuilder result = new StringBuilder();
                foreach (var performance in allPerformances)
                {
                    result.AppendFormat(
                        "({0}, {1}, {2}), ",
                        performance.Name,
                        performance.Theater,
                        performance.Date.ToString("dd.MM.yyyy HH:mm")
                        );
                }
                result.Remove(result.Length - 2, 2);
                return result.ToString();
            }
            return "No performances";
        }

        private string ExecutePrintPerformancesCommand(string[] commandArgs)
        {
            var theatre = commandArgs[1];
            try
            {
                var allPerformances = this.database.ListPerformances(theatre);
                allPerformances = allPerformances.OrderBy(performance => performance.Date);
                if (allPerformances.Count() == 0)
                {
                    return "No performances";
                }
                return string.Join(", ", allPerformances);
            }
            catch (TheatreNotFoundException ex)
            {
                return ex.Message;
            }
        }
    }
}
