using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Camera
    {
        private Player Player;

        public Camera(Player player)
        {
            Player = player;
        }

        public Vector3 Position
        {
            get
            {
                GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();
                // Return the Vector3 camera position without a Z axis.
                return new Vector3((Player.X - (GraphicsDevice.Viewport.Width / 2)) * -1,
                                   (Player.Y - (GraphicsDevice.Viewport.Height / 2)) * -1,
                                   0f);
            }
        }
    }
}
