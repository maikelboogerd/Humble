using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class AttackStrategy
    {
        private Random random = new Random();

        public enum State
        {
            ACTIVE,
            INACTIVE,
        }

        private State currentState;

        public AttackStrategy()
        {
            currentState = State.INACTIVE;
        }

        public void Attack()
        {
        }

        public void Stop()
        {
        }
    }
}
