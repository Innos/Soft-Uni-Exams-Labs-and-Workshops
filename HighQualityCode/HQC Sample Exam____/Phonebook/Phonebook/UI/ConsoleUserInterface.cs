namespace Phonebook.UI
{
    using System;

    using Phonebook.Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
