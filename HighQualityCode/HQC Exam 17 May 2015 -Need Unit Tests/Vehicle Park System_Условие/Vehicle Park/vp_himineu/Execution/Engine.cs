namespace VehiclePark.Execution
{
    using System;

    using VehiclePark.Interfaces;
    using VehiclePark.UserInterface;

    public class Engine : IEngine
    {
        public Engine(ICommandExecutor commandExecutor, IUserInterface userInterface)
        {
            this.CommandExecutor = commandExecutor;
            this.UserInterface = userInterface;
        }

        public Engine()
            : this(new CommandExecutor(), new ConsoleUserInterface())
        {
        }

        public ICommandExecutor CommandExecutor { get; private set; }

        public IUserInterface UserInterface { get; private set; }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.UserInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();
                if (!string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.CommandExecutor.ExecuteCommand(command);
                        this.UserInterface.WriteLine(commandResult);
                    }
                    catch (Exception
                        ex)
                    {
                        this.UserInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}