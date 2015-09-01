namespace TicketOffice.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketRepositoryAirTicketsUnitTests
    {
        [TestMethod]
        public void TestAddAirTicketReturnsFlightCreated()
        {
            ITicketRepository repository = new TicketRepository();
            
            string cmdResult = repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            Assert.AreEqual("Flight created", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Flight));
        }

        [TestMethod]
        public void TestAddAirTicketDuplicates()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            
            string cmdResult = repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "London", airline: "Wizz Air", dateTime: new DateTime(2015, 1, 22, 06, 15, 00), price: 730.55M);

            Assert.AreEqual("Duplicated flight", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Flight));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsFlightDeleted()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string cmdResult = repository.DeleteAirTicket(flightNumber: "FX215");

            Assert.AreEqual("Flight deleted", cmdResult);
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Flight));
        }

        [TestMethod]
        public void TestDeleteAirTicketReturnsFlightDoesNotExist()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);

            string cmdResult = repository.DeleteAirTicket(flightNumber: "FX217");

            Assert.AreEqual("Flight does not exist", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Flight));
        }

        [TestMethod]
        public void TestDeleteDeletedAirTicketReturnsFlightDoesNotExist()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            repository.DeleteAirTicket(flightNumber: "FX215");

            string cmdResult = repository.DeleteAirTicket(flightNumber: "FX215");

            Assert.AreEqual("Flight does not exist", cmdResult);
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Flight));
        }
    }
}
