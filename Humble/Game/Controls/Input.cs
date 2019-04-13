using System;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class Input
    {
        /// Movement
        /// 

        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Left { get; set; }
        public Keys Right { get; set; }

        /// Combat
        /// 

        public Keys Shoot { get; set; }

        /// Default
        /// 

        public static Input Default()
        {
            return new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D,
                Shoot = Keys.Space,
            };
        }

        public static Input Alternative()
        {
            return new Input()
            {
                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.Left,
                Right = Keys.Right,
                Shoot = Keys.RightControl,
            };
        }

    }
}
