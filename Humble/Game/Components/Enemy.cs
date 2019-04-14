using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Enemy : DrawableGameComponent, ICollidable, IMovable, ISpawnable
    {
        private Game game;
        private SpriteBatch spriteBatch;

        public enum State
        {
            IDLE,
            ATTACKING,
            TRAVELING,
            DEATH,
        }

        public State currentState;

        private Texture2D boundsTexture;
        private Texture2D enemyTexture;

        public Enemy(Game game) : base(game)
        {
            this.game = game;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@Enemy.Initialize");
            base.Initialize();
        }

        /// Load
        /// 

        protected override void LoadContent()
        {
            Console.WriteLine("@Enemy.LoadContent");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            boundsTexture = new Texture2D(GraphicsDevice, 1, 1);
            boundsTexture.SetData(new[] { Color.Red });
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));
            spriteBatch.Draw(boundsTexture, Bounds, Color.White * 1.0f);
            spriteBatch.End();
        }

        /// Collision
        /// 

        public int Width = 20;
        public int Height = 20;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X - (Width / 2), (int)Position.Y - (Height / 2), Width, Height);
            }
        }

        public bool Intersects(Rectangle rectangle)
        {
            return rectangle.Intersects(Bounds);
        }

        public bool Contains(Vector2 point)
        {
            return Bounds.Contains(point.X, point.Y);
        }

        /// Movement
        /// 

        public Vector2 Position { get; set; }

        public void ChangePosition(Vector2 location)
        {
            Position = location;
        }

        /// Spawning
        /// 

        public Vector2 SpawnPoint { get; set; }

        public void Spawn(Vector2 spawnPoint)
        {
            SpawnPoint = SpawnPoint;
            ChangePosition(spawnPoint);
            currentState = State.IDLE;
        }

        public void Respawn()
        {
            Spawn(SpawnPoint);
        }

        /// Damage
        /// 

        public void Kill()
        {
            currentState = State.DEATH;
        }

        public bool IsDeath()
        {
            return currentState == State.DEATH;
        }

    }
}
