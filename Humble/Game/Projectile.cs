using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public class Projectile
    {
        enum State
        {
            IDLE,
            CHARGING,
            TRAVELING,
            INACTIVE,
        }

        State currentState = State.IDLE;

        public Point Start;
        public Point Location;
        public Point Target;

        private int Velocity;
        public int travelDistance;

        private Texture2D Texture;

        public Projectile()
        {
            Start = new Point(10, 10);
            Target = new Point(60, 60);
            Velocity = 10;
            travelDistance = 0;
        }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(Location.X - 5, Location.Y - 5, 10, 10);
            }
        }

        public void Spawn(Point spawnPoint)
        {
            Start = spawnPoint;
            currentState = State.IDLE;
        }

        public void Charge()
        {
            currentState = State.CHARGING;
        }

        public void Shoot()
        {
            Location = Start;
            currentState = State.TRAVELING;
        }

        public void Destroy()
        {
            currentState = State.TRAVELING;
        }

        public void Update()
        {
            switch (currentState)
            {
                case State.CHARGING:
                    {
                        Velocity += 1;
                        break;
                    }
                case State.TRAVELING:
                    {
                        if (travelDistance < 8000)
                        {
                            Location.X += Velocity;
                            Location.Y += Velocity;
                            travelDistance += Velocity;
                        }
                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();

            Texture = new Texture2D(GraphicsDevice, 1, 1);
            Texture.SetData(new[] { Color.Blue });
            spriteBatch.Draw(Texture, Bounds, Color.White * 0.5f);
        }
    }
}
