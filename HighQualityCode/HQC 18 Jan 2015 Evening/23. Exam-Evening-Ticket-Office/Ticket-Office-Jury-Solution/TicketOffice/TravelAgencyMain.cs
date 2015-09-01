namespace TicketOffice
{
    using System;
    using System.Globalization;
    using System.Threading;

    public static class TravelAgencyMain
    {
        private static ITicketRepository ticketRepository = new TicketRepository();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                string line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                if (line != string.Empty)
                {
                    string commandResult = ProcessCommand(line);
                    Console.WriteLine(commandResult);
                }
            }
        }

        private static string ProcessCommand(string line)
        {
            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return Constants.InvalidCommand;
            }

            string command = line.Substring(0, firstSpaceIndex);
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(
                new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            string commandResult;
            switch (command)
            {
                case "CreateBus":
                    commandResult = ProcessCreateBusCommand(parameters);
                    break;
                case "DeleteBus":
                    commandResult = ProcessDeleteBusCommand(parameters);
                    break;
                case "CreateTrain":
                    commandResult = ProcessCreateTrainCommand(parameters);
                    break;
                case "DeleteTrain":
                    commandResult = ProcessDeleteTrainCommand(parameters);
                    break;
                case "CreateFlight":
                    commandResult = ProcessCreateFlightCommand(parameters);
                    break;
                case "DeleteFlight":
                    commandResult = ProcessDeleteFlightCommand(parameters);
                    break;
                case "FindTickets":
                    commandResult = ProcessFindTicketsCommand(parameters);
                    break;
                case "FindByDates":
                    commandResult = ProcessFindTicketsInIntervalCommand(parameters);
                    break;
                default:
                    commandResult = Constants.InvalidCommand;
                    break;
            }

            return commandResult;
        }

        private static string ProcessCreateBusCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string travelCompany = parameters[2];
            DateTime dateTime = ParseDateTime(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);
            string commandResult = ticketRepository.AddBusTicket(from, to, travelCompany, dateTime, price);
            return commandResult;
        }

        private static DateTime ParseDateTime(string dateTimeStr)
        {
            var result = DateTime.ParseExact(
                dateTimeStr, Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            return result;
        }

        private static string ProcessDeleteBusCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string travelCompany = parameters[2];
            DateTime dateTime = ParseDateTime(parameters[3]);
            string commandResult = ticketRepository.DeleteBusTicket(from, to, travelCompany, dateTime);
            return commandResult;
        }

        private static string ProcessCreateTrainCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateTime = ParseDateTime(parameters[2]);
            decimal price = decimal.Parse(parameters[3]);
            decimal studentPrice = decimal.Parse(parameters[4]);
            string commandResult = ticketRepository.AddTrainTicket(from, to, dateTime, price, studentPrice);
            return commandResult;
        }

        private static string ProcessDeleteTrainCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            DateTime dateTime = ParseDateTime(parameters[2]);
            string commandResult = ticketRepository.DeleteTrainTicket(from, to, dateTime);
            return commandResult;
        }

        private static string ProcessCreateFlightCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string from = parameters[1];
            string to = parameters[2];
            string airline = parameters[3];
            DateTime dateTime = ParseDateTime(parameters[4]);
            decimal price = decimal.Parse(parameters[5]);
            string commandResult = ticketRepository.AddAirTicket(flightNumber, from, to, airline, dateTime, price);
            return commandResult;
        }

        private static string ProcessDeleteFlightCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string commandResult = ticketRepository.DeleteAirTicket(flightNumber);
            return commandResult;
        }

        private static string ProcessFindTicketsCommand(string[] parameters)
        {
            string from = parameters[0];
            string to = parameters[1];
            string commandResult = ticketRepository.FindTickets(from, to);
            return commandResult;
        }

        private static string ProcessFindTicketsInIntervalCommand(string[] parameters)
        {
            DateTime startDateTime = ParseDateTime(parameters[0]);
            DateTime endDateTime = ParseDateTime(parameters[1]);
            string commandResult = ticketRepository.FindTicketsInInterval(startDateTime, endDateTime);
            return commandResult;
        }
    }
}
