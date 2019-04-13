using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class Cursor
    {
        public Cursor()
        {
        }

        public static Vector2 Position
        {
            get
            {
                MouseState mouse = Mouse.GetState();
                return new Vector2(mouse.X, mouse.Y);
            }

        }
    }
}
