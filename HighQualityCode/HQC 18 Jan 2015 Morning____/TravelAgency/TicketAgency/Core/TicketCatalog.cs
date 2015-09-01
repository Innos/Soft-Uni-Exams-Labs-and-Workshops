namespace TicketAgency.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TicketAgency.Data;
    using TicketAgency.Enums;
    using TicketAgency.Interfaces;
    using TicketAgency.Modles;

    public class TicketCatalog : ITicketCatalog
    {
        public TicketCatalog(ITicketCatalogDatabase database)
        {
            this.Database = database;
        }

        public TicketCatalog()
            : this(new TicketCatalogDatabase())
        {
        }

        private ITicketCatalogDatabase Database { get; set; }

        public string FindTickets(string from, string to)
        {
            string fromTo = from + "; " + to;

            if (this.Database.TicketsByDestinations.ContainsKey(fromTo))
            {
                // Bottleneck: There is no need to iterate through all the values of the collection when we can easily find our results by just looking at the values corresponding to the key we have.
                List<ITicket> ticketsFound =
                    this.Database.TicketsByDestinations[fromTo].OrderBy(t => t.DateAndTime)
                        .ThenBy(t => t.Type)
                        .ThenBy(t => t.Price)
                        .ToList();

                return string.Join(" ", ticketsFound);
            }

            return "Not found";
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.Database.TicketsByDate.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string tickets = string.Join(" ", ticketsFound);

                return tickets;
            }

            return "Not found";
        }

        public int GetTicketsCount(TicketType type)
        {
            return this.Database.TicketAmounts[type];
        }

        public string AddAirTicket(string flightNumber, string startingPoint, string destination, string airline, DateTime date, decimal price)
        {
            AirTicket ticket = new AirTicket(flightNumber, startingPoint, destination, airline, date, price);
            return this.AddTicket(ticket);
        }

        public string DeleteAirTicket(string flightNumber)
        {
            string identifier = TicketType.air + ";" + flightNumber;
            return this.RemoveTicket(identifier);
        }

        public string AddTrainTicket(string from, string to, DateTime date, decimal price, decimal studentPrice)
        {
            TrainTicket ticket = new TrainTicket(from, to, date, price, studentPrice);
            return this.AddTicket(ticket);
        }

        public string DeleteTrainTicket(string from, string to, DateTime date)
        {
            string identifier = TicketType.train + ";" + from + "; " + to + ";" + date + ";";
            return this.RemoveTicket(identifier);
        }

        public string AddBusTicket(string from, string to, string company, DateTime date, decimal price)
        {
            BusTicket ticket = new BusTicket(from, to, company, date, price);
            return this.AddTicket(ticket);
        }

        public string DeleteBusTicket(string from, string to, string company, DateTime date)
        {
            string identifier = TicketType.bus + ";" + from + "; " + to + ";" + company + date + ";";
            return this.RemoveTicket(identifier);
        }

        private string AddTicket(ITicket ticket)
        {
            string identifier = ticket.UniqueIdentification;
            if (this.Database.TicketsByUniqueIdentifier.ContainsKey(identifier))
            {
                return "Duplicate ticket";
            }

            this.Database.AddTicket(ticket);
            return "Ticket added";
        }

        private string RemoveTicket(string identifier)
        {
            if (!this.Database.TicketsByUniqueIdentifier.ContainsKey(identifier))
            {
                return "Ticket does not exist";
            }

            ITicket ticket = this.Database.TicketsByUniqueIdentifier[identifier];
            this.Database.RemoveTicket(ticket);
            return "Ticket deleted";
        }

    }
}
