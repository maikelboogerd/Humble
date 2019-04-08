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
        private SpriteBatch spriteBatch;
        public Level level;

        public World(Game game) : base(game)
        {
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            level = new Level();
            level.Generate();
            base.Initialize();
        }

        public Vector2 spawnPoint
        {
            get
            {
                return level.getSpawnPoint();
            }
        }

        /// Collision
        /// 

        public Boolean Intersects(Rectangle rectangle)
        {
            return level.Intersects(rectangle);
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime) {}

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));
            level.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
