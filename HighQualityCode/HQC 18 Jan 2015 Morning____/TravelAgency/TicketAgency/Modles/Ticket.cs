namespace TicketAgency.Modles
{
    using System;

    using TicketAgency.Enums;
    using TicketAgency.Interfaces;
    using TicketAgency.Utilities;

    public abstract class Ticket : ITicket
    {
        protected Ticket(string startingPoint, string destination, DateTime date, decimal price, TicketType ticketType)
        {
            this.FromTo = startingPoint + "; " + destination;
            this.DateAndTime = date;
            this.Price = price;
            this.Type = ticketType;
        }

        public TicketType Type { get; private set; }

        public DateTime DateAndTime { get; private set; }

        public decimal Price { get; private set; }

        public string FromTo { get; private set; }

        public abstract string UniqueIdentification { get; }

        public int CompareTo(ITicket otherTicket)
        {
            int result = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (result == 0)
            {
                result = this.Type.CompareTo(otherTicket.Type);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(otherTicket.Price);
            }

            return result;
        }

        public override string ToString()
        {
            string input = "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") + "; " + this.Type + "; "
                           + string.Format("{0:f2}", this.Price) + "]";
            return input;
        }

    }
}
