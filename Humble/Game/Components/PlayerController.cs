using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class PlayerController : GameComponent
    {
        private Game game;
        private Player player;
        private List<Player> players;

        public PlayerController(Game game) : base(game)
        {
            this.game = game;
            players = new List<Player>();
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@PlayerController.Initialize");
            base.Initialize();
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            foreach (Player player in players)
            {
                if (player.IsDeath())
                {
                    player.Respawn();
                }
            }

            base.Update(gameTime);
        }

        /// Custom
        /// 

        public Player Create(Input input)
        {
            Console.WriteLine(">> PlayerController.Create");
            player = new Player(game, input);
            Game.Components.Add(player);
            players.Add(player);
            return player;
        }

        public Player Get()
        {
            return player;
        }

        public List<Player> List()
        {
            return players;
        }

        public void HandleMovement(World world)
        {
            foreach (Player player in players)
            {
                Rectangle targetBounds = player.Bounds;

                if (Keyboard.GetState().IsKeyDown(player.input.Left))
                    targetBounds.X -= player.MovementSpeed;

                if (Keyboard.GetState().IsKeyDown(player.input.Right))
                    targetBounds.X += player.MovementSpeed;

                if (Keyboard.GetState().IsKeyDown(player.input.Up))
                    targetBounds.Y -= player.MovementSpeed;

                if (Keyboard.GetState().IsKeyDown(player.input.Down))
                    targetBounds.Y += player.MovementSpeed;

                if (world.Intersects(targetBounds))
                {
                    Vector2 targetPosition = new Vector2(targetBounds.X, targetBounds.Y);
                    player.ChangePosition(targetPosition);
                }
            }
        }

        public void HandleActions()
        {
            ProjectileController projectileController = GameService.GetService<ProjectileController>();
            Cursor cursor = GameService.GetService<Cursor>();

            foreach (Player player in players)
            {
                if (Keyboard.GetState().IsKeyDown(player.input.Shoot))
                {
                    Vector2 spawnPoint = player.Position;
                    Vector2 targetPoint = cursor.Position;
                    Projectile projectile = new Projectile(game, player);
                    projectileController.Add(projectile);
                    projectile.Spawn(spawnPoint);
                    projectile.Shoot(targetPoint);
                }
            }
        }

    }
}