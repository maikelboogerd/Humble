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

            gridSize = new Vector2(2, 3);

            blocks = new List<Block>();
            isometricBlocks = new List<IsometricBlock>();

            for (int j = 0; j < gridSize.Y; ++j)
            {
                for (int i = 0; i < gridSize.X; ++i)
                {
                    Vector2 blockPosition;

                    if (j % 2 == 0)
                        blockPosition = new Vector2(i * IsometricBlock.Width - (IsometricBlock.Width / 2), (j * IsometricBlock.Height / 2) / 2);
                    else
                        blockPosition = new Vector2(i * IsometricBlock.Width, (j * IsometricBlock.Height / 2) / 2);

                    IsometricBlock isometricBlock = new IsometricBlock(game, blockPosition);
                    isometricBlocks.Add(isometricBlock);

                }
            }

            base.Initialize();
        }

        public Vector2 spawnPoint()
        {
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

            foreach (IsometricBlock isometricBlock in isometricBlocks)
                isometricBlock.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
