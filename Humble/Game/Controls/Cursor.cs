using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
                Player player = GameService.GetService<Player>();
                return new Vector2(mouse.X + player.X, mouse.Y + player.Y);
            }

        }

        public static Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, 10, 10);
            }
        }

    }
}
