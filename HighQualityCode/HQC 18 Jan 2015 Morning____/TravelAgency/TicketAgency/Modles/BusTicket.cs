namespace TicketAgency.Modles
{
    using System;

    using TicketAgency.Enums;

    public class BusTicket : Ticket
    {
        private const TicketType BusTicketType = TicketType.bus;

        public BusTicket(string startingPoint, string destination, string company, DateTime date, decimal price)
            : base(startingPoint, destination, date, price, BusTicketType)
        {
            this.Company = company;
        }

        public string Company { get; private set; }

        public override string UniqueIdentification
        {
            get
            {
                return this.Type + ";" + this.FromTo + ";" +
                this.Company + this.DateAndTime + ";";
            }
        }
    }
}
