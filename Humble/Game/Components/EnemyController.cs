using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class EnemyController : GameComponent
    {
        private Game game;
        private List<Enemy> enemies;

        public EnemyController(Game game) : base(game)
        {
            this.game = game;
            enemies = new List<Enemy>();
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@EnemyController.Initialize");
            base.Initialize();
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            List<Enemy> deathEnemies = new List<Enemy>();

            foreach (Enemy enemy in enemies)
            {
                if (enemy.IsDeath())
                {
                    deathEnemies.Add(enemy);
                }
            }

            foreach (Enemy enemy in deathEnemies)
            {
                if (true)
                {
                    // Respawn killed enemies.
                    var world = GameService.GetService<World>();
                    enemy.Spawn(world.spawnPoint);
                }
                else
                {
                    // Enemies stay death.
                    Game.Components.Remove(enemy);
                    enemies.Remove(enemy);
                }
            }
        }

        /// Custom
        /// 

        public Enemy Create()
        {
            Console.WriteLine(">> EnemyController.Create");
            Enemy enemy = new Enemy(game);
            Game.Components.Add(enemy);
            enemies.Add(enemy);
            return enemy;
        }

        public List<Enemy> List()
        {
            return enemies;
        }

    }
}
