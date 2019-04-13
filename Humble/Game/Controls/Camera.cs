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
        private Player player;

        public Camera(Player player)
        {
            this.player = player;
        }

        public Vector3 Position
        {
            get
            {
                GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();
                return new Vector3((player.Position.X - (GraphicsDevice.Viewport.Width / 2)) * -1, (player.Position.Y - (GraphicsDevice.Viewport.Height / 2)) * -1, 0f);
            }
        }
    }
}
