namespace BangaloreUniversityLearningSystem.UserInterface
{
    using System;

    using BangaloreUniversityLearningSystem.Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
