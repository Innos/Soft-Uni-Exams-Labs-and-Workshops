namespace TheatreManager.Exceptions
{
    using System;

    public class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException(string msg)
            : base(msg)
        {
        }
    }
}
