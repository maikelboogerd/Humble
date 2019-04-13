using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class CollisionChecker : GameComponent
    {

        public PlayerController playerController { get; set; }
        public EnemyController enemyController { get; set; }
        public ProjectileController projectileController { get; set; }

        public CollisionChecker(Game game) : base(game)
        {
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            foreach (Projectile projectile in projectileController.List())
            {
                foreach (Enemy enemy in enemyController.List())
                {
                    if (enemy.Intersects(projectile.Bounds))
                    {
                        enemy.Kill();
                    }
                }

                if (true)
                {
                    // Enable PVP.
                    foreach (Player player in playerController.List())
                    {
                        if (player.Intersects(projectile.Bounds) && projectile.source != player)
                        {
                            player.Kill();
                        }
                    }
                }
            }
        }
    }
}
