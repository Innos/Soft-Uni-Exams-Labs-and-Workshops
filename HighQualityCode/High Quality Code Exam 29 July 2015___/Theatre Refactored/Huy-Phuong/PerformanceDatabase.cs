namespace TheatreManager
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Exceptions;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, HashSet<Performance>> theaters;

        public PerformanceDatabase()
        {
            this.theaters = new SortedDictionary<string, HashSet<Performance>>();
        }
        public void AddTheatre(string theater)
        {
            if (this.theaters.ContainsKey(theater))
            {
                throw new DuplicateTheatreException("Error: Duplicate theatre");
            }
            this.theaters.Add(theater, new HashSet<Performance>());

        }

        public IEnumerable<string> ListTheatres()
        {
            return this.theaters.Keys;
        }

        public void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.theaters.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Error: Theatre does not exist");
            }
            var overlaps = IsOverlapping(this.theaters[theatreName], startDateTime, startDateTime + duration);
                
                if (overlaps)
                {
                    throw new TimeDurationOverlapException("Error: Time/duration overlap");
                }
            
            var performanceToAdd = new Performance(performanceTitle, theatreName, startDateTime, duration, price);

            this.theaters[theatreName].Add(performanceToAdd);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var allTheatres = this.theaters.Keys;

            var allPerformances = new List<Performance>(); 
            foreach (var theatre in allTheatres)
            {
                var performances = this.theaters[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theaters.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Error: Theatre does not exist");
            } 
            var performances = this.theaters[theatreName];
            return performances;
        }

        private static bool IsOverlapping(IEnumerable<Performance> performances, DateTime performanceToAddStartDate, DateTime performanceToAddEndDate)
        {
            foreach (var performance in performances)
            {
                var performanceStartDate = performance.Date;
                var performanceEndDate = performance.Date + performance.Duration;

                var overlaps = (performanceStartDate <= performanceToAddStartDate && performanceToAddStartDate <= performanceEndDate) ||
                    (performanceStartDate <= performanceToAddEndDate && performanceToAddEndDate <= performanceEndDate) ||
                    (performanceToAddStartDate <= performanceStartDate && performanceStartDate <= performanceToAddEndDate) ||
                    (performanceToAddStartDate <= performanceEndDate && performanceEndDate <= performanceToAddEndDate);

                if (overlaps)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
