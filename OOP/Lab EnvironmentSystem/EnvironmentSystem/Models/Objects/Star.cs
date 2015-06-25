using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    using System.Data.SqlTypes;

    using EnvironmentSystem.Models.DataStructures;

    class Star : EnvironmentObject
    {
        private static readonly Random Random = new Random();

        private static readonly char[] Symbols = new char[] { '0', 'o', '@' };

        private int flickerTimer = 0;

        public Star(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
        }

        public override void Update()
        {
            this.flickerTimer++;
            if (this.flickerTimer == 10)
            {
                this.ImageProfile = this.GenerateImageProfile();
                this.flickerTimer = 0;
            }
            int chance = Random.Next(0, 300);
            if (chance == 100)
            {
                this.Exists = false;
            }

        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;

            if (hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists == false)
            {
                int direction = Random.Next(-1, 2);
                if (direction == 0)
                {
                    direction = -1;
                }
                return new EnvironmentObject[1]
                           {
                               new FallingStar(
                                   this.Bounds.TopLeft.X,
                                   this.Bounds.TopLeft.Y,
                                   1,
                                   1,
                                   new Point(direction, 1))
                           };
            }

            return new EnvironmentObject[0];
        }

        protected virtual char[,] GenerateImageProfile()
        {
            char symbol = Symbols[Random.Next(0, Symbols.Length)];
            return new char[,] { { symbol } };
        }


    }
}
