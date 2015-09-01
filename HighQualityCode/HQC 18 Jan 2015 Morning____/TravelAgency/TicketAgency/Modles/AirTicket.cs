namespace TicketAgency.Modles
{
    using System;

    using TicketAgency.Enums;

    public class AirTicket : Ticket
    {
        private const TicketType AirTicketType = TicketType.air;

        public AirTicket(string flightNumber, string startingPoint, string destination, string airline, DateTime date, decimal price)
            : base(startingPoint, destination, date, price, AirTicketType)
        {
            this.FlightNumber = flightNumber;
            this.Airline = airline;
        }

        public string FlightNumber { get; private set; }

        public string Airline { get; private set; }

        public override string UniqueIdentification
        {
            get
            {
                return this.Type + ";" + this.FlightNumber;
            }
        }
    }
}
