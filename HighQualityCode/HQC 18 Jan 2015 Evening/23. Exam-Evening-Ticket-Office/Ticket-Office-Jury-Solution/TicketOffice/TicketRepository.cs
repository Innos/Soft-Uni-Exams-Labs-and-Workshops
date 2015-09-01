namespace TicketOffice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class TicketRepository : ITicketRepository
    {
        private Dictionary<string, Ticket> ticketsByUniqueKey = 
            new Dictionary<string, Ticket>();

        private MultiDictionary<string, Ticket> ticketsFromTo = 
            new MultiDictionary<string, Ticket>(true);

        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDate = 
            new OrderedMultiDictionary<DateTime, Ticket>(true);

        private Dictionary<TicketType, int> ticketCountByType =
            new Dictionary<TicketType, int>();

        public TicketRepository()
        {
            this.ticketCountByType[TicketType.Flight] = 0;
            this.ticketCountByType[TicketType.Bus] = 0;
            this.ticketCountByType[TicketType.Train] = 0;
        }

        public string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price)
        {
            var ticket = new BusTicket(from, to, travelCompany, dateTime, price);
            string result = this.AddTicket(ticket);
            return result;
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            var ticket = new BusTicket(from, to, travelCompany, dateTime);
            var uniqueKey = ticket.UniqueKey;
            string result = this.DeleteTicket(TicketType.Bus, uniqueKey);
            return result;
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            var ticket = new TrainTicket(from, to, dateTime, price, studentPrice);
            string result = this.AddTicket(ticket);
            return result;
        }

        public string DeleteTrainTicket(string from, string to, DateTime dateTime)
        {
            var ticket = new TrainTicket(from, to, dateTime);
            var uniqueKey = ticket.UniqueKey;
            string result = this.DeleteTicket(TicketType.Train, uniqueKey);
            return result;
        }

        public string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            var ticket = new AirTicket(flightNumber, from, to, airline, dateTime, price);
            string result = this.AddTicket(ticket);
            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            var ticket = new AirTicket(flightNumber);
            var uniqueKey = ticket.UniqueKey;
            string result = this.DeleteTicket(TicketType.Flight, uniqueKey);
            return result;
        }

        public string FindTickets(string from, string to)
        {
            string fromToKey = CreateFromToKey(from, to);
            if (this.ticketsFromTo.ContainsKey(fromToKey))
            {
                var ticketsFound = this.ticketsFromTo[fromToKey];
                string ticketsAsString = FormatTicketsForPrinting(ticketsFound);
                return ticketsAsString;
            }

            return Constants.NotFoundMsg;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByDate.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                string ticketsAsString = FormatTicketsForPrinting(ticketsFound);
                return ticketsAsString;
            }

            return Constants.NotFoundMsg;
        }

        public int GetTicketsCount(TicketType type)
        {
            return this.ticketCountByType[type];
        }

        private static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        private static string FormatTicketsForPrinting(IEnumerable<Ticket> tickets)
        {
            string ticketsStr = string.Join(" ", tickets.OrderBy(t => t));
            return ticketsStr;
        }

        private string AddTicket(Ticket ticket)
        {
            string key = ticket.UniqueKey;
            if (this.ticketsByUniqueKey.ContainsKey(key))
            {
                return Constants.DuplicateTicketMsg + ticket.Type.ToString().ToLower();
            }

            this.ticketsByUniqueKey.Add(key, ticket);
            string fromToKey = CreateFromToKey(ticket.From, ticket.To);
            this.ticketsFromTo.Add(fromToKey, ticket);
            this.ticketsByDate.Add(ticket.DateTime, ticket);
            this.ticketCountByType[ticket.Type]++;

            return ticket.Type + Constants.TicketCreatedMsg;
        }

        private string DeleteTicket(TicketType ticketType, string uniqueKey)
        {
            if (this.ticketsByUniqueKey.ContainsKey(uniqueKey))
            {
                var ticketToDelete = this.ticketsByUniqueKey[uniqueKey];
                this.ticketsByUniqueKey.Remove(uniqueKey);
                string fromToKey = CreateFromToKey(ticketToDelete.From, ticketToDelete.To);
                this.ticketsFromTo.Remove(fromToKey, ticketToDelete);
                this.ticketsByDate.Remove(ticketToDelete.DateTime, ticketToDelete);
                this.ticketCountByType[ticketToDelete.Type]--;
                return ticketToDelete.Type + Constants.TicketDeletedMsg;
            }

            return ticketType + Constants.TicketDoesNotExistMsg;
        }
    }
}
