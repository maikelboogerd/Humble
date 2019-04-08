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
        private TypedDictionary blockMapping;
        private List<int> layout = new List<int>() {
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 0, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1,
        };

        public Level()
        {
            blockMapping = new TypedDictionary();
            blockMapping.Add(0, typeof(Blocks.Lava));
            blockMapping.Add(1, typeof(Blocks.Grass));
            Console.WriteLine(blockMapping);
        }

        /// Generation
        /// 

        public void Generate()
        {
            grid = new Grid(layout);
            grid.Fill(blockMapping);
        }

        /// Spawning
        /// 

        public Vector2 getSpawnPoint()
        {
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
            foreach (IsometricBlock block in grid.blocks)
                block.Draw(spriteBatch);
        }
    }
}
