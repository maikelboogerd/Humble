﻿using System;
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

        private Point startPosition;
        private Point currentPosition;
        private Point targetPosition;

        private int velocity = 10;
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
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Red });
            startPosition = new Point(10, 10);
            targetPosition = new Point(60, 60);
            base.Initialize();
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
                            currentPosition.X += velocity;
                            currentPosition.Y += velocity;
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

        public void Spawn(Point spawnPoint)
        {
            startPosition = spawnPoint;
            currentState = State.SPAWNED;
        }

        public void Charge()
        {
            if (currentState == State.SPAWNED)
            {
                currentState = State.CHARGING;
            }
        }

        public void Shoot()
        {
            currentPosition = startPosition;
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
                return new Rectangle(currentPosition.X - 5, currentPosition.Y - 5, 10, 10);
            }
        }
    }
}