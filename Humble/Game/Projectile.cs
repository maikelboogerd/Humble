using System;
using Microsoft.Xna.Framework;

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

        public int Velocity;
        public float Angle;

        public Projectile()
        {
            Start = new Point(10, 10);
            Target = new Point(60, 60);
            Velocity = 10;
            Angle = 10;
        }

        public void Spawn()
        {
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
                    break;
                }
                case State.END:
                {
                    break;
                }
            }
        }

    }
}
