using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    class Tile
    {
        public Rectangle rectangle;
        public Color color;

        public void Update() {}

        public void Draw(GraphicsDevice GraphicsDevice, SpriteBatch spriteBatch)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });

            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}
