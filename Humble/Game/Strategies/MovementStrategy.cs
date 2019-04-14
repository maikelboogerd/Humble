using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class MovementStrategy
    {
        private Random random = new Random();
        private IMoveable moveable;

        public MovementStrategy(IMoveable moveable)
        {
            this.moveable = moveable;
        }

        public void Move()
        {
            var world = GameService.GetService<World>();

            int angle = random.Next(360);

            double stepX = moveable.Position.X + moveable.MovementSpeed * Math.Cos(angle);
            double stepY = moveable.Position.Y + moveable.MovementSpeed * Math.Sin(angle);

            Vector2 targetPosition = new Vector2((int)stepX, (int)stepY);

            if (world.Contains(targetPosition))
            {
                moveable.ChangePosition(targetPosition);
            }
        }

    }
}
