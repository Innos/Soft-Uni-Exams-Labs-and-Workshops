namespace Phonebook.UI
{
    using System;
    using System.IO;

    using Phonebook.Interfaces;

    public class FileUserInterface : IUserInterface
    {
        public void WriteLine(string message)
        {
            File.AppendAllText("test.txt", string.Format(message + Environment.NewLine));

        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
