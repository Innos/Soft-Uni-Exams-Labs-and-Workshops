namespace TheatreManager.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The interface that is implemented by the PerformanceDatabase class
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// The method adds a theatre to the database
        /// </summary>
        /// <param name="theatreName">The name of the theatre that will be added.</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// The method creates a collection of all theatres in the database and returns them.
        /// </summary>
        /// <returns>Returns an IEnumerable<string> with the names of all theatres in the database.</string></returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// The method creates an instance of the Performance class and adds it to a theatre in the database.
        /// </summary>
        /// <param name="theatreName">The name of the theatre to which the performance will be added.</param>
        /// <param name="performanceTitle">The name of the performance.</param>
        /// <param name="startDateTime">The starting date of the performance.</param>
        /// <param name="duration">The duration of the performance.</param>
        /// <param name="price">The price of the tickets of the performance.</param>
        /// <see cref="TheatreManager.Performance"/>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// The method creates a collection of all performances and returns it.
        /// </summary>
        /// <returns>Returns an IEnumerable<Performance> with all performances in the database.</Performance></returns>
        /// <see cref="TheatreManager.Performance"/>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// The method returns a collection with all performances in a theater specified by name.
        /// </summary>
        /// <param name="theatreName">The name of the theatre.</param>
        /// <returns>Returns an IEnumerable<Performance> with all performances in the specified theater.</Performance></returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
