using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicketAgencyTests
{
    using TicketAgency.Core;
    using TicketAgency.Enums;

    [TestClass]
    public class TicketCatalogTests
    {
        [TestMethod]
        public void TicketCatalogFindTickets_WithoutValidResults_ShouldReturnANotFoundMessage()
        {
            var ticketCatalog = new TicketCatalog();
            var result = ticketCatalog.FindTickets("Paris", "Varna");
            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void FindTickets_WithASingleValidMatchFromMany_ShouldReturnValidResult()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket(
                "CAA6",
                "Madrid",
                "Sofia",
                "BlindEagle Airlines",
                new DateTime(2000, 06, 06, 10, 40, 40),
                25.50m);
            ticketCatalog.AddAirTicket(
                "CAA5",
                "Paris",
                "Varna",
                "BlindEagle Airlines",
                new DateTime(2000, 06, 06, 10, 40, 40),
                25.50m);
            var result = ticketCatalog.FindTickets("Paris", "Varna");
            var expected = "[06.06.2000 10:40; air; 25.50]";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindTickets_WithMultipleResults_ShouldReturnResultsSorted()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket(
                "CAA6",
                "Madrid",
                "Sofia",
                "BlindEagle Airlines",
                new DateTime(2000, 06, 06, 10, 40, 40),
                25.50m);
            ticketCatalog.AddAirTicket(
                "CAA5",
                "Paris",
                "Varna",
                "BlindEagle Airlines",
                new DateTime(2000, 06, 06, 22, 07, 40),
                25.50m);
            ticketCatalog.AddAirTicket(
                "CAA7",
                "Paris",
                "Varna",
                "Bad Air",
                new DateTime(2006, 01, 10, 16, 15, 40),
                11.77m);
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "FastBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                55.50m);
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "SlowBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);
            ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2010, 08, 10, 10, 40, 40),
                55.50m,
                104.22m);

            var result = ticketCatalog.FindTickets("Paris", "Varna");
            var expected = "[06.06.2000 22:07; air; 25.50] [10.01.2006 16:15; air; 11.77] [10.08.2010 10:40; bus; 33.15] [10.08.2010 10:40; bus; 55.50] [10.08.2010 10:40; train; 55.50]";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindTicketsInInterval_WithoutValidMatches_ShouldReturnNotFoundMessage()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "SlowBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);

            var result = ticketCatalog.FindTicketsInInterval(new DateTime(2009, 10, 10, 10, 10, 10), new DateTime(2010, 05, 05, 12, 12, 12));

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void FindTicketsInInterval_WithASingleValidMatchFromMany_ShouldReturnCorrectResult()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "SlowBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "SlowBus",
                new DateTime(2012, 08, 10, 10, 40, 40),
                33.15m);
            ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2005, 08, 10, 10, 40, 40),
                33.15m,
                10.11m);

            var result = ticketCatalog.FindTicketsInInterval(new DateTime(2006, 10, 10, 10, 10, 10), new DateTime(2010, 12, 12, 12, 12, 12));
            var expected = "[10.08.2010 10:40; bus; 33.15]";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindTicketsInInterval_WithMultipleResults_ShouldReturnResultsSorted()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket(
                "CAA6",
                "Madrid",
                "Sofia",
                "BlindEagle Airlines",
                new DateTime(2000, 06, 06, 10, 40, 40),
                25.50m);
            ticketCatalog.AddAirTicket(
                "CAA5",
                "Paris",
                "Varna",
                "BlindEagle Airlines",
                new DateTime(2000, 06, 06, 22, 07, 40),
                25.50m);
            ticketCatalog.AddAirTicket(
                "CAA7",
                "Dubai",
                "Caracao",
                "Bad Air",
                new DateTime(2006, 01, 10, 16, 15, 40),
                11.77m);
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "FastBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                55.50m);
            ticketCatalog.AddBusTicket(
                "Tokya",
                "New York",
                "SlowBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);
            ticketCatalog.AddTrainTicket(
                "London",
                "Stockholm",
                new DateTime(2010, 08, 10, 10, 40, 40),
                55.50m,
                104.22m);

            var result = ticketCatalog.FindTicketsInInterval(new DateTime(2005, 12, 12, 08, 08, 08), new DateTime(2011, 05, 05, 05, 05, 05, 05));
            var expected = "[10.01.2006 16:15; air; 11.77] [10.08.2010 10:40; bus; 33.15] [10.08.2010 10:40; bus; 55.50] [10.08.2010 10:40; train; 55.50]";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetTicketsCount_ShouldReturnCorrectResult()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "SlowBus",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);
            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "SlowBus",
                new DateTime(2012, 08, 10, 10, 40, 40),
                33.15m);
            ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2005, 08, 10, 10, 40, 40),
                33.15m,
                10.11m);

            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.air));
            Assert.AreEqual(2, ticketCatalog.GetTicketsCount(TicketType.bus));
            Assert.AreEqual(1, ticketCatalog.GetTicketsCount(TicketType.train));
        }

        [TestMethod]
        public void AddAirTicket_WithValidData_ShouldAddAirTicketToDatabase()
        {
            var ticketCatalog = new TicketCatalog();
            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.air));

            ticketCatalog.AddAirTicket(
                "CAA5H",
                "Paris",
                "Varna",
                "BlindEagle",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);


            Assert.AreEqual(1, ticketCatalog.GetTicketsCount(TicketType.air));
        }

        [TestMethod]
        public void AddAirTicket_WithValidData_ShouldTicketAddedMessage()
        {
            var ticketCatalog = new TicketCatalog();

            var result = ticketCatalog.AddAirTicket(
                "CAA5H",
                "Paris",
                "Varna",
                "BlindEagle",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);


            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void AddAirTicket_WithADuplicate_ShouldReturnDuplicateMessage()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddAirTicket(
                       "CAA5H",
                       "Paris",
                       "Varna",
                       "BlindEagle",
                       new DateTime(2010, 08, 10, 10, 40, 40),
                       33.15m);

            var result = ticketCatalog.AddAirTicket(
                "CAA5H",
                "Paris",
                "Varna",
                "BlindEagle",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);


            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void AddBusTicket_WithValidData_ShouldAddAirTicketToDatabase()
        {
            var ticketCatalog = new TicketCatalog();
            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.bus));

            ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "BlindEagle",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);


            Assert.AreEqual(1, ticketCatalog.GetTicketsCount(TicketType.bus));
        }

        [TestMethod]
        public void AddBusTicket_WithValidData_ShouldTicketAddedMessage()
        {
            var ticketCatalog = new TicketCatalog();

            var result = ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "BlindEagle",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);


            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void AddBusTicket_WithADuplicate_ShouldReturnDuplicateMessage()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddBusTicket(
                       "Paris",
                       "Varna",
                       "BlindEagle",
                       new DateTime(2010, 08, 10, 10, 40, 40),
                       33.15m);

            var result = ticketCatalog.AddBusTicket(
                "Paris",
                "Varna",
                "BlindEagle",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m);


            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void AddTrainTicket_WithValidData_ShouldAddAirTicketToDatabase()
        {
            var ticketCatalog = new TicketCatalog();
            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.train));

            ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m,
                22.15m);


            Assert.AreEqual(1, ticketCatalog.GetTicketsCount(TicketType.train));
        }

        [TestMethod]
        public void AddTrainTicket_WithValidData_ShouldTicketAddedMessage()
        {
            var ticketCatalog = new TicketCatalog();

            var result = ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m,
                22.15m);


            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void AddTrainTicket_WithADuplicate_ShouldReturnDuplicateMessage()
        {
            var ticketCatalog = new TicketCatalog();
            ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m,
                22.15m);

            var result = ticketCatalog.AddTrainTicket(
                "Paris",
                "Varna",
                new DateTime(2010, 08, 10, 10, 40, 40),
                33.15m,
                22.15m);


            Assert.AreEqual("Duplicate ticket", result);
        }

        [TestMethod]
        public void DeleteAirTicket_WithValidData_ShouldDeleteTicketFromDatabase()
        {
            var ticketCatalog = new TicketCatalog();

            ticketCatalog.AddAirTicket(
            "CA55G",
            "Paris",
            "Varna",
            "BlindEagle",
            new DateTime(2010, 08, 10, 10, 40, 40),
            33.15m);

            Assert.AreEqual(1, ticketCatalog.GetTicketsCount(TicketType.air));
            ticketCatalog.DeleteAirTicket("CA55G");

            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.air));
        }

        [TestMethod]
        public void DeleteAirTicket_WithValidData_ShouldReturnTicketDeletedMessage()
        {
            var ticketCatalog = new TicketCatalog();

            ticketCatalog.AddAirTicket(
            "CA55G",
            "Paris",
            "Varna",
            "BlindEagle",
            new DateTime(2010, 08, 10, 10, 40, 40),
            33.15m);

            var result = ticketCatalog.DeleteAirTicket("CA55G");

            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void DeleteAirTicket_WithAnUnexistingEntry_ShouldReturnTicketDoesNotExistMessage()
        {
            var ticketCatalog = new TicketCatalog();

            var result = ticketCatalog.DeleteAirTicket("CA55G");

            Assert.AreEqual("Ticket does not exist", result);
        }

        [TestMethod]
        public void DeleteBusTicket_WithValidData_ShouldDeleteTicketFromDatabase()
        {
            var ticketCatalog = new TicketCatalog();

            var date = new DateTime(2010, 08, 10, 10, 40, 40);
            ticketCatalog.AddBusTicket(
            "Paris",
            "Varna",
            "BlindEagle",
            date,
            33.15m);

            ticketCatalog.DeleteBusTicket("Paris", "Varna", "BlindEagle", date);

            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.bus));
        }

        [TestMethod]
        public void DeleteBusTicket_WithValidData_ShouldReturnTicketDeletedMessage()
        {
            var ticketCatalog = new TicketCatalog();

            var date = new DateTime(2010, 08, 10, 10, 40, 40);
            ticketCatalog.AddBusTicket(
            "Paris",
            "Varna",
            "BlindEagle",
            date,
            33.15m);

            var result = ticketCatalog.DeleteBusTicket("Paris", "Varna", "BlindEagle", date);

            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void DeleteBusTicket_WithAnUnexistingEntry_ShouldReturnTicketDoesNotExistMessage()
        {
            var ticketCatalog = new TicketCatalog();
            var date = new DateTime(2010, 08, 10, 10, 40, 40);

            var result = ticketCatalog.DeleteBusTicket("Paris", "Varna", "BlindEagle",date);

            Assert.AreEqual("Ticket does not exist", result);
        }

        [TestMethod]
        public void DeleteTrainTicket_WithValidData_ShouldDeleteTicketFromDatabase()
        {
            var ticketCatalog = new TicketCatalog();

            var date = new DateTime(2010, 08, 10, 10, 40, 40);
            ticketCatalog.AddTrainTicket(
            "Paris",
            "Varna",
            date,
            33.15m,
            20.15m);

            ticketCatalog.DeleteTrainTicket("Paris", "Varna", date);

            Assert.AreEqual(0, ticketCatalog.GetTicketsCount(TicketType.train));
        }

        [TestMethod]
        public void DeleteTrainTicket_WithValidData_ShouldReturnTicketDeletedMessage()
        {
            var ticketCatalog = new TicketCatalog();

            var date = new DateTime(2010, 08, 10, 10, 40, 40);
            ticketCatalog.AddTrainTicket(
            "Paris",
            "Varna",
            date,
            33.15m,
            20.15m);

            var result = ticketCatalog.DeleteTrainTicket("Paris", "Varna", date);

            Assert.AreEqual("Ticket deleted", result);
        }

        [TestMethod]
        public void DeleteTrainTicket_WithAnUnexistingEntry_ShouldReturnTicketDoesNotExistMessage()
        {
            var ticketCatalog = new TicketCatalog();
            var date = new DateTime(2010, 08, 10, 10, 40, 40);

            var result = ticketCatalog.DeleteTrainTicket("Paris", "Varna", date);

            Assert.AreEqual("Ticket does not exist", result);
        }
    }
}
