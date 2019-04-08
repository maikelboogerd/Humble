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
        private Random random = new Random();

        private Vector2 gridSize;
        private List<IsometricBlock> isometricBlocks;

        public World(Game game) : base(game)
        {
            this.game = game;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gridSize = new Vector2(4, 6);
            isometricBlocks = new List<IsometricBlock>();

            // Loop over the grid and create each block in order.
            for (int j = 0; j < gridSize.Y; ++j)
            {
                for (int i = 0; i < gridSize.X; ++i)
                {
                    Vector2 blockPosition;

                    if (j % 2 == 0)
                        blockPosition = new Vector2(i * IsometricBlock.Width - (IsometricBlock.Width / 2), (j * IsometricBlock.Height / 2) / 2);
                    else
                        blockPosition = new Vector2(i * IsometricBlock.Width, (j * IsometricBlock.Height / 2) / 2);

                    IsometricBlock isometricBlock = new Blocks.Grass(blockPosition);
                    isometricBlocks.Add(isometricBlock);

                }
            }

            base.Initialize();
        }

        public Vector2 spawnPoint()
        {
            // Get a random block's center point as spawn location.
            IsometricBlock spawnBlock = isometricBlocks[random.Next(isometricBlocks.Count())];
            return spawnBlock.Center();
        }

        /// Collision
        /// 

        public Boolean Intersects(Rectangle rectangle)
        {
            foreach (IsometricBlock isometricBlock in isometricBlocks)
            {
                Vector2 point = new Vector2(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
                if (isometricBlock.Intersects(point))
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

            // Draw each isometric block by calling it's Draw().
            foreach (IsometricBlock isometricBlock in isometricBlocks)
                isometricBlock.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
