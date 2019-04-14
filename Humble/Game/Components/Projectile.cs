using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public class Projectile : DrawableGameComponent, ICollidable, IMoveable, ISpawnable
    {
        private Texture2D boundsTexture;
        private Texture2D projectileTexture;

        public enum State
        {
            IDLE,
            CHARGING,
            TRAVELING,
            EXPIRED,
        }

        public State currentState;
        public object source;

        private Vector2 targetPosition;
        private Vector2 direction;

        private int travelSpeed = 20;
        private int travelLimit = 1000;
        private int travelDistance;

        public Projectile(Game game, object source) : base(game)
        {
            this.source = source;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            base.Initialize();
        }

        /// Load
        /// 

        protected override void LoadContent()
        {
            boundsTexture = new Texture2D(GraphicsDevice, 1, 1);
            boundsTexture.SetData(new[] { Color.Orange });
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case State.CHARGING:
                    {
                        travelSpeed += 1;
                        break;
                    }
                case State.TRAVELING:
                    {
                        if (travelDistance < travelLimit)
                        {
                            ChangePosition(Position + direction * travelSpeed);
                            travelDistance += travelSpeed;
                        }
                        else
                        {
                            Expire();
                        }
                        break;
                    }
            }
        }

        /// Draw
        /// 

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(boundsTexture, Bounds, Color.White * 0.8f);
        }

        /// Collision
        /// 

        public int Width = 10;
        public int Height = 10;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
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
        public int MovementSpeed { get { return travelSpeed; } }

        public void ChangePosition(Vector2 location)
        {
            Position = location;
        }

        /// Spawning
        /// 

        public Vector2 SpawnPoint { get; set; }

        public void Spawn(Vector2 spawnPoint)
        {
            SpawnPoint = spawnPoint;
            ChangePosition(spawnPoint);
            currentState = State.IDLE;
        }

        public void Respawn()
        {
        }

        /// Custom
        /// 

        public void Charge()
        {
            currentState = State.CHARGING;
        }

        public void Shoot(Vector2 targetPoint)
        {
            targetPosition = targetPoint;
            direction = Vector2.Normalize(targetPosition - SpawnPoint);
            currentState = State.TRAVELING;
        }

        public void Expire()
        {
            currentState = State.EXPIRED;
        }

        public bool isExpired()
        {
            return currentState == State.EXPIRED;
        }

    }
}
