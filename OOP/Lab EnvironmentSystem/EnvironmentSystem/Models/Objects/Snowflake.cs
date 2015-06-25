namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    using EnvironmentSystem.Models.DataStructures;

    public class Snowflake : MovingObject
    {
        public Snowflake(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Snowflake;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Snow)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists == false)
            {
                return new EnvironmentObject[1] { new Snow(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, 1, 1) };
            }
            return new EnvironmentObject[0];
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { '*' } };
        }
    }
}
