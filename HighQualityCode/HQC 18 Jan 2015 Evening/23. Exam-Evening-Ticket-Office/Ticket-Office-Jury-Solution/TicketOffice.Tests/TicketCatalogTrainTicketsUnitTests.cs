namespace TicketOffice.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketRepositoryTrainTicketsUnitTests
    {
        [TestMethod]
        public void TestAddTrainTicketReturnsTrainCreated()
        {
            ITicketRepository repository = new TicketRepository();

            string cmdResult = repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);

            Assert.AreEqual("Train created", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestAddTrainTicketDuplicates()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);

            string cmdResult = repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 28.00M, studentPrice: 17.70M);

            Assert.AreEqual("Duplicated train", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTrainDeleted()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);

            string cmdResult = repository.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Train deleted", cmdResult);
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteTrainTicketReturnsTrainDoesNotExist()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 22.00M, studentPrice: 11.00M);

            string cmdResult = repository.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 33));

            Assert.AreEqual("Train does not exist", cmdResult);

            cmdResult = repository.DeleteTrainTicket(from: "Sofia", to: "VARNA", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Train does not exist", cmdResult);

            cmdResult = repository.DeleteTrainTicket(from: "sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Train does not exist", cmdResult);
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestDeleteDeletedTrainTicketReturnsTraindDoesNotExist()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 26.00M, studentPrice: 16.30M);
            repository.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            string cmdResult = repository.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 30, 12, 55, 00));

            Assert.AreEqual("Train does not exist", cmdResult);
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Train));
        }
    }
}
