using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class MovementStrategy
    {
        private Random random = new Random();
        private IMoveable moveable;

        private Vector2 targetPosition;
        private int maxSteps = 20;
        private int stepCount = 0;

        public enum State
        {
            IDLE,
            MOVING,
            STOPPED,
        }

        private State currentState;

        public MovementStrategy(IMoveable moveable)
        {
            this.moveable = moveable;
            currentState = State.IDLE;
        }

        private Vector2 getTarget()
        {
            int angle = random.Next(360);
            double stepX = moveable.Position.X + moveable.MovementSpeed * maxSteps * Math.Cos(angle);
            double stepY = moveable.Position.Y + moveable.MovementSpeed * maxSteps * Math.Sin(angle);
            return new Vector2((int)stepX, (int)stepY);
        }

        private Vector2 getStep()
        {
            Vector2 direction = Vector2.Normalize(targetPosition - moveable.Position);
            return moveable.Position + direction * moveable.MovementSpeed;
        }

        public void Stop()
        {
            stepCount = 0;
            currentState = State.STOPPED;
        }

        public void Move()
        {
            var world = GameService.GetService<World>();

            if (stepCount > maxSteps)
            {
                Stop();
            }

            if (currentState == State.MOVING)
            {
                Vector2 stepPosition = getStep();
                stepCount += 1;

                if (world.Contains(stepPosition))
                {
                    moveable.ChangePosition(stepPosition);
                }
                else
                {
                    Stop();
                }
            }

            if (currentState == State.IDLE || currentState == State.STOPPED)
            {
                targetPosition = getTarget();
                currentState = State.MOVING;
            }

        }

    }
}
