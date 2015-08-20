namespace TheatreManager
{
    using System;
    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
