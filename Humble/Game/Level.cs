using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Level
    {
        private Random random = new Random();
        private Grid grid;

        public Level()
        {
        }

        /// Generation
        /// 

        public void Generate()
        {
            grid = new Grid(10, 10);
            grid.Fill();
        }

        /// Spawning
        /// 

        public Vector2 getSpawnPoint()
        {
            // Get a random block's center point as spawn location.
            IsometricBlock spawnBlock = grid.blocks[random.Next(grid.blocks.Count())];
            return spawnBlock.Center();
        }

        /// Collision
        /// 

        public bool Intersects(Rectangle rectangle)
        {
            foreach (IsometricBlock block in grid.blocks)
            {
                Vector2 point = new Vector2(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
                if (block.Intersects(point))
                    return true;
            }

            return false;
        }

        /// Draw
        /// 

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw each isometric block by calling it's Draw().
            foreach (IsometricBlock block in grid.blocks)
                block.Draw(spriteBatch);
        }
    }
}
