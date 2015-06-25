using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSystem.Models.Objects
{
    public class UnstableStar : FallingStar
    {
        private int lifetime = 8;

        public UnstableStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = base.GenerateImageProfile();
            this.CollisionGroup = CollisionGroup.Star;
        }

        public override void Update()
        {
            base.Update();
            this.lifetime--;
            if (this.lifetime == 0)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists)
            {
               return base.ProduceObjects();
            }
                return new EnvironmentObject[1] { new Explosion(this.Bounds.TopLeft.X - 2, this.Bounds.TopLeft.Y - 2, 5, 5) };
        }
    }
}
