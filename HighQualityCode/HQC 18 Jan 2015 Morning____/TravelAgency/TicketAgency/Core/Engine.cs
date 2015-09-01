namespace TicketAgency.Core
{
    using TicketAgency.Interfaces;
    using TicketAgency.UserInterface;

    public class Engine
    {
        public Engine(CommandExecutor executor, IUserInterface userInterface)
        {
            this.CommandExecutor = executor;
            this.UserInterface = userInterface;
        }

        public Engine()
            : this(new CommandExecutor(),new ConsoleUserInterface())
        {
        }

        private CommandExecutor CommandExecutor { get; set; }

        private IUserInterface UserInterface { get; set; }

        public void Run()
        {
            while (true)
            {
                string line = this.UserInterface.ReadLine();
                if (line == null)
                {
                    break;
                }

                line = line.Trim();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string commandResult = this.CommandExecutor.ProcessCommand(line);
                    this.UserInterface.WriteLine(commandResult);
                }
            }
        }
    }
}
