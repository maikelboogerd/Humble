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
    public class World : DrawableGameComponent, ICollidable
    {
        private SpriteBatch spriteBatch;
        private Texture2D cursorTexture;

        public Level level;
        public Shape shape;

        public World(Game game) : base(game)
        {
            //level = new Level();
            level = new IsometricLevel();
            //shape = new Shape();
            DrawOrder = 0;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@World.Initialize");
            base.Initialize();
        }

        /// Load
        /// 

        protected override void LoadContent()
        {
            Console.WriteLine("@World.LoadContent");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursorTexture = new Texture2D(GraphicsDevice, 1, 1);
            cursorTexture.SetData(new[] { Color.Yellow });
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
            Cursor cursor = GameService.GetService<Cursor>();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));

            level.Draw(spriteBatch);
            //shape.Draw(spriteBatch);

            if (true)
            {
                spriteBatch.Draw(cursorTexture, new Rectangle((int)cursor.Position.X, (int)cursor.Position.Y, 10, 10), Color.White);
            }

            spriteBatch.End();
        }

        /// Collision
        /// 

        public Rectangle Bounds
        {
            get
            {
                return level.Bounds;
            }
            set
            {
            }
        }

        public bool Intersects(Rectangle rectangle)
        {
            return level.Intersects(rectangle);
        }

        public bool Contains(Vector2 point)
        {
            return level.Contains(point);
        }

        /// Custom
        /// 

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
