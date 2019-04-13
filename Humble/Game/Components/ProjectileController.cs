using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public class ProjectileController : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private List<Projectile> projectiles;

        public ProjectileController(Game game) : base(game)
        {
            projectiles = new List<Projectile>();
            DrawOrder = 2;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@ProjectileController.Initialize");
            base.Initialize();
        }

        /// Load
        /// 

        protected override void LoadContent()
        {
            Console.WriteLine("@ProjectileController.LoadContent");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            List<Projectile> expiredProjectiles = new List<Projectile>();

            foreach (Projectile projectile in projectiles)
            {

                if (projectile.isExpired())
                {
                    expiredProjectiles.Add(projectile);
                }
            }

            foreach (Projectile projectile in expiredProjectiles)
            {
                Game.Components.Remove(projectile);
                projectiles.Remove(projectile);
            }

            base.Update(gameTime);
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));

            foreach (Projectile projectile in projectiles)
            {
                projectile.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        /// Custom
        /// 

        public void Add(Projectile projectile)
        {
            Game.Components.Add(projectile);
            projectiles.Add(projectile);
        }

        public List<Projectile> List()
        {
            return projectiles;
        }
    }
}
