namespace TicketAgency.Core
{
    using System;
    using System.Linq;
    using TicketAgency.Interfaces;
    using TicketAgency.Utilities;

    public class CommandExecutor
    {
        public CommandExecutor(ITicketCatalog catalog)
        {
            this.TicketCatalog = catalog;
        }

        public CommandExecutor()
            : this(new TicketCatalog())
        {
        }

        public ITicketCatalog TicketCatalog { get; private set; }

        public string ProcessCommand(string line)
        {
            int firstSpaceIndex = line.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            string command = line.Substring(0, firstSpaceIndex);
            string information = "Invalid command!";
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters =
                        allParameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(parameter => parameter.Trim())
                            .ToArray();

            switch (command)
            {
                case "AddAir":
                    information = this.TicketCatalog.AddAirTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        parameters[3],
                        DateTimeParser.ParseDateTime(parameters[4]),
                        decimal.Parse(parameters[5]));
                    break;
                case "DeleteAir":
                    information = this.TicketCatalog.DeleteAirTicket(parameters[0]);
                    break;
                case "AddTrain":
                    information = this.TicketCatalog.AddTrainTicket(
                        parameters[0],
                        parameters[1],
                        DateTimeParser.ParseDateTime(parameters[2]),
                        decimal.Parse(parameters[3]),
                        decimal.Parse(parameters[4]));
                    break;
                case "DeleteTrain":
                    information = this.TicketCatalog.DeleteTrainTicket(parameters[0], parameters[1], DateTimeParser.ParseDateTime(parameters[2]));
                    break;
                case "AddBus":
                    information = this.TicketCatalog.AddBusTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        DateTimeParser.ParseDateTime(parameters[3]),
                        decimal.Parse(parameters[4]));
                    break;
                case "DeleteBus":
                    information = this.TicketCatalog.DeleteBusTicket(
                        parameters[0],
                        parameters[1],
                        parameters[2],
                        DateTimeParser.ParseDateTime(parameters[3]));
                    break;
                case "FindTickets":
                    information = this.TicketCatalog.FindTickets(parameters[0], parameters[1]);
                    break;
                case "FindTicketsInInterval":
                    information = this.TicketCatalog.FindTicketsInInterval(
                        DateTimeParser.ParseDateTime(parameters[0]),
                        DateTimeParser.ParseDateTime(parameters[1]));
                    break;
            }

            return information;
        }
    }
}
