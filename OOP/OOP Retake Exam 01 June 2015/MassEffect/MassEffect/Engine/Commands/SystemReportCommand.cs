using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Locations;

    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string systemName = commandArgs[1];

            StarSystem starSystem = null;
            starSystem = this.GameEngine.Galaxy.StarSystems.First(system => system.Name == systemName);

            IEnumerable<IStarship> intactShips = null;
            intactShips = this.GameEngine.Starships
                .Where(ship => ship.Location == starSystem)
                .Where(ship => ship.Health > 0)
                .OrderByDescending(ship => ship.Health)
                .ThenByDescending(ship => ship.Shields);

            StringBuilder output = new StringBuilder();

            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            IEnumerable<IStarship> destroyedShips = null;
            destroyedShips = this.GameEngine.Starships
                .Where(ship => ship.Location == starSystem)
                .Where(ship => ship.Health <= 0)
                .OrderBy(ship => ship.Name);

            output.AppendLine("Destroyed ships:");
            output.Append(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString());
        }
    }
}
