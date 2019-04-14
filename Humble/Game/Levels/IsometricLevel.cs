using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class IsometricLevel : Level
    {
        private Random random = new Random();

        private Grid grid;
        private ClassMapping blockMapping;
        private List<int> layout = new List<int>() {
            0, 0, 2, 2, 2, 1, 1, 1, 1,
            0, 0, 2, 2, 1, 1, 1, 1, 1,
            0, 0, 2, 2, 1, 1, 1, 1, 1,
            0, 2, 2, 2, 1, 1, 1, 1, 1,
            2, 2, 2, 2, 1, 1, 1, 1, 1,
            2, 2, 2, 2, 1, 1, 1, 1, 1,
            0, 0, 2, 2, 1, 1, 1, 1, 1,
            0, 0, 2, 2, 1, 1, 1, 1, 1,
            0, 0, 2, 2, 2, 1, 1, 1, 1,
        };

        public IsometricLevel()
        {
            blockMapping = new ClassMapping();
            blockMapping.Add(0, typeof(Blocks.Ice));
            blockMapping.Add(1, typeof(Blocks.Grass));
            blockMapping.Add(2, typeof(Blocks.Snow));
            grid = new Grid(layout);
            grid.Fill(blockMapping);
        }

        /// Collision
        /// 

        public override Rectangle Bounds { get; }

        public override bool Intersects(Rectangle rectangle)
        {
            foreach (IsometricBlock block in grid.blocks)
            {
                Vector2 point = new Vector2(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
                if (block.Intersects(point))
                    return true;
            }

            return false;
        }

        public override bool Contains(Vector2 point)
        {
            foreach (IsometricBlock block in grid.blocks)
            {
                if (block.Intersects(point))
                    return true;
            }

            return false;
        }

        /// Draw
        /// 

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (IsometricBlock block in grid.blocks)
                block.Draw(spriteBatch);
        }

        /// Custom
        /// 

        public override Vector2 getSpawnPoint()
        {
            IsometricBlock spawnBlock = grid.blocks[random.Next(grid.blocks.Count())];
            return spawnBlock.Center();
        }

    }
}
