namespace TicketAgency.Data
{
    using System;

    using System.Collections.Generic;

    using TicketAgency.Enums;
    using TicketAgency.Interfaces;
    using TicketAgency.Modles;

    using Wintellect.PowerCollections;

    public class TicketCatalogDatabase : ITicketCatalogDatabase
    {
        public TicketCatalogDatabase()
        {
            this.TicketsByUniqueIdentifier = new Dictionary<string, ITicket>();
            this.TicketsByDestinations = new MultiDictionary<string, ITicket>(true);
            this.TicketsByDate = new OrderedMultiDictionary<DateTime, ITicket>(true);
            this.TicketAmounts = new Dictionary<TicketType, int>();
            this.TicketAmounts.Add(TicketType.air, 0);
            this.TicketAmounts.Add(TicketType.bus, 0);
            this.TicketAmounts.Add(TicketType.train, 0);
        }

        public Dictionary<string, ITicket> TicketsByUniqueIdentifier { get; private set; }

        public MultiDictionary<string, ITicket> TicketsByDestinations { get; private set; }

        public OrderedMultiDictionary<DateTime, ITicket> TicketsByDate { get; private set; }

        public Dictionary<TicketType, int> TicketAmounts { get; private set; }

        public void AddTicket(ITicket ticket)
        {
            this.TicketsByUniqueIdentifier.Add(ticket.UniqueIdentification, ticket);
            this.TicketsByDestinations.Add(ticket.FromTo, ticket);
            this.TicketsByDate.Add(ticket.DateAndTime, ticket);
            this.TicketAmounts[ticket.Type]++;
        }

        public void RemoveTicket(ITicket ticket)
        {
            this.TicketsByUniqueIdentifier.Remove(ticket.UniqueIdentification);
            this.TicketsByDestinations.Remove(ticket.FromTo, ticket);
            this.TicketsByDate.Remove(ticket.DateAndTime, ticket);
            this.TicketAmounts[ticket.Type]--;
        }


    }
}
