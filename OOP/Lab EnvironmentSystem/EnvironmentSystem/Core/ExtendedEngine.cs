using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Core
{
    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.Objects;

    public class ExtendedEngine : Engine
    {
        public bool isRunning = true;
        protected readonly IController controller;

        public ExtendedEngine(int worldWidth, int worldHeight, IObjectGenerator<EnvironmentObject> objectGenerator, ICollisionHandler collisionHandler, IRenderer renderer,IController controller)
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj","Object cannot be null");
            }
            base.Insert(obj);
        }

        public override void Run()
        {
            controller.Pause += (sender, args) =>
            {
                this.isRunning = !this.isRunning;
            };
            base.Run();
        }

        protected override void ExecuteEnvironmentLoop()
        {
            controller.ProcessInput();

            if (this.isRunning)
            {
                base.ExecuteEnvironmentLoop();
                
            }
            
        }

    }
    
}
