using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public class World : DrawableGameComponent
    {
        private Game game;
        private SpriteBatch spriteBatch;
        private Vector2 gridSize;
        private List<Block> blocks;
        private Random random = new Random();

        public World(Game game) : base(game)
        {
            this.game = game;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gridSize = new Vector2(10, 10);
            int blockSize = 30;

            blocks = new List<Block>();

            for (int i = 0; i < gridSize.X; ++i)
            {
                for (int j = 0; j < gridSize.Y; ++j)
                {
                    Rectangle rectangle = new Rectangle(i * blockSize, j * blockSize, blockSize, blockSize);
                    Block block = new Block(game, rectangle);
                    blocks.Add(block);
                }
            }

            base.Initialize();
        }

        public Vector2 spawnPoint()
        {
            Block spawnBlock = blocks[random.Next(blocks.Count())];
            return spawnBlock.Center();
        }

        /// Collision
        /// 

        public Boolean Intersects(Rectangle rectangle)
        {
            foreach (Block block in blocks)
            {
                if (block.rectangle.Intersects(rectangle))
                    return true;
            }

            return false;
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime) {}

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            foreach (Block block in blocks)
                block.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
