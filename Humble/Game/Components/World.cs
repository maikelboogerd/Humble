using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Differ;

namespace Humble
{
    public class World : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D cursorTexture;

        public Level level;
        public Shape shape;
        public Differ.Shapes.Circle circle;
        public Differ.Shapes.Polygon box1;
        public Differ.Shapes.Polygon box2;

        public World(Game game) : base(game)
        {
            DrawOrder = 0;
        }

        /// Initialize
        ///

        public override void Initialize()
        {
            Console.WriteLine("@World.Initialize");
            level = new Level();
            shape = new Shape();

            box1 = Differ.Shapes.Polygon.rectangle(0, 0, 100, 300);
            box2 = Differ.Shapes.Polygon.rectangle(0, 0, 50, 150);

            level.Generate();
            base.Initialize();
        }

        /// Load
        ///

        protected override void LoadContent()
        {
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
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));

            level.Draw(spriteBatch);
            //shape.Draw(spriteBatch);
            // circle.Draw(spriteBatch);
            //var box = Differ.Shapes.Polygon.rectangle(0, 0, 50, 150);

            if (true){
                box1.Draw(spriteBatch);
                box2.Draw(spriteBatch);
            }

            if (true)
            {
                spriteBatch.Draw(cursorTexture, Cursor.Bounds, Color.White);
            }

            spriteBatch.End();
        }

        /// Custom
        ///

        public Boolean Intersects(Rectangle rectangle)
        {


            //box.rotation = 45;

            //var collideInfo = Collision.shapeWithShape(circle, box);

            //if (collideInfo != null)
            //{
            //    Console.WriteLine("-----------------");
            //    Console.WriteLine(collideInfo);
            //    //use collideInfo.separationX
            //    //    collideInfo.separationY
            //    //    collideInfo.normalAxisX
            //    //    collideInfo.normalAxisY
            //    //    collideInfo.overlap
            //}
            //return shape.Intersects(rectangle);
            return level.Intersects(rectangle);
        }

        public Vector2 spawnPoint
        {
            get
            {
                Console.WriteLine("@World.spawnPoint");
                //return shape.Center();
                return level.getSpawnPoint();
            }
        }
    }
}
