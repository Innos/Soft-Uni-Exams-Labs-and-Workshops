namespace TicketAgency.Interfaces
{
    using System;

    using System.Collections.Generic;

    using TicketAgency.Enums;
    using TicketAgency.Modles;

    using Wintellect.PowerCollections;

    public interface ITicketCatalogDatabase
    {
        Dictionary<string, ITicket> TicketsByUniqueIdentifier { get; }

        MultiDictionary<string, ITicket> TicketsByDestinations { get; }

        OrderedMultiDictionary<DateTime, ITicket> TicketsByDate { get; }

        Dictionary<TicketType, int> TicketAmounts { get; }

        void AddTicket(ITicket ticket);

        void RemoveTicket(ITicket ticket);

    }
}
