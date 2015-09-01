namespace TicketAgency.Interfaces
{
    using System;

    using TicketAgency.Enums;

    public interface ITicketCatalog
    {
        /// <summary>
        /// Creates an AirTicket and tries to add it to the database, then returns a string with the result of the operation.
        /// </summary>
        /// <param name="flightNumber">An unique number which represents the number of the flight.</param>
        /// <param name="from">The starting location of the route.</param>
        /// <param name="to">The destination of the route.</param>
        /// <param name="airline">The name of the Airline who will fly the route.</param>
        /// <param name="dateTime">A DateTime showing the start of the course.</param>
        /// <param name="price">The price of the course.</param>
        /// <returns>Returns a string with the result of the operation, if the ticket already exists in the database, returns a duplicate ticket message, otherwise returns a success message.</returns>
        string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        /// <summary>
        /// Searches for a ticket in the database by an unique identifier and deletes it if it exists, then returns a string message with the result of the operation.
        /// </summary>
        /// <param name="flightNumber">The flight number of the course.</param>
        /// <returns>Returns a string with the result of the operation, if no ticket with given flightNumber exists in the database, returns a ticket does not exist message, otherwise returns a success message.</returns>
        string DeleteAirTicket(string flightNumber);

        /// <summary>
        /// Creates a TrainTicket and tries to add it to the database, then returns a string with the result of the operation.
        /// </summary>
        /// <param name="from">The starting location of the route.</param>
        /// <param name="to">The destination of the route.</param>
        /// <param name="dateTime">A DateTime showing the start of the course.</param>
        /// <param name="price">The price of the course.</param>
        /// <param name="studentPrice">A discounted price for students.</param>
        /// <returns>Returns a string with the result of the operation, if the ticket already exists in the database, returns a duplicate ticket message, otherwise returns a succes message.</returns>
        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        /// <summary>
        /// Searches for a ticket in the database by an unique identifier and deletes it if it exists, then returns a string message with the result of the operation.
        /// </summary>
        /// <param name="from">The starting location of the route.</param>
        /// <param name="to">The destination of the route.</param>
        /// <param name="dateTime">A DateTime showing the start of the course.</param>
        /// <returns>>Returns a string with the result of the operation, if no ticket with an unique identifier created by the input parameters exists in the database, returns a ticket does not exist message, otherwise returns a success message.</returns>
        string DeleteTrainTicket(string from, string to, DateTime dateTime);

        /// <summary>
        /// Creates a BusTicket and tries to add it to the database, then returns a string with the result of the operation.
        /// </summary>
        /// <param name="from">The starting location of the route.</param>
        /// <param name="to">The destination of the route.</param>
        /// <param name="travelCompany">The name of the Travel company traversing the route.</param>
        /// <param name="dateTime">A DateTime showing the start of the course.</param>
        /// <param name="price">The price of the course.</param>
        /// <returns>Returns a string with the result of the operation, if the ticket already exists in the database, returns a duplicate ticket message, otherwise returns a succes message.</returns>
        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

        /// <summary>
        /// Searches for a ticket in the database by an unique identifier and deletes it if it exists, then returns a string message with the result of the operation.
        /// </summary>
        /// <param name="from">The starting location of the route.</param>
        /// <param name="to">The destination of the route.</param>
        /// <param name="travelCompany">The name of the Travel company traversing the route.</param>
        /// <param name="dateTime">A DateTime showing the start of the course.</param>
        /// <returns>Returns a string with the result of the operation, if no ticket with an unique identifier created by the input parameters exists in the database, returns a ticket does not exist message, otherwise returns a success message.</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Searches the database for all tickets matching the specified startind location and destination, and returns a string representation of the result, if there are no results prints a not found message.
        /// </summary>
        /// <param name="from">The starting location.</param>
        /// <param name="to">The destination.</param>
        /// <returns>Returns the string representation of the sorted collection of all tickets meeting the requirments, if no such tickets exist, returns a not found message.</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Searches the database for all tickets whose date and time are between two specified dates and then returns the string representation of the collection of all matching tickets, if no matching tickets are found returns a not found message.
        /// </summary>
        /// <param name="startDateTime">A DateTime specifying the lower bound of the search(inclusive).</param>
        /// <param name="endDateTime">A DateTime specifying the upper bound of the search(inclusive).</param>
        /// <returns>Returns the string representation of the sorted collection of all tickets meeting the requirments, if no such tickets exist, returns a not found message.</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        /// <summary>
        /// Returns the amound of tickets of a certain type from the database.
        /// </summary>
        /// <param name="type">The type of the ticket.</param>
        /// <returns>Returns an integer which represents the amount of tickets of the certain type present in the database.</returns>
        int GetTicketsCount(TicketType type);
    }
}
