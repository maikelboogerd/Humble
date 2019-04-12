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
        Random random = new Random();

        private SpriteBatch spriteBatch;
        public Level level;

        public Shape shape;

        private List<Projectile> projectiles = new List<Projectile>();

        public World(Game game) : base(game)
        {
            shape = new Shape();
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
                //return shape.Center();
                return level.getSpawnPoint();
            }
        }

        /// Collision
        /// 

        public Boolean Intersects(Rectangle rectangle)
        {
            //return shape.Intersects(rectangle);
            return level.Intersects(rectangle);
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {

            Projectile projectile;
            Point spawnPoint = new Point(random.Next(0, 800), random.Next(0, 800));

            if (projectiles.Count < 20)
            {
                projectile = new Projectile();
                projectile.Spawn(spawnPoint);
                projectile.Shoot();
                projectiles.Add(projectile);
            }
            else
            {
                projectiles.RemoveAt(0);
            }

            foreach (Projectile p in projectiles)
            {
                p.Update();
            }
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));
            level.Draw(spriteBatch);

            foreach (Projectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }
            //shape.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
