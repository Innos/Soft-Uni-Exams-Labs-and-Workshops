namespace TicketAgency.Interfaces
{
    using System;

    using TicketAgency.Enums;

    public interface ITicket : IComparable<ITicket>
    {
        TicketType Type { get; }

        DateTime DateAndTime { get; }

        decimal Price { get; }

        string FromTo { get; }

        string UniqueIdentification { get; }
    }
}
