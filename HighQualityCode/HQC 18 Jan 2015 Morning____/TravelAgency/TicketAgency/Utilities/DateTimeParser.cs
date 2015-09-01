namespace TicketAgency.Utilities
{
    using System;

    using System.Globalization;

    public static class DateTimeParser
    {
        public static DateTime ParseDateTime(string dt)
        {
            DateTime result = DateTime.ParseExact(dt, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }
    }
}
