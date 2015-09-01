
namespace Phonebook.Core
{
    using System;

    using Phonebook.Interfaces;
    using Phonebook.UI;

    public class Engine
    {
        public Engine(CommandManager manager, IUserInterface userInterface)
        {
            this.Manager = manager;
            this.UserInterface = userInterface;
        }

        public Engine()
            : this(new CommandManager(), new ConsoleUserInterface())
        {
        }

        public CommandManager Manager { get; set; }

        public IUserInterface UserInterface { get; set; }

        public void Run()
        {
            string data = this.UserInterface.ReadLine();
            while (data != "End")
            {
                try
                {
                    var result = this.Manager.ProcessCommand(data);
                    if (result != string.Empty)
                    {
                        this.UserInterface.WriteLine(result);
                    }
                }
                catch (ArgumentException ex)
                {
                    this.UserInterface.WriteLine(ex.Message);
                }                           
                data = this.UserInterface.ReadLine();
            }
        }
    }
}

