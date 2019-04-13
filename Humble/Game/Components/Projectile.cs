using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public class Projectile : DrawableGameComponent
    {
        public enum State
        {
            SPAWNED,
            CHARGING,
            TRAVELING,
            EXPIRED,
        }

        public State currentState;

        private Vector2 startPosition;
        private Vector2 currentPosition;
        private Vector2 targetPosition;
        private Vector2 direction;

        private int velocity = 15;
        private int travelLimit = 1500;
        private int travelDistance;

        private Texture2D texture;

        public Projectile(Game game) : base(game)
        {
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            startPosition = new Vector2(10, 10);
            targetPosition = new Vector2(60, 60);
            base.Initialize();
        }

        /// Load
        /// 

        protected override void LoadContent()
        {
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Red });
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            switch (currentState)
            {
                case State.CHARGING:
                    {
                        velocity += 1;
                        break;
                    }
                case State.TRAVELING:
                    {
                        if (travelDistance < travelLimit)
                        {
                            currentPosition += direction * velocity;
                            //currentPosition.X += velocity;
                            //currentPosition.Y += velocity;
                            travelDistance += velocity;
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
            spriteBatch.Draw(texture, Bounds, Color.White * 0.5f);
        }

        /// Custom
        /// 

        public void Spawn(Vector2 spawnPoint)
        {
            startPosition = spawnPoint;
            currentPosition = startPosition;
            currentState = State.SPAWNED;
        }

        public void Charge()
        {
            if (currentState == State.SPAWNED)
            {
                currentState = State.CHARGING;
            }
        }

        public void Shoot(Vector2 targetPoint)
        {
            targetPosition = targetPoint;
            direction = Vector2.Normalize(targetPosition - startPosition);
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

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)currentPosition.X - 5, (int)currentPosition.Y - 5, 10, 10);
            }
        }
    }
}
