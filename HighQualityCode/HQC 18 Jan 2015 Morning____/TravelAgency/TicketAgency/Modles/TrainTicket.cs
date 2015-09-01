namespace TicketAgency.Modles
{
    using System;

    using TicketAgency.Enums;

    public class TrainTicket : Ticket
    {
        private const TicketType TrainTicketType = TicketType.train;

        public TrainTicket(string startingPoint, string destination, DateTime date, decimal price, decimal studentPrice)
            : base(startingPoint, destination, date, price, TrainTicketType)
        {
            this.StudentPrice = studentPrice;
        }

        public decimal StudentPrice { get; private set; }

        public override string UniqueIdentification
        {
            get
            {
                return this.Type + ";" + this.FromTo + ";" + this.DateAndTime + ";";
            }
        }
    }
}
