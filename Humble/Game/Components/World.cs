using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing;

namespace Humble
{
    public class World : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        public Level level;
        public Shape shape;
        public List<Polygon> polygons = new List<Polygon>();
        public Polygon player_collision;

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
            level.Generate();



            Polygon p = new Polygon();
            p.Points.Add(new Vector(100, 0));
            p.Points.Add(new Vector(150, 50));
            p.Points.Add(new Vector(100, 150));
            p.Points.Add(new Vector(0, 100));

            polygons.Add(p);

            p = new Polygon();
            p.Points.Add(new Vector(50, 50));
            p.Points.Add(new Vector(100, 0));
            p.Points.Add(new Vector(150, 150));
            p.Offset(80, 80);

            polygons.Add(p);

            p = new Polygon();
            p.Points.Add(new Vector(0, 50));
            p.Points.Add(new Vector(50, 0));
            p.Points.Add(new Vector(150, 80));
            p.Points.Add(new Vector(160, 200));
            p.Points.Add(new Vector(-10, 190));
            p.Offset(300, 300);

            polygons.Add(p);

            foreach (Polygon polygon in polygons) polygon.BuildEdges();

            player_collision = polygons[0];

            base.Initialize();
        }

        /// Load
        ///

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// Update
        ///

        public override void Update(GameTime gameTime)
        {
            //Vector playerTranslation = velocity;
        }

        /// Draw
        ///

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));

            Vector p1;
            Vector p2;
            foreach (Polygon polygon in polygons)
            {
                polygon.Draw(spriteBatch);
            }


            level.Draw(spriteBatch);
            //shape.Draw(spriteBatch);

            spriteBatch.End();
        }

        /// Custom
        ///

        public Boolean Intersects(Polygon polygonA, Polygon polygonB, Vector velocity = new Vector())
        {

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
