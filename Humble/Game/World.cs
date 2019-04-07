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
        Game game;
        SpriteBatch spriteBatch;

        Vector2 gridSize;
        List<Block> blocks;

        public World(Game game) : base(game)
        {
            this.game = game;
        }

        public override void Initialize()
        {
            Console.WriteLine("@World.Initialize");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            gridSize = new Vector2(10, 10);
            int blockSize = 40;

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

        public Boolean Intersects(Rectangle rectangle)
        {
            foreach (Block block in blocks)
            {
                if (block.rectangle.Intersects(rectangle))
                    return true;
            }

            return false;
        }

        public Vector2 spawnPoint()
        {
            return new Vector2(10, 10);
        }

        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine("@World.Update");
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            foreach (Block block in blocks)
                block.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
