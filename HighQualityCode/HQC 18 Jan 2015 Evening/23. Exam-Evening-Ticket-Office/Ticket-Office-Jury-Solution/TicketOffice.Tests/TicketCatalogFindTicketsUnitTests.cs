namespace TicketOffice.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketRepositoryFindTicketsUnitTests
    {
        [TestMethod]
        public void TestFindTicketsReturnsTickets()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");

            repository.AddBusTicket(from: "Varna", to: "Sofia", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            repository.AddTrainTicket(from: "SOFIA", to: "VARNA", dateTime: new DateTime(2015, 1, 23, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddAirTicket(from: "sofia", to: "varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            repository.AddBusTicket(from: "Varna2", to: "Sofia2", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            string cmdResult = repository.FindTickets(from: "Sofia", to: "Varna");

            Assert.AreEqual("[29.01.2015 07:40|flight|24.00] [30.01.2015 12:55|train|26.00]", cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsReturnsNoMatches()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            repository.AddBusTicket(from: "Varna", to: "Sofia", dateTime: new DateTime(2015, 1, 30, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");
            repository.AddTrainTicket(from: "SOFIA", to: "VARNA", dateTime: new DateTime(2015, 1, 23, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddAirTicket(from: "sofia", to: "varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 24.00M, airline: "Bulgaria Air", flightNumber: "SV7023");
            repository.AddBusTicket(from: "Varna2", to: "Sofia2", dateTime: new DateTime(2015, 1, 25, 11, 35, 00), price: 25.00M, travelCompany: "Biomet");

            string cmdResult = repository.FindTickets(from: "Sofia", to: "Istanbul");

            Assert.AreEqual("No matches", cmdResult);
        }

        [TestMethod]
        public void TestFindTicketsCheckCorrectSortingOrder()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 224.00M, airline: "Bulgaria Air", flightNumber: "SV453");
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 224.00M, airline: "Bulgaria Air", flightNumber: "SV453-2");
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 40, 00), price: 224.00M, airline: "Air BG", flightNumber: "S9473");
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 1224.00M, airline: "Air Travel Corp.", flightNumber: "V245X");

            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 26, 7, 40, 00), price: 24.00M, studentPrice: 16.30M);
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 24, 7, 40, 00), price: 426.55M, studentPrice: 16.30M);

            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet2");
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 28.00M, travelCompany: "Etap");
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 27, 7, 40, 00), price: 25.00M, travelCompany: "New Bus Corp.");
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 5.72M, travelCompany: "Sofia Bus Ltd.");
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 1235.72M, travelCompany: "Varna Bus Travel Ltd.");

            string cmdResult = repository.FindTickets(from: "Sofia", to: "Varna");

            string expectedCmdResult = 
                "[24.01.2015 07:40|train|426.55] " +
                "[26.01.2015 07:40|train|24.00] " +
                "[27.01.2015 07:40|bus|25.00] " +
                "[28.01.2015 07:40|flight|224.00] " +
                "[28.01.2015 07:45|train|26.00] " +
                "[29.01.2015 07:40|bus|5.72] " +
                "[29.01.2015 07:40|bus|25.00] " +
                "[29.01.2015 07:40|bus|25.00] " +
                "[29.01.2015 07:40|bus|28.00] " +
                "[29.01.2015 07:40|bus|1235.72] " +
                "[29.01.2015 07:40|flight|211.00] " +
                "[29.01.2015 07:40|flight|224.00] " +
                "[29.01.2015 07:40|flight|224.00] " +
                "[29.01.2015 07:40|flight|1224.00] " +
                "[29.01.2015 07:40|train|26.00]";
            Assert.AreEqual(expectedCmdResult, cmdResult);
        }
    }
}
