using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class World : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;

        public Level level;
        public Shape shape;

        public World(Game game) : base(game)
        {
            DrawOrder = 0;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            level = new Level();
            shape = new Shape();
            level.Generate();
            base.Initialize();
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));

            level.Draw(spriteBatch);
            //shape.Draw(spriteBatch);

            spriteBatch.End();
        }

        /// Custom
        /// 

        public Boolean Intersects(Rectangle rectangle)
        {
            //return shape.Intersects(rectangle);
            return level.Intersects(rectangle);
        }

        public Vector2 spawnPoint
        {
            get
            {
                //return shape.Center();
                return level.getSpawnPoint();
            }
        }
    }
}
