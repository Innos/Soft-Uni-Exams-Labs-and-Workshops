namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = null;
            ship = this.GameEngine.Starships.First(starship => starship.Name == shipName);
            System.Console.WriteLine(ship.ToString());
        }
    }
}
