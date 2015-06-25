namespace EnvironmentSystem.Models.Objects
{
    #region

    using System;
    using System.Collections.Generic;

    #endregion

    public class FallingStar : MovingObject
    {
        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.CollisionGroup = CollisionGroup.Star;
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[3]
                       {
                           new Trail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y - 1, 1, 1), 
                           new Trail(this.Bounds.TopLeft.X - (this.Direction.X * 2), this.Bounds.TopLeft.Y - 2, 1, 1), 
                           new Trail(this.Bounds.TopLeft.X - (this.Direction.X * 3), this.Bounds.TopLeft.Y - 3, 1, 1)
                       };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;

            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new[,] { { 'O' } };
        }
    }
}