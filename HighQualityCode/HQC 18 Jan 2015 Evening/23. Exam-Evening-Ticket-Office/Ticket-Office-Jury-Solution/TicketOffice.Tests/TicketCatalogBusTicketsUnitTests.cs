namespace TicketOffice.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketRepositoryBusTicketsUnitTests
    {
        [TestMethod]
        public void TestAddBusTicketReturnsBusCreated()
        {
            ITicketRepository repository = new TicketRepository();
            
            string cmdResult = repository.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            Assert.AreEqual("Bus created", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestAddBusTicketDuplicates()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            string cmdResult = repository.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 28.00M);

            Assert.AreEqual("Duplicated bus", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsBusDeleted()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            string cmdResult = repository.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Bus deleted", cmdResult);
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteBusTicketReturnsBusDoesNotExist()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);

            string cmdResult = repository.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 07));

            Assert.AreEqual("Bus does not exist", cmdResult);

            cmdResult = repository.DeleteBusTicket(from: "Sofia", to: "VARNA", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Bus does not exist", cmdResult);
            cmdResult = repository.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "Bus Express", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Bus does not exist", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestDeleteDeletedBusTicketReturnsBusdDoesNotExist()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M);
            repository.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            string cmdResult = repository.DeleteBusTicket(from: "Sofia", to: "Varna", travelCompany: "BusExpress", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Bus does not exist", cmdResult);
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Bus));
        }
    }
}
