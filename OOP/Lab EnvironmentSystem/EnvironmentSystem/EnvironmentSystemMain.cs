namespace EnvironmentSystem
{
    using System;
    using System.Runtime.Remoting.Channels;

    using EnvironmentSystem.Core;
    using EnvironmentSystem.Core.Generator;

    public class EnvironmentSystemMain
    {
        private const int WorldWidth = 50;
        private const int WorldHeight = 30;

        static void Main()
        {
            var objectGenerator = new ObjectGenerator(WorldWidth, WorldHeight);
            var consoleRenderer = new ConsoleRenderer(WorldWidth, WorldHeight);
            var collisionHandler = new CollisionHandler(WorldWidth, WorldHeight);
            var controller = new Controller();

            var engine = new ExtendedEngine(WorldWidth,
                WorldHeight,
                objectGenerator,
                collisionHandler,
                consoleRenderer,
                controller);

            engine.Run();

        }
    }
}
