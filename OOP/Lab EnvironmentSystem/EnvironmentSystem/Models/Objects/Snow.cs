using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    using EnvironmentSystem.Models.DataStructures;

    class Snow :EnvironmentObject
    {
        public Snow(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Snow;
        }

        public Snow(Rectangle bounds)
            : base(bounds)
        {
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '~' } };
        }

        public override void Update()
        {
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
